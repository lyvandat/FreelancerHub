using DeToiServer.Dtos.OrderDtos;

namespace DeToiServer.Services.OrderManagementService
{
    public interface IOrderManagementService
    {
        Task<Order?> Add(PostOrderDto service);
        Task<IEnumerable<Order>> GetFreelancerSuitableOrders(Guid freelancerId);
        Task<Order?> GetById(Guid orderId);
        Task<GetOrderDto?> GetOrderDetailById(Guid id);
        Task<IEnumerable<GetOrderDto>> GetAllCustomerOrders(Guid customerid);
        Task<GetOrderDto> GetLatestCustomerOrders(Guid customerId);
    }
}
