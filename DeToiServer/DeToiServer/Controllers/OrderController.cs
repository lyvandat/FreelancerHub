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
    }
}
