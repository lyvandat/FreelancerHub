using DeToiServer.Dtos.OrderDtos;

namespace DeToiServer.Services.OrderManagementService
{
    public interface IBiddingOrderService
    {
        Task<IEnumerable<GetOrderDto>> GetFreelancerBiddingOrders(Guid freelancerId);
    }
}
