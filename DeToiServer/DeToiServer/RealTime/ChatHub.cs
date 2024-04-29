using AutoMapper;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.NotificationDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.PaymentDtos;
using DeToiServer.Dtos.RealTimeDtos;
using DeToiServer.Models;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.NotificationService;
using DeToiServer.Services.OrderManagementService;
using DeToiServer.Services.PaymentService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.Helper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DeToiServer.RealTime
{
    public class ChatHub : Hub<IChatClient>
    {
        private readonly IFreelanceAccountService _freelancerService;
        private readonly ICustomerAccountService _customerService;
        private readonly IOrderManagementService _orderService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;
        private readonly DataContext _context;
        private readonly UnitOfWork _uow;
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(UnitOfWork uow, DataContext context, IFreelanceAccountService freelancerService, ICustomerAccountService customerService, IOrderManagementService orderService, INotificationService notificationService, IPaymentService paymentService, IMapper mapper, ILogger<ChatHub> logger)
        {
            _freelancerService = freelancerService;
            _customerService = customerService;
            _orderService = orderService;
            _notificationService = notificationService;
            _mapper = mapper;
            _paymentService = paymentService;
            _context = context;
            _uow = uow;
            _logger = logger;
        }

        public async Task SendMessageToFreelancer(PostOrderDto order)
        {
            // Get freelance accounts that are in the acceptable zone.
            var freelanceAccounts = await _context.Freelancers
                .AsNoTracking()
                .Include(fl => fl.Account)
                .Include(fl => fl.Address)
                .ToListAsync();

            freelanceAccounts = freelanceAccounts
                    .Where(acc => {
                        if (acc.Address != null && acc.Address.Count > 0)
                        {
                            var freelanceAddress = acc.Address.FirstOrDefault();

                            if (freelanceAddress == null) return false;

                            if (order.Address.Count == 0) return true;

                            return Helper.IsInAcceptableZone(
                                new Coordination()
                                {
                                    Lat = order.Address.First().Lat,
                                    Lon = order.Address.First().Lon
                                },
                                new Coordination()
                                {
                                    Lat = freelanceAddress.Lat,
                                    Lon = freelanceAddress.Lon
                                }); 
                        }
                        return false;
                    }).ToList();

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
        }

        public async Task SendReceiveOrderMessageToFreelancer(string freelancerPhone, GetOrderDto getOrderDto)
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
        }

        public async Task SendMessageToCustomer(GetFreelancerAndPreviewPriceDto matchingFreelancer)
        {
            var freelancer = await _freelancerService.GetDetailWithStatistic(matchingFreelancer.FreelancerId);
            if (freelancer.Account.Role.Equals(GlobalConstant.UnverifiedFreelancer))
            {
                // Add Notification here for fe to catch
                // Freelancer chưa verify 0 đc báo giá.
                await Clients.Caller.ErrorOccurred(new NotificationDto()
                {
                    NotificationType = NotificationType.Information.ToString(),
                    Title = "Tài khoản chưa xác thực không thể báo giá",
                    Body = "Bạn chưa xác thực tài khoản, vui lòng xác thực tài khoản của bạn để tiếp tục"
                });
                return;
            }

            var minPrice = (await _uow.PaymentRepo.GetAllFeeAsync())
                .Where(f => f.Id.Equals(GlobalConstant.Fee.Id.MinServicePrice)).First().Amount;
            var commissionFee = (await _uow.PaymentRepo.GetAllFeeAsync())
                .Where(f => f.Id.Equals(GlobalConstant.Fee.Id.PlatformFee)).First().Amount;
            if (matchingFreelancer.PreviewPrice < minPrice)
            {
                await Clients.Caller.ErrorOccurred(new NotificationDto()
                {
                    NotificationType = NotificationType.Information.ToString(),
                    Title = "Bạn báo giá với giá trị không cho phép",
                    Body = "Bạn đang báo giá với mức giá thấp hơn so với quy định của [Điều khoản dịch vụ], hãy thử lại"
                });
                return;
            }

            var order = await _orderService.GetById(matchingFreelancer.OrderId);

            if (order == null) return;

            if (freelancer.Balance < matchingFreelancer.PreviewPrice * commissionFee)
            {
                await Clients.Caller.ErrorOccurred(new NotificationDto()
                {
                    NotificationType = NotificationType.Information.ToString(),
                    Title = "Không đủ số tiền trong tài khoản",
                    Body = "Tài khoản của bạn không đủ để báo giá đơn hàng này"
                });
                return;
            }

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
                return;
            }

            // Save bidding orders, update orderStatus.
            try
            {
                if (order.ServiceStatusId.Equals(StatusConst.Created))
                {
                    order.ServiceStatusId = StatusConst.OnMatching;
                }
                _context.BiddingOrders.Add(biddingOrder);
                var updated = await _paymentService
                    .UpdateFreelancerBalance(new UpdateFreelanceBalanceDto()
                    {
                        Id = freelancer.AccountId,
                        Method = GlobalConstant.Payment.Card,
                        WalletType = GlobalConstant.Payment.Wallet.Personal,
                        Value = matchingFreelancer.PreviewPrice * commissionFee,
                    }, true);

                if (updated == null)
                {
                    await Clients.Caller.ErrorOccurred(new NotificationDto()
                    {
                        NotificationType = NotificationType.Error.ToString(),
                        Title = "Không thể báo giá",
                        Body = "Tài khoản bạn không đủ tiền để báo giá đơn hàng này, hãy nạp tiền để tiếp tục"
                    });
                    return;
                }

                if (!await _uow.SaveChangesAsync())
                {
                    // Add Notification here for fe to catch
                    await Clients.Caller.ErrorOccurred(new NotificationDto()
                    {
                        NotificationType = NotificationType.Error.ToString(),
                        Title = "Không thể báo giá",
                        Body = "Đã có lỗi trong quá trình báo giá, vui lòng thử lại"
                    });
                    return;
                }

                var user = await _context.Users
                    .AsNoTracking()
                    .Where(u => u.Phone.Equals(customer.Account.CombinedPhone))
                    .Include(u => u.Connections)
                    .FirstOrDefaultAsync();

                if (user?.Connections != null)
                {
                    freelancer.PreviewPrice = matchingFreelancer.PreviewPrice;

                    foreach (var connection in user.Connections)
                    {
                        await Clients.Client(connection.ConnectionId).ReceiveFreelancerResponse(freelancer);
                    }
                }

                await _notificationService.PushNotificationAsync(new PushNotificationDto()
                {
                    ExpoPushTokens = [customer.Account.ExpoPushToken],
                    Title = "Đã có Freelancer báo giá!",
                    Body = "Freelancer đã báo giá cho đơn của bạn! Hãy kiểm tra danh sách đơn nhé.",
                    Data = new()
                    {
                        ActionKey = GlobalConstant.Notification.FreelancerQuoteServiceToCustomer,
                    },
                }, [customer.AccountId]);
            }
            catch(Exception ex)
            {
                _logger.LogError("Cannot save bidding order: " + ex.Message);
            }
        }

        public async Task SendOrderStatusToCustomer(UpdateOrderStatusRealTimeDto orderStatus)
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
        }

        public override async Task OnConnectedAsync()
        {
            var phone = Context.GetHttpContext()?.Request.Query["phone"].ToString();

            if (!string.IsNullOrEmpty(phone))
            {
                phone = $"+{phone.Trim()}";
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