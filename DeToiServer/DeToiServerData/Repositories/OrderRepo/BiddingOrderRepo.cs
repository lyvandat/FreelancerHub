using DeToiServerCore.Models;
using DeToiServerCore.Models.Accounts;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories.OrderRepo
{
    public class BiddingOrderRepo : RepositoryBase<BiddingOrder>, IBiddingOrderRepo
    {
        readonly DataContext _dataContext;

        public BiddingOrderRepo(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<BiddingOrder>> GetByFreelancerIdWithOrderDetail(Guid freelancerId)
        {
            var query = _dataContext.BiddingOrders
                .AsNoTracking().AsSplitQuery()
                .Where(bo => bo.FreelancerId.Equals(freelancerId))
                .Include(bo => bo.Order)
                    .ThenInclude(o => o.OrderServiceTypes)
                        .ThenInclude(ost => ost.ServiceType)
                            .ThenInclude(st => st.ServiceStatusList)
                                .ThenInclude(stl => stl.ServiceStatus)
                .Include(bo => bo.Order)
                    .ThenInclude(o => o.OrderServices)
                        .ThenInclude(ost => ost.Service)
                .Include(bo => bo.Order)
                    .ThenInclude(o => o.ServiceStatus)
                .Include(bo => bo.Order)
                    .ThenInclude(o => o.OrderAddress)
                        .ThenInclude(o => o.Address);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<BiddingOrder>> GetMatchingFreelancersByOrderId(Guid orderId)
        {
            return await _dataContext.BiddingOrders
                .AsNoTracking()
                .Where(bo => bo.OrderId == orderId)
                .Include(bo => bo.Freelancer)
                    .ThenInclude(fl => fl.Account)
                .ToListAsync();
        }
    }
}
