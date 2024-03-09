using DeToiServer.Dtos.OrderDtos;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Services.OrderManagementService
{
    public interface IOrderManagementService
    {
        Task<Order?> Add(PostOrderDto service);
    }
}
