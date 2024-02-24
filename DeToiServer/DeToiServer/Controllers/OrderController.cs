using AutoMapper;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Services.OrderManagementService;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Lưu ý để id mặc định cho service status trong order model
        /// </summary>
        /// <param name="postOrder"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(PostOrderDto postOrder)
        {
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
    }
}
