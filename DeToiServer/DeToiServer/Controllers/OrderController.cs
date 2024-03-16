using AutoMapper;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.OrderManagementService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/order")]
    public class OrderController : Controller
    {
        private readonly UnitOfWork _uow;
        private readonly IOrderManagementService _orderService;
        private readonly ICustomerAccountService _customerAcc;
        private readonly IMapper _mapper;

        public OrderController(UnitOfWork uow, IOrderManagementService orderService, ICustomerAccountService customerAcc, IMapper mapper)
        {
            _uow = uow;
            _orderService = orderService;
            _customerAcc = customerAcc;
            _mapper = mapper;
        }

        [HttpPost, AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<Order>> PostOrder(PostOrderDto postOrder)
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid customerId);
            postOrder.CustomerId = customerId;
            var order = await _orderService.Add(postOrder);
            
            if (order is null)
            {
                return BadRequest(new
                {
                    Message = "Tạo đơn đặt hàng không thành công"
                });
            }
            return Ok(order);
        }

        //[HttpGet("all")]
        //public async Task<ActionResult<Order>> GetAllOrders()
        //{
        //    //Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid customerId);
        //    //postOrder.CustomerId = customerId;
        //    var order = await _orderService.Ge(Guid.Empty);

        //    if (order is null)
        //    {
        //        return BadRequest(new
        //        {
        //            Message = "Lấy đơn đặt hàng không thành công"
        //        });
        //    }

        //    return Ok(order);
        //}

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
    }
}
