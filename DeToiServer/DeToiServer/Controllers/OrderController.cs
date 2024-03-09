using AutoMapper;
using DeToiServer.Dtos.OrderDtos;
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
        private readonly IMapper _mapper;

        public OrderController(UnitOfWork uow, IOrderManagementService orderService, IMapper mapper)
        {
            _uow = uow;
            _orderService = orderService;
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

        [HttpGet("all")]
        public async Task<ActionResult<Order>> GetAllOrders()
        {
            //Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid customerId);
            //postOrder.CustomerId = customerId;
            var order = await _orderService.GetFreelancerMatchingOrders(Guid.Empty);

            if (order is null)
            {
                return BadRequest(new
                {
                    Message = "Lấy đơn đặt hàng không thành công"
                });
            }

            return Ok(order);
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
    }
}
