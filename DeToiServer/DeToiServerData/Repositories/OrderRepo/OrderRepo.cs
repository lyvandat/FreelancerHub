using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;
using DeToiServerCore.QueryModels.OrderQueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                .Include(o => o.SkillRequired)
                    .ThenInclude(skr => skr.Skill)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.Address)
                .ToListAsync();

            foreach (var order in result)
            {
                order.RecommendPrice = order.OrderServiceTypes
                    .Select(async ost => await CalcAvgOrderPriceByServiceType(ost.ServiceTypeId))
                    .ToList().Sum(price => price.Result);
            }

            return result;
        }

        public async Task<IEnumerable<Order>> GetOrderWithDetailAsync(FilterOrderQuery filterOrderQuery)
        {
            var ordersQuery = _context.Orders.AsSplitQuery().AsNoTracking();


            var result = await ordersQuery
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.SkillRequired)
                    .ThenInclude(skr => skr.Skill)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.Address)
                .ToListAsync();

            if (!string.IsNullOrEmpty(filterOrderQuery.Ward))
            {
                result = result.Where(o => o.Address.Ward.Contains(filterOrderQuery.Ward)).ToList();
            }

            if (!string.IsNullOrEmpty(filterOrderQuery.District))
            {
                result = result.Where(o => o.Address.District.Contains(filterOrderQuery.District)).ToList();
            }

            if (!string.IsNullOrEmpty(filterOrderQuery.Province))
            {
                result = result.Where(o => o.Address.Province.Contains(filterOrderQuery.Province)).ToList();
            }

            if (!string.IsNullOrEmpty(filterOrderQuery.Country))
            {
                result = result.Where(o => o.Address.Country.Contains(filterOrderQuery.Country)).ToList();
            }

            var sortExpression = GetSortExpression(filterOrderQuery);

            if (filterOrderQuery.SortType == "desc")
            {
                result = result.AsQueryable().OrderByDescending(sortExpression).ToList();
            }
            else
            {
                result = result.AsQueryable().OrderBy(sortExpression).ToList();
            }

            foreach (var order in result)
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
                .Where(o => o.Id == id) // && !o.ServiceStatusId.Equals(StatusConst.Canceled)
                .AsNoTracking().AsSplitQuery()
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.SkillRequired)
                    .ThenInclude(skr => skr.Skill)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.Address);

            var result = await orderDetail.FirstOrDefaultAsync();
            result.RecommendPrice = result.OrderServiceTypes
                .Select(async ost => await CalcAvgOrderPriceByServiceType(ost.ServiceTypeId))
                .ToList().Sum(price => price.Result);

            return result;
        }

        private Expression<Func<Order, object>> GetCustomerOrderSortExpression(FilterCustomerOrderQuery filterQuery)
        => filterQuery.SortingCol?.ToLower() switch
        {
            "date" => ord => ord.StartTime,
            "created_at" => ord => ord.CreatedTime,
            _ => ord => ord.CreatedTime,
        };

        public async Task<IEnumerable<Order>> GetCustomerOrders(Guid customerId, FilterCustomerOrderQuery filterQuery)
        {
            var statusList = new List<Guid>() {
                StatusConst.Canceled,
                StatusConst.Completed
            };

            var query = _context.Orders
                .AsNoTracking().AsSplitQuery()
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.SkillRequired)
                    .ThenInclude(skr => skr.Skill)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.Address)
                .Where(o => o.CustomerId == customerId); // && !o.ServiceStatusId.Equals(StatusConst.Canceled)

            if (filterQuery.OrderStatusId != null)
            {
                query = query.Where(o => filterQuery.OrderStatusId.Contains(o.ServiceStatusId));
            }

            var sortExpression = GetCustomerOrderSortExpression(filterQuery);

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
            "date" => ord => ord.StartTime,
            "distance" => ord => ord.CreatedTime,
            "created_at" => ord => ord.CreatedTime,
            _ => ord => ord.CreatedTime,
        };

        public async Task<IEnumerable<Order>> GetFreelancerSuitableOrders(Guid freelancerId, FilterFreelancerOrderQuery filterQuery)
        {
            var freelance = await _context.Freelancers
                .AsNoTracking().AsSplitQuery()
                .Include(fl => fl.Address)
                .Include(fl => fl.FreelanceSkills)
                    .ThenInclude(fl_sk => fl_sk.Skill)
                        .ThenInclude(sk => sk.ServiceTypeOfSkill)
                            .ThenInclude(st_sk => st_sk.ServiceType)
                .Include(fl => fl.FreelancerFeasibleServices)
                    .ThenInclude(f_sv => f_sv.ServiceType)
                .FirstOrDefaultAsync(fl => fl.Id == freelancerId);

            if (freelance == null) return [];

            // Materialize the suitable service types
            var suitableServiceTypes = freelance.FreelanceSkills
                .SelectMany(fl_sk => fl_sk.Skill.ServiceTypeOfSkill.Select(sk_st => sk_st.ServiceType.Id).ToList())
                .Concat(freelance.FreelancerFeasibleServices.Select(f_sv => f_sv.ServiceType.Id))
                .Distinct()
                .ToList();

            var suitableSkills = freelance.FreelanceSkills
                .Select(fl => fl.Skill.Id)
                .ToList();

            var query = _context.Orders
                .AsNoTracking().AsSplitQuery()
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                        .ThenInclude(svt => svt.ServiceCategory)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.SkillRequired)
                    .ThenInclude(skrq => skrq.Skill)
                .Include(o => o.Address)
                .Where(order =>
                    !order.ServiceStatusId.Equals(StatusConst.Canceled)
                    && (order.SkillRequired.Any(skill => suitableSkills.Contains(skill.SkillId))
                    || order.OrderServiceTypes.Any(type => suitableServiceTypes.Contains(type.ServiceTypeId)))
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

            if (!(freelance.Address == null || freelance.Address.Count == 0))
                if (filterQuery.SortingCol.ToLower().Equals("distance"))
                {
                    if (filterQuery.SortType.ToLower().Equals("asc"))
                        result = result.OrderBy(order => order, new DistanceComparer(freelance.Address.First())).ToList();
                    else
                        result = result.OrderByDescending(order => order, new DistanceComparer(freelance.Address.First())).ToList();
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
                .Include(o => o.SkillRequired)
                    .ThenInclude(skr => skr.Skill)
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
                .Include(o => o.SkillRequired)
                    .ThenInclude(skr => skr.Skill)
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

    public class DistanceComparer(Address freelancerAddress) : IComparer<Order>
    {
        private readonly Coordination _coord = new()
        {
            Lat = freelancerAddress.Lat,
            Lon = freelancerAddress.Lon,
        };

        public int Compare(Order x, Order y)
        {
            double distance1 = Helper.GeoCalculator.CalculateDistance(new Coordination() { Lat = x.Address.Lat, Lon = x.Address.Lon }, _coord);
            double distance2 = Helper.GeoCalculator.CalculateDistance(new Coordination() { Lat = y.Address.Lat, Lon = y.Address.Lon }, _coord);

            // Compare A objects based on the length of additional data from B
            return (int)(distance1 - distance2);
        }
    }
}
