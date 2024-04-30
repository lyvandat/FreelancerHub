using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.OrderDtos;

namespace DeToiServer.Services.OrderManagementService
{
    public interface IBiddingOrderService
    {
        Task<IEnumerable<GetOrderDto>> GetFreelancerBiddingOrders(Guid freelancerId);
        Task<IEnumerable<GetFreelanceMatchingDto>> GetFreelancersForCustomerBiddingOrder(Guid orderId);
        Task<IEnumerable<BiddingOrder>> GetAllBiddingInfoByOrderId(Guid orderId);
        Task<BiddingOrder?> GetSpecificBiddingFreelancerForOrder(Guid orderId, Guid freelancerId);
    }
}
