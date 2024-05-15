using AutoMapper;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.ChattingDtos;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.NotificationDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.PaymentDtos;
using DeToiServer.Dtos.RealTimeDtos;
using DeToiServer.Models;
using DeToiServer.Services.CacheService;
using DeToiServer.Services.ChattingService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.NotificationService;
using DeToiServer.Services.OrderManagementService;
using DeToiServer.Services.PaymentService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Chat;
using DeToiServerData;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DeToiServer.RealTime
{
    public class ChatHub : Hub<IChatClient>
    {
        private readonly IFreelanceAccountService _freelancerService;
        private readonly ICustomerAccountService _customerService;
        private readonly IOrderManagementService _orderService;
        private readonly INotificationService _notificationService;
        private readonly IChattingService _chattingService;
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;
        private readonly ICacheService _cacheService;
        private readonly DataContext _context;
        private readonly UnitOfWork _uow;
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(
            UnitOfWork uow,
            DataContext context,
            IFreelanceAccountService freelancerService,
            ICustomerAccountService customerService,
            IOrderManagementService orderService,
            INotificationService notificationService,
            IChattingService chattingService,
            IPaymentService paymentService,
            ICacheService cacheService,
            IMapper mapper,
            ILogger<ChatHub> logger)
        {
            _freelancerService = freelancerService;
            _customerService = customerService;
            _orderService = orderService;
            _notificationService = notificationService;
            _chattingService = chattingService;
            _mapper = mapper;
            _paymentService = paymentService;
            _cacheService = cacheService;
            _context = context;
            _uow = uow;
            _logger = logger;
        }

        public async Task<RealtimeResponseDto> SendMessageToFreelancer(PostOrderDto order)
        {
            // Get freelance accounts that are in the acceptable zone.
            var freelanceAccounts = await _context.Freelancers
                .AsNoTracking()
                .Include(fl => fl.Account)
                .Include(fl => fl.Address)
                .ToListAsync();

            // TODO: No need to filter freelance by address -> they will evaluate the Order
            // => Will filter in the future
            //string? addressOption = (await _context.ServiceTypes
            //    .Where(st => st.Id.Equals(order.Services.ServiceTypeId))
            //    .FirstOrDefaultAsync())?.AddressRequireOption;

            //freelanceAccounts = freelanceAccounts
            //        .Where(acc => {
            //            if (acc.Address != null && acc.Address.Count > 0)
            //            {
            //                var freelanceAddress = acc.Address.FirstOrDefault();
            //                if (order.Address == null || order.Address?.Count == 0) return true;
            //                if (freelanceAddress == null) return false;
            //                return Helper.IsInAcceptableZone(
            //                    new Coordination()
            //                    {
            //                        Lat = order.Address?.First().Lat ?? 0,
            //                        Lon = order.Address?.First().Lon ?? 0
            //                    },
            //                    new Coordination()
            //                    {
            //                        Lat = freelanceAddress.Lat,
            //                        Lon = freelanceAddress.Lon
            //                    }); 
            //            }
            //            return false;
            //        }).ToList();

            // Online users that are connecting to SignalR
            var users = await _context.Users
                .AsNoTracking()
                .Include(u => u.Connections)
                .ToListAsync();

            // Send a message to the online freelancers
            foreach (var freelanceAcc in freelanceAccounts)
            {
                foreach (var user in users)
                {
                    if (user.Phone.Equals(freelanceAcc.Account.CombinedPhone))
                    {
                        if (user.Connections != null)
                        {
                            foreach (var connection in user.Connections)
                            {
                                await Clients.Client(connection.ConnectionId).ReceiveCustomerOrder(order);
                            }
                        }
                    }
                }
            }

            return new RealtimeResponseDto
            {
                Message = "Thành công.",
                Data = order
            };
        }

        public async Task<RealtimeResponseDto> SendReceiveOrderMessageToFreelancer(string freelancerPhone, GetOrderDto getOrderDto)
        {
            // Online users that are connecting to SignalR
            var users = await _context.Users
                .AsNoTracking()
                .Include(u => u.Connections)
                .ToListAsync();

            // Send a message to the online freelancers
            foreach (var user in users)
            {
                if (user.Phone.Equals(freelancerPhone))
                {
                    if (user.Connections != null)
                    {
                        foreach (var connection in user.Connections)
                        {
                            await Clients.Client(connection.ConnectionId).ReceiveConfirmCustomerOrder(getOrderDto);
                        }
                    }
                }
            }

            return new RealtimeResponseDto
            {
                Message = "Thành công.",
                Data = getOrderDto
            };
        }

        public async Task<RealtimeResponseDto> SendMessageToCustomer(GetFreelancerAndPreviewPriceDto matchingFreelancer)
        {
            var freelancer = await _freelancerService.GetDetailWithStatistic(matchingFreelancer.FreelancerId);

            if (freelancer == null)
            {
                await Clients.Caller.ErrorOccurred(new NotificationDto()
                {
                    NotificationType = NotificationType.Information.ToString(),
                    Title = "Không tìm thấy Freelancer",
                    Body = "Rất tiếc, Freelancer này không tồn tại trong hệ thống của chúng tôi"
                });
                return new RealtimeResponseDto
                {
                    Status = false,
                    Message = "Rất tiếc, Freelancer này không tồn tại trong hệ thống của chúng tôi",
                    Data = new { Message = "Không tìm thấy Freelancer" }
                };
            }

            if (freelancer.Account.Role.Equals(GlobalConstant.UnverifiedFreelancer))
            {
                // Add Notification here for fe to catch
                // Freelancer chưa verify 0 đc báo giá.
                await Clients.Caller.ErrorOccurred(new NotificationDto()
                {
                    NotificationType = NotificationType.Information.ToString(),
                    Title = "Tài khoản chưa xác thực không thể báo giá",
                    Body = "Admin chưa xét duyệt tài khoản của bạn, vui lòng chờ."
                });
                return new RealtimeResponseDto
                {
                    Status = false,
                    Message = "Admin chưa xét duyệt tài khoản của bạn, vui lòng chờ.",
                    Data = new { Message = "Tài khoản chưa xác thực không thể báo giá" }
                };
            }

            //var minPrice = await _paymentService.GetMinServicePrice();
            //if (matchingFreelancer.PreviewPrice < minPrice)
            //{
            //    await Clients.Caller.ErrorOccurred(new NotificationDto()
            //    {
            //        NotificationType = NotificationType.Information.ToString(),
            //        Title = "Bạn báo giá với giá trị không cho phép",
            //        Body = "Bạn đang báo giá với mức giá thấp hơn so với quy định của [Điều khoản dịch vụ], hãy thử lại"
            //    });
            //    return new RealtimeResponseDto
            //    {
            //        Status = false,
            //        Message = "Bạn đang báo giá với mức giá thấp hơn so với quy định của [Điều khoản dịch vụ], hãy thử lại",
            //        Data = new { Message = "Bạn báo giá với giá trị không cho phép" }
            //    };
            //}

            var commissionFee = await _paymentService.GetCommission();
            var order = await _orderService.GetByIdWithServiceType(matchingFreelancer.OrderId);

            if (order == null)
            {
                await Clients.Caller.ErrorOccurred(new NotificationDto()
                {
                    NotificationType = NotificationType.Information.ToString(),
                    Title = "Đơn hàng không tồn tại",
                    Body = "Đơn hàng này không tồn tại, vui lòng báo giá đơn khác"
                });
                return new RealtimeResponseDto
                {
                    Status = false,
                    Message = "Đơn hàng này không tồn tại, vui lòng báo giá đơn khác",
                    Data = new { Message = "Đơn hàng không tồn tại" }
                };
            }

            //if (freelancer.Balance < matchingFreelancer.PreviewPrice * commissionFee)
            //{
            //    await Clients.Caller.ErrorOccurred(new NotificationDto()
            //    {
            //        NotificationType = NotificationType.Information.ToString(),
            //        Title = "Không đủ số tiền trong tài khoản",
            //        Body = "Tài khoản của bạn không đủ để báo giá đơn hàng này"
            //    });
            //    return new RealtimeResponseDto
            //    {
            //        Status = false,
            //        Message = "Tài khoản của bạn không đủ để báo giá đơn hàng này",
            //        Data = new { Message = "Không đủ số tiền trong tài khoản" }
            //    };
            //}

            var customer = await _customerService.GetByIdWithAccount(order.CustomerId);
            var biddingOrder = _mapper.Map<BiddingOrder>(matchingFreelancer);
            var existingBiddingOrder = await _context.BiddingOrders
                .Where(bo => bo.OrderId == biddingOrder.OrderId && bo.FreelancerId == biddingOrder.FreelancerId)
                .FirstOrDefaultAsync();

            if (existingBiddingOrder != null)
            {
                // Add Notification here for fe to catch
                await Clients.Caller.ErrorOccurred(new NotificationDto()
                {
                    NotificationType = NotificationType.Information.ToString(),
                    Title = "Đơn đã được báo giá",
                    Body = "Bạn đã báo giá đơn hàng này, không thể tiếp tục báo giá"
                });
                return new RealtimeResponseDto
                {
                    Status = false,
                    Message = "Bạn đã báo giá đơn hàng này, không thể tiếp tục báo giá",
                    Data = new { Message = "Đơn đã được báo giá" }
                };
            }

            // Save bidding orders, update orderStatus.
            try
            {
                if (order.ServiceStatusId.Equals(StatusConst.Created))
                {
                    order.ServiceStatusId = StatusConst.OnMatching;
                }
                _context.BiddingOrders.Add(biddingOrder);

                // TODO: Need to uncommend
                //var updated = await _paymentService
                //    .UpdateFreelancerBalance(new UpdateFreelanceBalanceDto()
                //    {
                //        Id = freelancer.AccountId,
                //        Method = GlobalConstant.Payment.AppFee,
                //        WalletType = GlobalConstant.Payment.Wallet.Personal,
                //        Value = matchingFreelancer.PreviewPrice * commissionFee,
                //    }, minus: true, addRecord: false);

                //if (updated == null)
                //{
                //    await Clients.Caller.ErrorOccurred(new NotificationDto()
                //    {
                //        NotificationType = NotificationType.Error.ToString(),
                //        Title = "Không thể báo giá",
                //        Body = "Tài khoản bạn không đủ tiền để báo giá đơn hàng này, hãy nạp tiền để tiếp tục"
                //    });
                //    return new RealtimeResponseDto
                //    {
                //        Status = false,
                //        Message = "Tài khoản bạn không đủ tiền để báo giá đơn hàng này, hãy nạp tiền để tiếp tục",
                //        Data = new { Message = "Không thể báo giá" }
                //    };
                //}

                if (!await _uow.SaveChangesAsync())
                {
                    // Add Notification here for fe to catch
                    await Clients.Caller.ErrorOccurred(new NotificationDto()
                    {
                        NotificationType = NotificationType.Error.ToString(),
                        Title = "Không thể báo giá",
                        Body = "Đã có lỗi trong quá trình báo giá, vui lòng thử lại"
                    });
                    return new RealtimeResponseDto
                    {
                        Status = false,
                        Message = "Đã có lỗi trong quá trình báo giá, vui lòng thử lại",
                        Data = new { Message = "Không thể báo giá" }
                    };
                }

                var user = await _context.Users
                    .AsNoTracking()
                    .Where(u => u.Phone.Equals(customer.Account.CombinedPhone))
                    .Include(u => u.Connections)
                    .FirstOrDefaultAsync();

                if (user?.Connections != null)
                {
                    freelancer.PreviewPrice = matchingFreelancer.PreviewPrice;
                    freelancer.BiddingNote = matchingFreelancer.BiddingNote;
                    _cacheService.RemoveData($"Order-freelancer{freelancer.Id}-bidding");
                    foreach (var connection in user.Connections)
                    {
                        await Clients.Client(connection.ConnectionId).ReceiveFreelancerResponse(freelancer);
                    }
                }

                await _notificationService.PushNotificationAsync(new PushNotificationDto()
                {
                    ExpoPushTokens = [customer.Account.ExpoPushToken],
                    Title = $"📣 Đã có Freelancer báo giá!",
                    Body = $"Đơn dịch vụ {order.OrderServiceTypes.First().ServiceType.Name} của bạn được Freelancer đã báo giá!",
                    Data = new()
                    {
                        ActionKey = GlobalConstant.Notification.FreelancerQuoteServiceToCustomer,
                    },
                }, [customer.AccountId]);

                return new RealtimeResponseDto
                {
                    Message = "Báo giá thành công.",
                    Data = new { Message = "Báo giá thành công." } // updated
                };
            }
            catch(Exception ex)
            {
                _logger.LogError("Cannot save bidding order: " + ex.Message);
                return new RealtimeResponseDto
                {
                    Status = false,
                    Message = "Có lỗi xảy ra trong quá trình lưu kết quả báo giá.",
                    Data = new { Message = ex.Message }
                };
            }
        }

        public async Task<RealtimeResponseDto> SendOrderStatusToCustomer(UpdateOrderStatusRealTimeDto orderStatus)
        {
            var user = await _context.Users
                .AsNoTracking()
                .Include(u => u.Connections)
                .FirstOrDefaultAsync(user => user.Phone.Equals(orderStatus.CustomerPhone));

            if (user?.Connections != null)
            {
                foreach (var connection in user.Connections)
                {
                    await Clients.Client(connection.ConnectionId).ReceiveFreelancerStatusResponse(new UpdateOnMovingOrderStatusDto()
                    {
                        ServiceStatusId = orderStatus.ServiceStatusId,
                        Address = orderStatus.Address
                    });
                }
            }

            return new RealtimeResponseDto
            {
                Message = "Thành công.",
                Data = new { Message = "Gửi trạng thái đơn hàng thành công." }
            };
        }

        public async Task SendFeasibleOrderToFreelancer(SendFeasibleOrderFreelancerDto orderData)
        {
            var userList = await _context.Users
                .AsNoTracking()
                .Where(u => orderData.FreelancerPhones.Contains(u.Phone))
                .Include(u => u.Connections)
                .ToListAsync();

            foreach (var user in userList)
            {
                if (user?.Connections != null)
                {
                    foreach (var connection in user.Connections)
                    {
                        await Clients.Client(connection.ConnectionId)
                            .ReceiveFreelancerFeasibleOrder(orderData.OrderToSend);
                    }
                }
            }
        }

        public async Task<RealtimeResponseDto> SendMovingStatusToCustomer(UpdateMovingStatusDto orderStatus)
        {
            var order = await _orderService.GetById(orderStatus.OrderId);

            if (order == null)
            {
                await Clients.Caller.ErrorOccurred(new NotificationDto()
                {
                    NotificationType = NotificationType.Error.ToString(),
                    Title = "Gửi vị trí thât bại",
                    Body = "Gửi vị trí thất bại, vui lòng thử lại"
                });
                return new RealtimeResponseDto
                {
                    Status = false,
                    Message = "Gửi vị trí thất bại, vui lòng thử lại",
                    Data = new { Message = "Gửi vị trí thất bại, vui lòng thử lại" }
                };
            }

            var customer = await _customerService.GetByAccId(order.CustomerId);
            var user = await _context.Users
                .AsNoTracking()
                .Include(u => u.Connections)
                .FirstOrDefaultAsync(user => user.Phone.Equals(customer.Account.CombinedPhone));

            if (user?.Connections != null)
            {
                foreach (var connection in user.Connections)
                {
                    await Clients.Client(connection.ConnectionId).ReceiveFreelancerPositionResponse(new UpdateMovingStatusDto()
                    {
                        Address = orderStatus.Address,
                        OrderId = orderStatus.OrderId
                    });
                }
            }

            return new RealtimeResponseDto
            {
                Message = "Thành công.",
                Data = new { Message = "Gửi vị trí thành công" }
            };
        }

        public async Task<RealtimeResponseDto> SendChatMessageToAccount(PostSendMessageRealtimeDto sendMessage)
        {
            var freelance = await _context.Freelancers.AsNoTracking().AsSplitQuery().Include(fl => fl.Account)
                .FirstOrDefaultAsync(fl => fl.Id.Equals(sendMessage.Id) || fl.AccountId.Equals(sendMessage.Id));
            var customer = await _context.Customers.AsNoTracking().AsSplitQuery().Include(fl => fl.Account)
                .FirstOrDefaultAsync(cs => cs.Id.Equals(sendMessage.Id) || cs.AccountId.Equals(sendMessage.Id));

            if (freelance == null && customer == null)
            {
                await Clients.Caller.ErrorOccurred(new NotificationDto()
                {
                    NotificationType = NotificationType.Error.ToString(),
                    Title = "Gửi tin nhắn thât bại",
                    Body = $"Không tìm được tài khoản có Id:{sendMessage.Id}"
                });
                return new RealtimeResponseDto
                {
                    Status = false,
                    Message = $"Không tìm được tài khoản có Id:{sendMessage.Id}",
                    Data = sendMessage
                };
            }

            Account currentAccount = freelance != null ? freelance.Account : customer!.Account;

            var sentMsg = await _chattingService.PostSendMessageByAccountId(sendMessage.Id, new()
            {
                Image = sendMessage.Image,
                IsSystem = sendMessage.IsSystem,
                Content = sendMessage.Content ?? "",
                SendTo = sendMessage.SendTo
            });
            await _uow.SaveChangesAsync();

            var receiveUser = await _context.Accounts.FirstOrDefaultAsync(a => a.Id.Equals(sendMessage.SendTo));
            if (receiveUser != null)
            {
                var connectTo = await _context.Users.AsNoTracking().Include(u => u.Connections)
                    .FirstOrDefaultAsync(user => user.Phone.Contains(receiveUser.Phone));

                if (connectTo?.Connections != null)
                {
                    foreach (var connection in connectTo.Connections)
                    {
                        await Clients.Client(connection.ConnectionId).ReceiveRealtimeMessageFromAccount(sentMsg);
                    }
                }
            }

            return new RealtimeResponseDto
            {
                Status = true,
                Message = "Gửi tin nhắn thành công",
                Data = sendMessage
            };
        }

        public override async Task OnConnectedAsync()
        {
            var phone = Context.GetHttpContext()?.Request.Query["phone"].ToString();

            if (!string.IsNullOrEmpty(phone))
            {
                var user = _context.Users
                .Include(u => u.Connections)
                .SingleOrDefault(u => u.Phone == phone);

                if (user == null)
                {
                    user = new User
                    {
                        Phone = phone,
                        Connections = new List<Connection>()
                    };
                    _context.Users.Add(user);
                }

                user.Connections!.Add(new Connection
                {
                    ConnectionId = Context.ConnectionId,
                    UserAgent = Context.GetHttpContext()?.Request.Headers["User-Agent"],
                    Connected = true
                });

                await _context.SaveChangesAsync();
            }

            //else
            //{
            //    await Groups.AddToGroupAsync(Context.ConnectionId, "guests");
            //}

            await base.OnConnectedAsync();
        }

        // TODO: Do we actually remove as much info as possible
        public override async Task OnDisconnectedAsync(Exception? ex)
        {
            var phone = Context.GetHttpContext()?.Request.Query["phone"].ToString();
            var connection = _context.Connections.Find(Context.ConnectionId);

            // Remove officers' connection from the db
            if (connection != null)
            {
                _context.Connections.Remove(connection);

                // remove the user(phone) that doesn't have any connection.
                var connectionCount = _context.Connections.Where(con => con.UserPhone == connection.UserPhone).Count();

                if (connectionCount == 1)
                {
                    var userWithLastConnection = _context.Users.Find(connection.UserPhone);

                    // Check if the entity exists
                    if (userWithLastConnection != null)
                    {
                        // Remove the entity from the context
                        _context.Users.Remove(userWithLastConnection);
                    }
                }

            }

            // Remove guests from the guests group
            //if (string.IsNullOrEmpty(phone))
            //{
            //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, "guests");
            //}

            await _context.SaveChangesAsync();
            await base.OnDisconnectedAsync(ex);
        }
    }
}