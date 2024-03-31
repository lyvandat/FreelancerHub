﻿using DeToiServerCore.Models;
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
            return await _dataContext.BiddingOrders
                .AsNoTracking()
                .Where(bo => bo.FreelancerId == freelancerId)
                .Include(bo => bo.Order)
                    .ThenInclude(o => o.OrderServiceTypes)
                        .ThenInclude(ost => ost.ServiceType)
                .Include(bo => bo.Order)
                    .ThenInclude(o => o.OrderServices)
                        .ThenInclude(ost => ost.Service)
                .Include(bo => bo.Order)
                    .ThenInclude(o => o.ServiceStatus)
                .Include(bo => bo.Order)
                    .ThenInclude(o => o.Address)
                .ToListAsync();
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
