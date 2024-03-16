using DeToiServerCore.Models;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;
using DeToiServerCore.QueryModels.OrderQueryModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DeToiServerData.Repositories.OrderRepo
{
    public class OrderRepo : RepositoryBase<Order>, IOrderRepo
    {
        private readonly DataContext _context;

        public OrderRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            var ordersQuery = _context.Orders.AsSplitQuery();

            var result = await ordersQuery
                .Include(o => o.Address)
                .Include(o => o.ServiceStatus)
                .Include(o => o.OrderServiceTypes)
                .Include(o => o.OrderServices)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Order>> GetOrdersWithFiltersAsync(FilterOrderQuery searchOrder)
        {
            var ordersQuery = _context.Orders.AsSplitQuery();

            var sortExpression = GetSortExpression(searchOrder);

            if (searchOrder.SortType == "desc")
            {
                ordersQuery = ordersQuery.OrderByDescending(sortExpression);
            }
            else
            {
                ordersQuery = ordersQuery.OrderBy(sortExpression);
            }

            return await ordersQuery.ToListAsync();
        }

        private Expression<Func<Order, object>> GetSortExpression(FilterOrderQuery searchOrder)
        => searchOrder.SortingCol?.ToLower() switch
        {
            "rating" => ord => ord.Rating,
            "estimatedprice" => ord => ord.EstimatedPrice,
            _ => ord => ord.Id,
        };

        public async Task<Order> GetOrderDetailByIdAsync(Guid id)
        {
            var orderDetail = _context.Orders
                .AsNoTracking()
                .Where(o => o.Id == id)
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.Address);

            return await orderDetail.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetCustomerOrders(Guid customerId)
        {

            var result = await _context.Orders
                .AsNoTracking()
                .Where(o => o.CustomerId == customerId)
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.Address)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Order>> GetFreelancerSuitableOrders(Guid freelancerId)
        {
            var freelance = await _context.Freelancers
                .AsNoTracking().AsSplitQuery()
                .Include(fl => fl.Address)
                .Include(fl => fl.FreelanceSkills)
                    .ThenInclude(fl_sk => fl_sk.Skill)
                .FirstOrDefaultAsync(fl => fl.Id == freelancerId);

            if (freelance == null) return Enumerable.Empty<Order>();

            var query = _context.Orders
                .AsNoTracking().AsSplitQuery()
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                        .ThenInclude(svt => svt.ServiceCategory)
                .Include(o => o.Address)
                .Where(order => FilterFreelancerSuitableOrders(order, freelance));

            var result = await query.ToListAsync();

            return result;
        }

        private bool FilterFreelancerSuitableOrders(Order order, FreelanceAccount freelancer)
        {
            var suitableSkills = freelancer.FreelanceSkills.Select(fl_sk => fl_sk.Skill.SkillCategory)
            .Distinct().ToList();

            var inCategory = order.OrderServiceTypes
                .All(type => suitableSkills.Contains(type.ServiceType?.ServiceCategory?.ServiceClassName));

            if (!inCategory) return false;

            return order.FreelancerId == null;
        }

        public async Task<Order> GetLatestCustomerOrders(Guid customerId)
        {

            var result = await _context.Orders
                .AsNoTracking()
                .Where(o => o.CustomerId == customerId)
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.Address)
                .FirstOrDefaultAsync(o => o.FreelancerId == null 
                    && !((DateTime.Now - o.CreatedTime) > TimeSpan.FromMinutes(5)));

            return result;
        }
    }
}
