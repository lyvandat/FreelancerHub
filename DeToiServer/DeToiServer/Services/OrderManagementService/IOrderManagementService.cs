using DeToiServer.Dtos.OrderDtos;
using DeToiServerCore.QueryModels.OrderQueryModels;

namespace DeToiServer.Services.OrderManagementService
{
    public interface IOrderManagementService
    {
        Task<Order?> Add(PostOrderDto service);
        Task<IEnumerable<GetOrderDto>> GetFreelancerSuitableOrders(Guid freelancerId, FilterFreelancerOrderQuery filterQuery);
        Task<Order?> GetById(Guid orderId);
        Task<GetOrderDto?> GetOrderDetailById(Guid id);
        Task<GetOrderDto?> GetLatestCustomerOrders(Guid customerId);
        Task<IEnumerable<Order>> GetAllOrderTest();
        Task<IEnumerable<GetOrderDto>> GetAllOrder(FilterOrderQuery filterOrderQuery);
        Task<UpdateOrderResultDto> PostOrderReview(PostOrderCustomerReviewDto review, Guid customerId);
        Task<UpdateOrderResultDto> PostCancelOrderCustomer(Guid orderId, Guid customerId);
        Task<IEnumerable<GetOrderDto>> GetFreelancerIncomingOrders(Guid freelancerId);
        Task<IEnumerable<GetCustomerOrderDto>> GetAllCustomerOrders(Guid customerId, FilterCustomerOrderQuery orderQuery);
    }
}
