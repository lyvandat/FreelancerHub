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
using static DeToiServerCore.Common.Constants.GlobalConstant;
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

            return query.IsNullOrEmpty() ? GlobalConstant.OrderConst.DefaultRecommendPrice : query.Average();
        }

        public List<Order> FilterOrders(List<Order> orders, FilterOrderQuery filterOrderQuery)
        {
            if (!string.IsNullOrEmpty(filterOrderQuery.Ward))
            {
                orders = orders.Where(o => o.OrderAddress.Any(addrs => addrs.Address.Ward.Contains(filterOrderQuery.Ward))).ToList();
            }

            if (!string.IsNullOrEmpty(filterOrderQuery.District))
            {
                orders = orders.Where(o => o.OrderAddress.Any(addrs => addrs.Address.District.Contains(filterOrderQuery.District))).ToList();
            }

            if (!string.IsNullOrEmpty(filterOrderQuery.Province))
            {
                orders = orders.Where(o => o.OrderAddress.Any(addrs => addrs.Address.Province.Contains(filterOrderQuery.Province))).ToList();
            }

            if (!string.IsNullOrEmpty(filterOrderQuery.Country))
            {
                orders = orders.Where(o => o.OrderAddress.Any(addrs => addrs.Address.Province.Contains(filterOrderQuery.Province))).ToList();
            }

            if (!string.IsNullOrEmpty(filterOrderQuery.Status))
            {
                orders = orders.Where(o => o.ServiceStatus.Name.Contains(filterOrderQuery.Status)).ToList();
            }

            var sortExpression = GetSortExpression(filterOrderQuery);

            if (filterOrderQuery.SortType == "desc")
            {
                orders = orders.AsQueryable().OrderByDescending(sortExpression).ToList();
            }
            else
            {
                orders = orders.AsQueryable().OrderBy(sortExpression).ToList();
            }

            return orders;
        }

        public async Task<IEnumerable<Order>> GetAllOrderWithDetailAsync()
        {
            var ordersQuery = _context.Orders.AsSplitQuery().AsNoTracking();

            var result = await ordersQuery
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                        .ThenInclude(svt => svt.ServiceStatusList)
                            .ThenInclude(sts => sts.ServiceStatus)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.SkillRequired)
                    .ThenInclude(skr => skr.Skill)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.OrderAddress)
                    .ThenInclude(oad => oad.Address)
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
                        .ThenInclude(svt => svt.ServiceStatusList)
                            .ThenInclude(sts => sts.ServiceStatus)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.SkillRequired)
                    .ThenInclude(skr => skr.Skill)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.OrderAddress)
                    .ThenInclude(oad => oad.Address)
                .ToListAsync();

            result = FilterOrders(result.ToList(), filterOrderQuery);

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
                        .ThenInclude(svt => svt.ServiceStatusList)
                            .ThenInclude(sts => sts.ServiceStatus)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.SkillRequired)
                    .ThenInclude(skr => skr.Skill)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.OrderAddress)
                    .ThenInclude(oad => oad.Address);

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
                        .ThenInclude(svt => svt.ServiceStatusList)
                            .ThenInclude(sts => sts.ServiceStatus)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.SkillRequired)
                    .ThenInclude(skr => skr.Skill)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.OrderAddress)
                    .ThenInclude(oad => oad.Address)
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

        public async Task<OrderFeasibleFreelancersQuery> GetSuitableFreelancerForOrderById(Guid orderId)
        {
            var orderDetail = await _context.Orders
                .AsNoTracking().AsSplitQuery()
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                        .ThenInclude(svt => svt.ServiceStatusList)
                            .ThenInclude(sts => sts.ServiceStatus)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.SkillRequired)
                    .ThenInclude(skrq => skrq.Skill)
                .Include(o => o.OrderAddress)
                    .ThenInclude(oad => oad.Address)
                .FirstOrDefaultAsync(o => o.Id.Equals(orderId));

            if (orderDetail == null)
            {
                return new() {};
            }

            orderDetail.RecommendPrice = orderDetail.OrderServiceTypes
                    .Select(async ost => await CalcAvgOrderPriceByServiceType(ost.ServiceTypeId))
                    .ToList().Sum(price => price.Result);

            var serviceTypeIds = orderDetail.OrderServiceTypes.Select(ost => ost.ServiceTypeId).ToList();
            var skillIds = orderDetail.SkillRequired.Select(ost => ost.SkillId).ToList();

            var realQuery = _context.FreelanceServiceTypes
                .AsNoTracking().AsSplitQuery()
                .Where(fst => serviceTypeIds.Contains(fst.ServiceTypeId))
                .Include(fst => fst.Freelancer)
                    .ThenInclude(fl => fl.Account)
                .Select(fst => fst.Freelancer.Account.CombinedPhone)
                .Distinct();

            var realSkillQuery = _context.SkillServiceTypes
                .AsNoTracking().AsSplitQuery()
                .Where(sst => serviceTypeIds.Contains(sst.ServiceTypeId)
                    || skillIds.Contains(sst.SkillId))
                .Include(sst => sst.Skill)
                    .ThenInclude(sk => sk.FreelanceSkills)
                        .ThenInclude(fls => fls.Freelancer)
                            .ThenInclude(fl => fl.Account)
                .SelectMany(sst => sst.Skill.FreelanceSkills.Select(fl_sk => fl_sk.Freelancer.Account.CombinedPhone))
                .Distinct();

            return new()
            {
                FreelancerPhones = (await realQuery.ToListAsync())
                    .Concat(await realSkillQuery.ToListAsync()),
                OrderDetail = orderDetail
            };
        }

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

            var validStatuses = new List<Guid>()
            {
                StatusConst.Created, StatusConst.OnMatching
            };

            var query = _context.Orders
                .AsNoTracking().AsSplitQuery()
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                        .ThenInclude(svt => svt.ServiceStatusList)
                            .ThenInclude(sts => sts.ServiceStatus)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.SkillRequired)
                    .ThenInclude(skrq => skrq.Skill)
                .Include(o => o.OrderAddress)
                    .ThenInclude(oad => oad.Address)
                .Where(order =>
                    validStatuses.Contains(order.ServiceStatusId)
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
                        .ThenInclude(svt => svt.ServiceStatusList)
                            .ThenInclude(sts => sts.ServiceStatus)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.SkillRequired)
                    .ThenInclude(skr => skr.Skill)
                .Include(o => o.Freelance)
                    .ThenInclude(f => f.Account)
                .Include(o => o.ServiceStatus)
                .Include(o => o.OrderAddress)
                    .ThenInclude(oad => oad.Address)
                .OrderByDescending(o => o.CreatedTime)
                .FirstOrDefaultAsync();

            if (result != null)
            {
                result.RecommendPrice = result.OrderServiceTypes
                    .Select(async ost => await CalcAvgOrderPriceByServiceType(ost.ServiceTypeId))
                    .ToList().Sum(price => price.Result);
            }

            return result;
        }

        public async Task<IEnumerable<Order>> GetFreelancerIncomingOrdersAsync(Guid freelancerId)
        {
            var statusList = new List<Guid>()
            {
                StatusConst.Waiting,
                StatusConst.OnMoving,
                StatusConst.OnDoingService,
                StatusConst.OnDelivering,
            };

            var result = await _context.Orders
                .AsNoTracking().AsSplitQuery()
                .Include(o => o.OrderServiceTypes)
                    .ThenInclude(ost => ost.ServiceType)
                        .ThenInclude(svt => svt.ServiceStatusList)
                            .ThenInclude(sts => sts.ServiceStatus)
                .Include(o => o.OrderServices)
                    .ThenInclude(ost => ost.Service)
                .Include(o => o.SkillRequired)
                    .ThenInclude(skr => skr.Skill)
                .Include(o => o.OrderAddress)
                    .ThenInclude(oad => oad.Address)
                .Where(order =>
                    statusList.Contains(order.ServiceStatusId)
                    && order.FreelancerId.Equals(freelancerId)) 
                .OrderByDescending(o => o.CreatedTime)
                .ToListAsync();

            // && order.StartTime > DateTime.Now.AddDays(-2): revert filtering order by start day.
            // withn 2 days after the start day

            foreach (var order in result)
            {
                order.RecommendPrice = order.OrderServiceTypes
                    .Select(async ost => await CalcAvgOrderPriceByServiceType(ost.ServiceTypeId))
                    .ToList().Sum(price => price.Result);
            }

            return result;
        }

        public async Task<Order> GetOrderDetailWithFreelancerAsync(Guid orderId)
        {
            var query = _context.Orders.AsSplitQuery()
                .Where(o => o.Id.Equals(orderId))
                .Include(o => o.Freelance)
                    .ThenInclude(fl => fl.Account);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> QueryOrdersByMonthAsync(int month, int year)
        {
            var result = await _context.Orders
                .AsNoTracking().AsSplitQuery()
                .Where(o => o.CreatedTime.Month.Equals(month)
                    && o.CreatedTime.Year.Equals(year)
                ).ToListAsync();

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
            var countX = x.OrderAddress.Count;
            var countY = y.OrderAddress.Count;

            var coorX = new Coordination()
            {
                Lat = x.OrderAddress.First().Address.Lat,
                Lon = x.OrderAddress.First().Address.Lon
            };
            var coorY = new Coordination()
            {
                Lat = y.OrderAddress.First().Address.Lat,
                Lon = y.OrderAddress.First().Address.Lon
            };

            if (countX != countY)
            {
                return countX - countY;
            } 
            else if (countX == 1)
            {
                double distance1_1 = Helper.GeoCalculator.CalculateDistance(coorX, _coord);
                double distance2_1 = Helper.GeoCalculator.CalculateDistance(coorY, _coord);
                return (int)(distance1_1 - distance2_1);
            }

            coorX = new Coordination()
            {
                Lat = x.OrderAddress.ElementAt((int)GlobalConstant.AddressOption.ShippingEnum.From).Address.Lat,
                Lon = x.OrderAddress.ElementAt((int)GlobalConstant.AddressOption.ShippingEnum.From).Address.Lon
            };
            coorY = new Coordination()
            {
                Lat = y.OrderAddress.ElementAt((int)GlobalConstant.AddressOption.ShippingEnum.From).Address.Lat,
                Lon = y.OrderAddress.ElementAt((int)GlobalConstant.AddressOption.ShippingEnum.From).Address.Lon
            };

            double distance1 = Helper.GeoCalculator.CalculateDistance(coorX, _coord);
            double distance2 = Helper.GeoCalculator.CalculateDistance(coorY, _coord);
            return (int)(distance1 - distance2);
        }
    }
}
