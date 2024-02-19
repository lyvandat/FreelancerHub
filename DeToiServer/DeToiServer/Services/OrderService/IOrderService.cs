using DeToiServer.Dtos.OrderDtos;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Services.OrderService
{
    public interface IOrderService
    {
        Task<Order> Add(PostOrderDto service);
    }
}
