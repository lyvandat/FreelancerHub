using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;
using DeToiServerCore.QueryModels.OrderQueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DeToiServerData.Repositories.OrderRepo
{
    public class OrderRepo : RepositoryBase<Order>, IOrderRepo
    {
        private readonly DataContext _context;

        public OrderRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<double> CalcAvgOrderPriceByServiceType(Guid serviceTypeId)
        {
            var query = await _context.OrderServiceTypes.AsNoTracking().AsSplitQuery()
                .Include(ost => ost.Order)
                .Where(ost => ost.ServiceTypeId.Equals(serviceTypeId) 
                    && ost.Order.ServiceStatusId.Equals(StatusConst.Completed))
                .Select(ost => ost.Order.EstimatedPrice)
                .ToListAsync();
            
            return query.IsNullOrEmpty() ? GlobalConstant.Order.DefaultRecommendPrice : query.Average();
        }

        public async Task<IEnumerable<Order>> GetAllOrderWithDetailAsync()
        {
            var ordersQuery = _context.Orders.AsSplitQuery().AsNoTracking();

            var result = await ordersQuery
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.Address)
                .ToListAsync();

            foreach (var order in ordersQuery)
            {
                order.RecommendPrice = order.OrderServiceTypes
                    .Select(async ost => await CalcAvgOrderPriceByServiceType(ost.ServiceTypeId))
                    .ToList().Sum(price => price.Result);
            }

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
                .AsNoTracking().AsSplitQuery()
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.Address)
                .Where(o => o.Id == id); // && !o.ServiceStatusId.Equals(StatusConst.Canceled)

            var result = await orderDetail.FirstOrDefaultAsync();
            var avgPrice = result.OrderServiceTypes
                .Select(async ost => await CalcAvgOrderPriceByServiceType(ost.ServiceTypeId))
                .ToList().Sum(price => price.Result);
            result.RecommendPrice = avgPrice;

            return result;
        }

        public async Task<IEnumerable<Order>> GetCustomerOrders(Guid customerId)
        {
            var statusList = new List<Guid>() {
                StatusConst.Canceled,
                StatusConst.Completed
            };

            var result = await _context.Orders
                .AsNoTracking().AsSplitQuery()
                .Where(o => o.CustomerId == customerId) // && !o.ServiceStatusId.Equals(StatusConst.Canceled)
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.Address)
                .ToListAsync();

            foreach (var order in result)
            {
                if (!statusList.Contains(order.ServiceStatusId))
                    order.RecommendPrice = order.OrderServiceTypes
                        .Select(async ost => await CalcAvgOrderPriceByServiceType(ost.ServiceTypeId))
                        .ToList().Sum(price => price.Result);
            }

            return result;
        }

        private Expression<Func<Order, object>> GetFreelancerOrderSortExpression(FilterFreelancerOrderQuery filterQuery)
        => filterQuery.SortingCol?.ToLower() switch
        {
            "date" => ord => ord.CreatedTime,
            "distance" => ord => ord.CreatedTime,
            _ => ord => ord.CreatedTime,
        };

        public async Task<IEnumerable<Order>> GetFreelancerSuitableOrders(Guid freelancerId, FilterFreelancerOrderQuery filterQuery)
        {
            var freelance = await _context.Freelancers
                .AsNoTracking().AsSplitQuery()
                .Include(fl => fl.Address)
                .Include(fl => fl.FreelanceSkills)
                    .ThenInclude(fl_sk => fl_sk.Skill)
                .FirstOrDefaultAsync(fl => fl.Id == freelancerId);

            if (freelance == null) return Enumerable.Empty<Order>();

            // Materialize the suitable skill categories
            var suitableSkillCategories = freelance.FreelanceSkills
                .Select(fl_sk => fl_sk.Skill.SkillCategory)
                .Distinct()
                .ToList();

            var query = _context.Orders
                .AsNoTracking().AsSplitQuery()
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                        .ThenInclude(svt => svt.ServiceCategory)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.Address)
                .Where(order =>
                    !order.ServiceStatusId.Equals(StatusConst.Canceled)
                    && order.OrderServiceTypes.All(type => suitableSkillCategories
                        .Contains(type.ServiceType.ServiceCategory.ServiceClassName))
                    && order.FreelancerId == null);

            var sortExpression = GetFreelancerOrderSortExpression(filterQuery);

            if (filterQuery.SortType.ToLower().Equals("asc"))
            {
                query = query.OrderBy(sortExpression);
            }
            else
            {
                query = query.OrderByDescending(sortExpression);
            }

            var result = await query.ToListAsync();
            foreach (var order in result)
            {
                order.RecommendPrice = order.OrderServiceTypes
                    .Select(async ost => await CalcAvgOrderPriceByServiceType(ost.ServiceTypeId))
                    .ToList().Sum(price => price.Result);
            }

            return result;
        }

        public async Task<Order> GetLatestCustomerOrders(Guid customerId)
        {
            //&& !((DateTime.Now - o.CreatedTime) > TimeSpan.FromMinutes(5))
            var result = await _context.Orders
                .AsNoTracking().AsSplitQuery()
                .Where(o => o.CustomerId == customerId
                    && !o.ServiceStatusId.Equals(StatusConst.Canceled)
                    && o.FreelancerId == null)
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.Address)
                .OrderByDescending(o => o.CreatedTime)
                .FirstOrDefaultAsync();

            result.RecommendPrice = result.OrderServiceTypes
                .Select(async ost => await CalcAvgOrderPriceByServiceType(ost.ServiceTypeId))
                .ToList().Sum(price => price.Result);

            return result;
        }

        public async Task<IEnumerable<Order>> GetFreelancerIncomingOrdersAsync(Guid freelancerId)
        {
            var statusList = new List<Guid>()
            {
                StatusConst.Waiting,
                StatusConst.OnMoving,
                StatusConst.OnDoingService,
            };

            var result = await _context.Orders
                .AsNoTracking().AsSplitQuery()
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                        .ThenInclude(svt => svt.ServiceCategory)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.Address)
                .Where(order =>
                    statusList.Contains(order.ServiceStatusId)
                    && order.FreelancerId.Equals(freelancerId))
                .OrderByDescending(o => o.CreatedTime)
                .ToListAsync();
            
            foreach (var order in result)
            {
                order.RecommendPrice = order.OrderServiceTypes
                    .Select(async ost => await CalcAvgOrderPriceByServiceType(ost.ServiceTypeId))
                    .ToList().Sum(price => price.Result);
            }

            return result;
        }
    }
}
