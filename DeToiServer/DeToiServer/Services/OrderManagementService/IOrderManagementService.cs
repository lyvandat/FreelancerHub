using DeToiServer.Dtos.OrderDtos;

namespace DeToiServer.Services.OrderManagementService
{
    public interface IOrderManagementService
    {
        Task<Order?> Add(PostOrderDto service);
        Task<IEnumerable<Order>> GetFreelancerMatchingOrders(Guid freelancerId);
        Task<Order?> GetById(Guid orderId);
        Task<GetOrderDto?> GetOrderDetailById(Guid id);
        Task<IEnumerable<GetOrderDto>> GetAllCustomerOrders(Guid customerid);
    }
}
