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
        Task<GetCustomerOrderDto?> GetLatestCustomerOrders(Guid customerId);
        Task<IEnumerable<Order>> GetAllOrderTest();
        Task<IEnumerable<GetOrderDto>> GetAllOrder(FilterOrderQuery filterOrderQuery);
        Task<UpdateOrderResultDto> PostOrderReview(PostOrderCustomerReviewDto review, Guid customerId);
        Task<UpdateOrderResultDto> PostCancelOrderCustomer(Guid orderId, Guid customerId);
        Task<UpdateOrderResultWithOldPreviewPriceDto> PostCancelOrderFreelancer(Guid orderId, Guid freelancerId);
        Task<IEnumerable<GetOrderDto>> GetFreelancerIncomingOrders(FilterFreelancerIncomingOrderQuery query);
        Task<IEnumerable<GetCustomerOrderDto>> GetAllCustomerOrders(Guid customerId, FilterCustomerOrderQuery orderQuery);
        Task<UpdateOrderResultDto> PostFreelancerReview(PostOrderFreelancerReviewDto review, Guid freelancerId);
        Task<Order?> UpdateStatusAndPostPaymentHistory(PostPaymentStatusHistoryDto paymentStatusHistory);
        Task<UpdateOrderResultDto> UpdateFreelancerFaceImage(Guid freelancerId, PutOrderFreelancerImageDto freelancerImage);
        Task<IEnumerable<GetOrderDto>> GetFreelancerCompletedOrders(FilterFreelancerIncomingOrderQuery query);
    }
}
