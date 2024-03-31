using DeToiServerCore.Models;
using DeToiServerCore.Models.Accounts;

namespace DeToiServerData.Repositories.OrderRepo
{
    public interface IBiddingOrderRepo : IRepository<BiddingOrder>
    {
        Task<IEnumerable<BiddingOrder>> GetByFreelancerIdWithOrderDetail(Guid freelancerId);
        Task<IEnumerable<BiddingOrder>> GetMatchingFreelancersByOrderId(Guid orderId);
    }
}
