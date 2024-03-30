﻿using AutoMapper;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.RealTimeDtos;
using DeToiServer.RealTime;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.MessageQueueService;
using DeToiServer.Services.OrderManagementService;
using DeToiServer.Services.UserService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using DeToiServerData.Repositories.AccountFreelanceRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
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
        private readonly IFreelanceAccountRepo _freelancerAcc;
        private readonly IUserService _userService;
        private readonly RabbitMQProducer _rabbitMQProducer;
        private readonly IHubContext<ChatHub, IChatClient> _chatHubContext;
        private readonly IMapper _mapper;

        public OrderController(
            UnitOfWork uow, 
            IOrderManagementService orderService, 
            IBiddingOrderService biddingOrderService,
            ICustomerAccountService customerAcc, 
            IFreelanceAccountRepo freelancerAcc,
            IUserService userService,
            RabbitMQProducer rabbitMQProducer,
            IHubContext<ChatHub, IChatClient> chatHubContext,
            IMapper mapper)
        {
            _uow = uow;
            _orderService = orderService;
            _biddingOrderService = biddingOrderService;
            _customerAcc = customerAcc;
            _freelancerAcc = freelancerAcc;
            _userService = userService;
            _rabbitMQProducer = rabbitMQProducer;
            _chatHubContext = chatHubContext;
            _mapper = mapper;
        }

        [HttpPost, AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<PostOrderResultDto>> PostOrder(PostOrderDto postOrder)
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var customer = await _customerAcc.GetByAccId(accountId);

            postOrder.CustomerId = customer.Id;
            var my_str = JsonConvert.SerializeObject(postOrder.Services.Requirement);
            var order = await _orderService.Add(postOrder);
            
            if (order is null)
            {
                return BadRequest(new
                {
                    Message = "Tạo đơn đặt hàng không thành công"
                });
            }

            _rabbitMQProducer.PushMessageToQ(postOrder);

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

            return Ok(_mapper.Map<IEnumerable<GetOrderDto>>(order));
        }

        [HttpPut("order-price"), AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<Order>> UpdateOrderActualPriceAndFreelancer(PutOrderPriceAndFreelancerDto putOrder)
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid customerId);
            var order = await _orderService.GetById(putOrder.OrderId);

            if (order == null)
            {
                return BadRequest(new
                {
                    Message = "Cập nhật đơn đặt hàng không thành công"
                });
            }

            if (order.CustomerId != customerId)
            {
                return BadRequest(new
                {
                    Message = "Bạn không có quyền cập nhật đơn đặt hàng này"
                });
            }

            order.EstimatedPrice = putOrder.ActualPrice;
            order.FreelancerId = putOrder.FreelancerId;

            var saveResult = await _uow.SaveChangesAsync();

            if (!saveResult)
            {
                return BadRequest(new
                {
                    Message = "Cập nhật đơn đặt hàng không thành công"
                });
            }

            return Ok(order);
        }

        [HttpPut("order-moving-status"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult> UpdateOrderMovingStatus(PutOrderStatus putOrderStatus)
        {
            return await UpdateOrderStatus(putOrderStatus, StatusConst.OnMoving);
        }

        [HttpPut("order-doing-status"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult> UpdateOrderDoingStatus(PutOrderStatus putOrderStatus)
        {
            return await UpdateOrderStatus(putOrderStatus, StatusConst.OnDoingService);
        }

        [HttpPut("order-finished-status"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult> UpdateOrderFinishedStatus(PutOrderStatus putOrderStatus)
        {
            return await UpdateOrderStatus(putOrderStatus, StatusConst.Completed);
        }

        private async Task<ActionResult> UpdateOrderStatus(PutOrderStatus putOrderStatus, Guid orderStatus)
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

            var order = await _orderService.GetById(putOrderStatus.OrderId);

            if (order is null || order.FreelancerId != freelancer.Id)
            {
                return BadRequest(new
                {
                    Message = "Cập nhật trạng thái đơn hàng thất bại"
                });
            }

            order.ServiceStatusId = orderStatus;
            await _uow.SaveChangesAsync();

            // Handle real time - freelancers send update status message to customers.
            var customer = await _customerAcc.GetByCondition(cus => cus.Id == order.CustomerId);
            _rabbitMQProducer.PushOrderStatusToQ(new UpdateOrderStatusRealTimeDto
            {
                CustomerPhone = customer.Account.Phone,
                Address = _mapper.Map<AddressDto>(freelancer.Address?.FirstOrDefault()),
                ServiceStatusId = orderStatus
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

            // Handle real time - freelancers send update status message to customers.
            var customer = await _customerAcc.GetByCondition(cus => cus.Id == order.CustomerId);
            _rabbitMQProducer.PushOrderStatusToQ(new UpdateOrderStatusRealTimeDto
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

        [HttpGet("customer-all"), AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<GetOrderDto>> GetCustomerOrders()
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

            var order = await _orderService.GetAllCustomerOrders(customer.Id);

            return Ok(order);
        }

        [HttpGet("customer-latest"), AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<GetOrderDto>> GetCustomerLatestOrders()
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

        [HttpGet("freelancer-bidding"), AuthorizeRoles(GlobalConstant.Freelancer)]
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

            return Ok(await _biddingOrderService.GetFreelancerBiddingOrders(freelancer.Id));
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

            await _uow.SaveChangesAsync();
            return Ok(new
            {
                order.Message
            });
        }
    }
}
