using AutoMapper;
using DeToiServer.ConfigModels;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.NotificationDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.PaymentDtos;
using DeToiServer.Dtos.RealTimeDtos;
using DeToiServer.RealTime;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.NotificationService;
using DeToiServer.Services.OrderManagementService;
using DeToiServer.Services.PaymentService;
using DeToiServer.Services.UserService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models.Payment;
using DeToiServerCore.QueryModels.OrderQueryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/order")]
    public class OrderController : Controller
    {
        private readonly UnitOfWork _uow;
        private readonly IOrderManagementService _orderService;
        private readonly IBiddingOrderService _biddingOrderService;
        private readonly ICustomerAccountService _customerAcc;
        private readonly IFreelanceAccountService _freelancerAcc;
        private readonly IUserService _userService;
        private readonly RealtimeConsumer _rabbitMQConsumer;
        private readonly IMapper _mapper;
        private readonly VnPayConfigModel _vnPayConfig;
        private readonly INotificationService _notificationService;
        private readonly IPaymentService _paymentService;
        private readonly ILogger<OrderController> _logger;
        private readonly double _commissionRate = 0;

        public OrderController(
            UnitOfWork uow,
            IOrderManagementService orderService,
            IBiddingOrderService biddingOrderService,
            ICustomerAccountService customerAcc,
            IFreelanceAccountService freelancerAcc,
            IUserService userService,
            RealtimeConsumer rabbitMQConsumer,
            //IMessageBusClient messageBusClient,
            IOptions<VnPayConfigModel> vnPayConfig,
            INotificationService notificationService,
            IPaymentService paymentService,
            IMapper mapper, 
            ILogger<OrderController> logger)
        {
            _uow = uow;
            _orderService = orderService;
            _biddingOrderService = biddingOrderService;
            _customerAcc = customerAcc;
            _freelancerAcc = freelancerAcc;
            _userService = userService;
            _rabbitMQConsumer = rabbitMQConsumer;
            _mapper = mapper;
            _vnPayConfig = vnPayConfig.Value;
            _notificationService = notificationService;
            _paymentService = paymentService;
            _logger = logger;

            try
            {
                _commissionRate = _paymentService.GetCommission().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Cannot read commission rate, commission rate will be set to default ({GlobalConstant.Fee.ValueConst.PlatformFee}). Error: {ex.Message}", ex.StackTrace);
                _commissionRate = GlobalConstant.Fee.ValueConst.PlatformFee;
            }
        }

        [HttpGet("test-gateway")]
        public ActionResult TestGw()
        {
            return Ok("Great Job!, your services are running well");
        }

        [HttpPost, AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<PostOrderResultDto>> PostOrder(PostOrderDto postOrder)
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var customer = await _customerAcc.GetByAccId(accountId);

            postOrder.CustomerId = customer.Id;
            var order = await _orderService.Add(postOrder);

            if (order is null)
            {
                return BadRequest(new
                {
                    Message = "Tạo đơn đặt hàng không thành công"
                });
            }

            await _rabbitMQConsumer.SendMessageToFreelancer(postOrder);

            return Ok(new PostOrderResultDto()
            {
                Id = order.Id,
                Message = "Tạo đơn đặt hàng thành công"
            });
        }

        [HttpGet("all")]
        public async Task<ActionResult<Order>> GetAllOrders()
        {
            var order = await _orderService.GetAllOrderTest();

            if (order is null)
            {
                return BadRequest(new
                {
                    Message = "Lấy đơn đặt hàng không thành công"
                });
            }

            // _mapper.Map<IEnumerable<GetOrderDto>>(order)
            return Ok(_mapper.Map<IEnumerable<GetOrderDto>>(order));
        }

        // TODO: Finish refund, do not save records when temporarily charge commission on auctioning freelancers
        [HttpPut("order-price"), AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<Order>> UpdateOrderActualPriceAndFreelancer(PutOrderPriceAndFreelancerDto putOrder)
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var customer = await _customerAcc.GetByAccId(accountId);
            var order = await _orderService.GetById(putOrder.OrderId);
            var freelancer = await _freelancerAcc.GetByAccId(putOrder.FreelancerId);

            if (freelancer == null)
            {
                return BadRequest(new
                {
                    Message = "Freelancer không tồn tại"
                });
            }

            if (order == null)
            {
                return BadRequest(new
                {
                    Message = "Đơn hàng không tồn tại"
                });
            }

            if (order.FreelancerId != null)
            {
                return BadRequest(new
                {
                    Message = "Đơn hàng này đã có Freelancer nhận"
                });
            }

            if (order.CustomerId != customer.Id)
            {
                return BadRequest(new
                {
                    Message = "Bạn không có quyền cập nhật đơn đặt hàng này"
                });
            }

            var biddingFreelancer = await _biddingOrderService.GetSpecificBiddingFreelancerForOrder(putOrder.OrderId, freelancer.Id);
            if (biddingFreelancer == null)
            {
                return BadRequest(new
                {
                    Message = "Freelancer này chưa báo giá cho đơn hàng của bạn, không thể chọn."
                });
            }
            else if (biddingFreelancer.PreviewPrice != putOrder.ActualPrice)
            {
                return BadRequest(new
                {
                    Message = $"Freelancer không báo giá: {putOrder.ActualPrice}đ cho đơn này"
                });
            }

            order.EstimatedPrice = putOrder.ActualPrice;
            order.FreelancerId = freelancer.Id;
            var commisionValue = _commissionRate * putOrder.ActualPrice;

            if (order.ServiceStatusId.Equals(StatusConst.OnMatching))
            {
                order.ServiceStatusId = StatusConst.Waiting;
            }

            await _paymentService.AddFreelancePaymentHistory(new AddFreelancePaymentHistoryDto()
            {
                FreelancerId = freelancer.Id,
                Method = GlobalConstant.Payment.AppFee,
                PaymentType = PaymentType.Subtract,
                Value = commisionValue,
                Wallet = GlobalConstant.Payment.Wallet.Personal,
            });

            var ignoredFreelancer = await _biddingOrderService.GetFreelancersForCustomerBiddingOrder(putOrder.OrderId, freelancer.Id);
            var ignoredAccIds = ignoredFreelancer.Select(igfl => igfl.AccountId).ToList();

            // Refund 'Balance' for the other freelancers and schedule jobs to remove bidding orders
            try
            {
                if (ignoredFreelancer != null && ignoredFreelancer.Any())
                {
                    var newBalanceDict = ignoredFreelancer.ToDictionary(bf => bf.Id, bf => Helper.AesEncryption.Encrypt(bf.Id.ToString(), (bf.Balance + (_commissionRate * bf.PreviewPrice)).ToString()));
                    await _freelancerAcc.RefundAuctionBalance(newBalanceDict);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(new
                {
                    Message = "Hoàn tiền cho freelancers thất bại, vui lòng thử lại"
                });
            }

            if (!await _uow.SaveChangesAsync())
            {
                return BadRequest(new
                {
                    Message = "Đã có lỗi trong quá trình cập nhật giá đơn hàng, vui lòng thử lại sau"
                });
            }

            // Send success to choosen freelancer
            await _notificationService.PushNotificationAsync(new PushNotificationDto()
            {
                ExpoPushTokens = [freelancer.Account.ExpoPushToken],
                Title = "📣 Bạn đã được chọn!",
                Body = "Customer đã chọn bạn! Hãy kiểm tra danh sách đơn nhé.",
                Data = new()
                {
                    ActionKey = GlobalConstant.Notification.CustomerChooseThisFreelancer,
                },
            }, [freelancer.AccountId]);

            // Send failed to not choosen freelancers
            if (ignoredFreelancer != null && ignoredFreelancer.Any())
            {
                // Send fail noti to not choosen freelancers
                await _notificationService.PushNotificationAsync(new PushNotificationDto()
                {
                    ExpoPushTokens = ignoredFreelancer.Select(igfl => igfl.Account.ExpoPushToken).ToList(),
                    Title = "📣 Customer đã chọn người khác.",
                    Body = "Bạn hãy tiếp tục cố gắng nhé.",
                    Data = new()
                    {
                        ActionKey = GlobalConstant.Notification.CustomerNotChooseThisFreelancer,
                    },
                }, ignoredAccIds);
            }
            var getOrderDto = await _orderService.GetOrderDetailById(putOrder.OrderId);
            await _rabbitMQConsumer.SendReceiveOrderMessageToFreelancer(freelancer, getOrderDto);
            return Ok(order);
        }

        //[HttpGet("test-post-order")]
        //public ActionResult TestPostOrder()
        //{
        //    var publishedOrder = new OrderPlacedDto();
        //    publishedOrder.Comment = "Test published";
        //    //Send Async Message
        //    try
        //    {
        //        publishedOrder.Event = "OrderPlaced";
        //        _messageBusClient.PublishNewOrder(publishedOrder);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
        //        return BadRequest();
        //    }
        //    return Ok();
        //}

        //[HttpGet("test-notification-format")]
        //private ActionResult TestNotiFormat()
        //{
        //    var html = HtmlGenerator.GenerateHtmlWithTitleMessageImages("Test voucher notification", "Xin chao ban da chuc mung thanh cong",
        //        "https://th.bing.com/th/id/OIP.FisuRuJ80bgWGBe9z-SW8wHaNK?w=187&h=333&c=7&r=0&o=5&pid=1.7",
        //        "https://th.bing.com/th/id/OIP.FisuRuJ80bgWGBe9z-SW8wHaNK?w=187&h=333&c=7&r=0&o=5&pid=1.7",
        //        "https://th.bing.com/th/id/OIP.FisuRuJ80bgWGBe9z-SW8wHaNK?w=187&h=333&c=7&r=0&o=5&pid=1.7",
        //        "https://th.bing.com/th/id/OIP.FisuRuJ80bgWGBe9z-SW8wHaNK?w=187&h=333&c=7&r=0&o=5&pid=1.7");
        //    var htmlTag2 = HtmlGenerator.GenerateHtmlWithComponents("Test voucher notification big", "Xin chao ban da chuc mung thanh cong big", html);
        //    return Ok(htmlTag2.ToString());
        //}

        [HttpPut("service-status"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult> UpdateOrderStatus(PutOrderStatus putOrderStatus)
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var isValidStatus = StatusConst.SupportedStatuses.Contains(putOrderStatus.StatusId);
            var freelancer = await _uow.FreelanceAccountRepo.GetByAccId(accountId);

            if (!isValidStatus)
            {
                return BadRequest(new
                {
                    Message = "Trạng thái đơn hàng không được hỗ trợ"
                });
            }

            if (freelancer is null)
            {
                return BadRequest(new
                {
                    Message = "Tài khoản freelancer không hợp lệ"
                });
            }

            var order = await _orderService.GetById(putOrderStatus.OrderId);

            if (order is null || order.FreelancerId != freelancer.Id)
            {
                return BadRequest(new
                {
                    Message = "Cập nhật trạng thái đơn hàng thất bại"
                });
            }

            if (putOrderStatus.StatusId == order.ServiceStatusId)
            {
                return BadRequest(new
                {
                    Message = "Đơn hàng đã ở trạng thái này"
                });
            }

            if (StatusConst.SystemStatuses.Contains(putOrderStatus.StatusId))
            {
                return BadRequest(new
                {
                    Message = "Trạng thái đơn hàng không hợp lệ"
                });
            }

            order.ServiceStatusId = putOrderStatus.StatusId;
            await _uow.SaveChangesAsync();

            // Handle real time - freelancers send update status message to customers.
            var customer = await _customerAcc.GetByCondition(cus => cus.Id == order.CustomerId);
            await _rabbitMQConsumer.SendOrderStatusToCustomer(new UpdateOrderStatusRealTimeDto
            {
                CustomerPhone = customer.Account.CombinedPhone,
                Address = _mapper.Map<AddressDto>(freelancer.Address?.FirstOrDefault()),
                ServiceStatusId = putOrderStatus.StatusId
            });

            return Ok(new
            {
                Message = "Cập nhật trạng thái thành công"
            });
        }

        [HttpPut("order-moving-position-status"), AuthorizeRoles(GlobalConstant.Freelancer)]
        private async Task<ActionResult> UpdatePositionMovingStatus(PutOrderMovingStatusDto putOrderMovingStatusDto)
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelancer = await _uow.FreelanceAccountRepo.GetByAccId(accountId);

            if (freelancer is null)
            {
                return BadRequest(new
                {
                    Message = "Tài khoản freelancer không hợp lệ"
                });
            }

            var order = await _orderService.GetById(putOrderMovingStatusDto.OrderId);

            if (order is null || order.FreelancerId != freelancer.Id)
            {
                return BadRequest(new
                {
                    Message = "Cập nhật vị trí thất bại"
                });
            }

            if (order.ServiceStatusId != StatusConst.OnMoving)
            {
                return BadRequest(new
                {
                    Message = "Trạng thái đơn hàng không hợp lệ"
                });
            }

            // Handle real time - freelancers send update status message to customers.
            var customer = await _customerAcc.GetByCondition(cus => cus.Id == order.CustomerId);
            await _rabbitMQConsumer.SendOrderStatusToCustomer(new UpdateOrderStatusRealTimeDto
            {
                CustomerPhone = customer.Account.Phone,
                Address = new AddressDto() { Lat = putOrderMovingStatusDto.Lat, Lon = putOrderMovingStatusDto.Lon },
                ServiceStatusId = StatusConst.OnMoving
            });

            return Ok(new
            {
                Message = "Cập nhật trạng thái thành công"
            });
        }

        [HttpGet("detail")]
        public async Task<ActionResult<GetOrderDto>> GetOrderDetail(Guid id)
        {
            var order = await _orderService.GetOrderDetailById(id);

            if (order is null)
            {
                return BadRequest(new
                {
                    Message = "Lấy đơn đặt hàng không thành công"
                });
            }

            return Ok(order);
        }


        private async Task<ActionResult<IEnumerable<GetCustomerOrderDto>>> GetCustomerOrders(FilterCustomerOrderQuery query)
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var customer = await _customerAcc.GetByAccId(accountId);

            if (customer is null)
            {
                return BadRequest(new
                {
                    Message = "Không thể xem danh sách đơn hàng, hãy đăng nhập để thử lại"
                });
            }

            var order = await _orderService.GetAllCustomerOrders(customer.Id, query);

            return Ok(order);
        }


        [HttpGet("customer-all"), AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<IEnumerable<GetCustomerOrderDto>>> ControllerGetAllCustomerOrders([FromQuery] FilterCustomerOrderQuery query)
        {
            return await GetCustomerOrders(query);
        }

        [HttpGet("customer/on-service"), AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<IEnumerable<GetCustomerOrderDto>>> GetCustomerOnServiceOrders()
        {
            var query = new FilterCustomerOrderQuery()
            {
                OrderStatusId = [StatusConst.Waiting, StatusConst.OnDoingService, StatusConst.OnDelivering, StatusConst.OnMoving],
            };
            return await GetCustomerOrders(query);
        }

        [HttpGet("customer/on-matching"), AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<IEnumerable<GetCustomerOrderDto>>> GetCustomerOnMatchingOrders()
        {
            var query = new FilterCustomerOrderQuery()
            {
                OrderStatusId = [StatusConst.OnMatching, StatusConst.Created],
            };
            return await GetCustomerOrders(query);
        }

        [HttpGet("customer/completed"), AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<IEnumerable<GetCustomerOrderDto>>> GetCustomerCompletedOrders()
        {
            var query = new FilterCustomerOrderQuery()
            {
                OrderStatusId = [StatusConst.Completed],
            };
            return await GetCustomerOrders(query);
        }

        [HttpGet("customer-latest"), AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<GetCustomerOrderDto>> GetCustomerLatestOrders()
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var customer = await _customerAcc.GetByAccId(accountId);

            if (customer is null)
            {
                return BadRequest(new
                {
                    Message = "Không thể xem danh sách đơn hàng, hãy đăng nhập để thử lại"
                });
            }

            var order = await _orderService.GetLatestCustomerOrders(customer.Id);

            return Ok(order);
        }

        /// <summary>
        /// Get a list of orders that a freelancer has auctioned
        /// </summary>
        [HttpGet("freelancer-bidding"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<GetOrderDto>> GetBiddingOrders()
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelancer = await _freelancerAcc.GetByAccId(accountId);

            if (freelancer is null)
            {
                return BadRequest(new
                {
                    Message = "Không thể xem danh sách đơn hàng, hãy đăng nhập để thử lại"
                });
            }

            var result = await _biddingOrderService.GetFreelancerBiddingOrders(freelancer.Id);

            return Ok(result);
        }

        [HttpPost("customer-review"), AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<string>> PostCustomerOrderReview(PostOrderCustomerReviewDto review)
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var customer = await _customerAcc.GetByAccId(accountId);

            if (customer is null)
            {
                return BadRequest(new
                {
                    Message = "Không thể đánh giá đơn hàng, hãy đăng nhập để thử lại."
                });
            }

            var order = await _orderService.PostOrderReview(review, customer.Id);

            if (order.Order == null)
            {
                return BadRequest(new
                {
                    order.Message
                });
            }

            await _uow.SaveChangesAsync();
            return Ok(new
            {
                order.Message
            });
        }

        [HttpPost("freelancer-review"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult<string>> PostFreelancerOrderReview(PostOrderFreelancerReviewDto review)
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelancer = await _freelancerAcc.GetByAccId(accountId);

            if (freelancer is null)
            {
                return BadRequest(new
                {
                    Message = "Không thể đánh giá đơn hàng, hãy đăng nhập để thử lại."
                });
            }

            var order = await _orderService.PostFreelancerReview(review, freelancer.Id);

            if (order.Order == null)
            {
                return BadRequest(new
                {
                    order.Message
                });
            }

            return Ok(new
            {
                order.Message
            });
        }

        [HttpDelete("customer-order"), AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<string>> PostCustomerCancelOrder(Guid orderId)
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var customer = await _customerAcc.GetByAccId(accountId);

            if (customer is null)
            {
                return BadRequest(new
                {
                    Message = "Không thể hủy đơn hàng, hãy đăng nhập để thử lại."
                });
            }

            var order = await _orderService.PostCancelOrderCustomer(orderId, customer.Id);

            if (order.Order == null)
            {
                return BadRequest(new
                {
                    order.Message
                });
            }

            var freelancerId = order.Order.FreelancerId ?? Guid.Empty;

            var updated = await _paymentService
                .UpdateFreelancerBalance(new UpdateFreelanceBalanceDto()
                {
                    Id = freelancerId,
                    Method = GlobalConstant.Payment.BackAppFee,
                    WalletType = GlobalConstant.Payment.Wallet.Personal,
                    Value = order.Order.EstimatedPrice * _commissionRate,
                });

            if (!await _uow.SaveChangesAsync())
            {
                return StatusCode(500, new
                {
                    Message = "Có lỗi xảy ra trong lúc hủy đơn đặt hàng."
                });
            }

            // Send notification to freelancer
            if (!freelancerId.Equals(Guid.Empty))
            {
                var freelancerAcc = (await _freelancerAcc.GetByAccId(freelancerId)).Account;

                await _notificationService.PushNotificationAsync(new PushNotificationDto()
                {
                    ExpoPushTokens = [freelancerAcc.ExpoPushToken],
                    Title = $"📣 Rất tiếc, khách hàng đã hủy 1 đơn hàng!",
                    Body = $"Khách hàng đã hủy 1 đơn hàng! Hãy kiểm tra danh sách đơn bị hủy nhé.",
                    Data = new()
                    {
                        ActionKey = GlobalConstant.Notification.CustomerCanceledOrder,
                    },
                }, [freelancerAcc.Id]);
            }

            return Ok(new
            {
                order.Message
            });
        }

        [HttpPut("freelancer-cancel-order"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult<string>> PostFreelancerCancelOrder(Guid orderId)
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelancer = await _freelancerAcc.GetByAccId(accountId);

            if (freelancer is null)
            {
                return BadRequest(new
                {
                    Message = "Không thể hủy đơn hàng, hãy đăng nhập để thử lại."
                });
            }

            var order = await _orderService.PostCancelOrderFreelancer(orderId, freelancer.Id);

            if (order.Order == null)
            {
                return BadRequest(new
                {
                    order.Message
                });
            }

            if (DateTime.Now.AddMinutes(GlobalConstant.Order.MaximumTimeBeforeStartTimeForFreelancerCancel) < order.Order.StartTime)
            {
                await _paymentService
                .UpdateFreelancerBalance(new UpdateFreelanceBalanceDto()
                {
                    Id = freelancer.Id,
                    Method = GlobalConstant.Payment.BackAppFee,
                    WalletType = GlobalConstant.Payment.Wallet.Personal,
                    Value = order.OldPreviewPrice * _commissionRate,
                });
            } 

            if (!await _uow.SaveChangesAsync())
            {
                return StatusCode(500, new
                {
                    Message = "Có lỗi xảy ra trong lúc hủy đơn đặt hàng."
                });
            }

            // Send notification to customer
            var customerId = order.Order.CustomerId;
            var customerAcc = (await _customerAcc.GetByAccId(customerId)).Account;
            await _notificationService.PushNotificationAsync(new PushNotificationDto()
            {
                ExpoPushTokens = [customerAcc.ExpoPushToken],
                Title = $"📣 Rất tiếc, Freelancer đã từ chối nhận đơn hàng của bạn!",
                Body = $"Freelancer đã từ chối 1 đơn hàng của bạn, đơn hàng của bạn sẽ được đưa lên sàn đấu giá",
                Data = new()
                {
                    ActionKey = GlobalConstant.Notification.FreelancerCanceledOrder,
                },
            }, [customerAcc.Id]);

            return Ok(new
            {
                order.Message
            });
        }
    }
}
