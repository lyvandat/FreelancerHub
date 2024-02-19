using DeToiServer.Dtos.AuthDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Services.OrderService;
using DeToiServerCore.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/order")]
    public class OrderController : Controller
    {
        private readonly UnitOfWork _uow;
        private readonly IOrderService _orderService;

        public OrderController(UnitOfWork uow, IOrderService orderService)
        {
            _uow = uow;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder(PostOrderDto order)
        {
            var serviceType = await _orderService.Add(order);
            await _uow.SaveChangesAsync();
            return Ok();
        }
    }
}
