using DeToiServerCore.Models;

namespace DeToiServerData.Repositories.OrderRepo
{
    public interface IBiddingOrderRepo : IRepository<BiddingOrder>
    {
        Task<IEnumerable<BiddingOrder>> GetByFreelancerIdWithOrderDetail(Guid id);
    }
}
