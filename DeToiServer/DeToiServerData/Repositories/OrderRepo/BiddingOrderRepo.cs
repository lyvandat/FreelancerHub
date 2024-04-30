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
            var query = _dataContext.BiddingOrders
                .AsNoTracking().AsSplitQuery()
                .Where(bo => bo.OrderId == orderId)
                .Include(bo => bo.Freelancer)
                    .ThenInclude(fl => fl.Account)
                .Include(bo => bo.Freelancer)
                    .ThenInclude(fl => fl.Address)
                .Include(bo => bo.Freelancer)
                    .ThenInclude(fl => fl.FreelancerFeasibleServices)
                        .ThenInclude(ffs => ffs.ServiceType)
                .Include(bo => bo.Freelancer)
                    .ThenInclude(fl => fl.ServiceProven)
                        .ThenInclude(sp => sp.ServiceType)
                .Include(bo => bo.Freelancer)
                    .ThenInclude(fl => fl.ServiceProven)
                        .ThenInclude(sp => sp.Order);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<BiddingOrder>> GetAllBiddingInfoByOrderId(Guid orderId)
        {
            return await _dataContext.BiddingOrders
                .AsNoTracking().AsSplitQuery()
                .Where(bo => bo.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<BiddingOrder> GetSpecificBiddingFreelancerForOrder(Guid orderId, Guid freelancerId)
        {
            return await _dataContext.BiddingOrders
                .AsNoTracking().AsSplitQuery()
                .Where(bo => bo.OrderId == orderId && bo.FreelancerId == freelancerId)
                .FirstOrDefaultAsync();
        }
    }
}
