using AutoMapper;
using DeToiServer.Dtos.AdminDto;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models.Accounts;
using System;
using System.Linq.Expressions;

namespace DeToiServer.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AdminService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private ComparedToLastMonthOverviewDto ComparedToLastMonthOverview(MonthlyOverviewAdminDto curMonth, MonthlyOverviewAdminDto lastMonth)
        {
            return new()
            {
                ProfitDifferent = Helper.CalcRevenueGrowth(lastMonth.TotalProfit, curMonth.TotalProfit),
                DiscountCostDifferent = Helper.CalcRevenueGrowth(lastMonth.TotalDiscountCost, curMonth.TotalDiscountCost),
                RevenueDifferent = Helper.CalcRevenueGrowth(lastMonth.TotalRevenue, curMonth.TotalRevenue),
                SuccessOrderCountDifferent = Helper.CalcRevenueGrowth(lastMonth.SuccessOrderCount, curMonth.SuccessOrderCount),
                FailedOrderCountDifferent = Helper.CalcRevenueGrowth(lastMonth.FailedOrderCount, curMonth.FailedOrderCount),
            };
        }

        private async Task<MonthlyOverviewAdminDto> GetOverviewDataAdminByMonth(int month, int year)
        {
            var allOrders = await _unitOfWork.OrderRepo.QueryOrdersByMonthAsync(month, year);
            double totalRevenue = allOrders
                .Where(o => o.ServiceStatusId.Equals(StatusConst.Completed))
                .Sum(o => o.EstimatedPrice);
            int successCount = allOrders.Where(o => o.ServiceStatusId.Equals(StatusConst.Completed)).Count();
            int failedCount = allOrders.Where(o => o.ServiceStatusId.Equals(StatusConst.Canceled)).Count();

            return new()
            {
                TotalRevenue = totalRevenue,
                TotalProfit = totalRevenue * (0.05),
                TotalDiscountCost = 1,
                SuccessOrderCount = successCount,
                FailedOrderCount = failedCount
            };
        }

        public async Task<GetOverviewDataAdminDto> GetAllOverviewDataAdmin(int? month = null, int? year = null)
        {
            GetOverviewDataAdminDto result = new();

            var curDate = DateTime.Now.Date;
            var checkMonth = month ?? curDate.Month;
            var checkYear = year ?? curDate.Year;
            DateTime thisDate = new DateTime(checkYear, checkMonth, 1).AddDays(-1);
            var monthlyOverview = await GetOverviewDataAdminByMonth(checkMonth, checkYear);
            var lastOverview = await GetOverviewDataAdminByMonth(thisDate.Month, thisDate.Year);

            result.Overview = monthlyOverview;
            result.OverviewLastMonth = ComparedToLastMonthOverview(monthlyOverview, lastOverview);

            var allAccount = await _unitOfWork.AccountRepo.GetAllAsync();
            List<string> roleList = [GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer];
            var newFreelancer = allAccount.Where(acc => 
                Helper.IsDateOfMonthAndYear(acc.CreatedAt, checkMonth, checkYear)
                && roleList.Contains(acc.Role));
            var newCus = allAccount.Where(acc =>
                Helper.IsDateOfMonthAndYear(acc.CreatedAt, checkMonth, checkYear)
                && acc.Role.Equals(GlobalConstant.Customer));

            result.NeedResolve = new()
            {
                UnresolvedReportCount = 0,
                FreelancerRequestCount = allAccount.Where(acc => acc.Role.Equals(GlobalConstant.UnverifiedFreelancer)).Count()
            };

            result.PopularServices = new()
            {
                Statistics = _mapper.Map<IEnumerable<ServicePercentageAdminDto>>(await _unitOfWork.AdminRepo.GetServiceTypePercentage())
            };

            var dateCount = DateTime.DaysInMonth(checkYear, checkMonth);
            DateOnly finalDate = new(checkYear, checkMonth, dateCount);
            var allOrders = (await _unitOfWork.OrderRepo.QueryOrdersByMonthAsync(checkMonth, checkYear))
                .Where(o => o.ServiceStatusId.Equals(StatusConst.Completed));

            var profitStatList = new List<ProfitStatisticsAdminDto>();
            for (var dayCount = 1; dayCount <= dateCount; dayCount++)
            {
                var checkDate = new DateOnly(checkYear, checkMonth, dayCount);
                profitStatList.Add(new()
                {
                    Date = checkDate,
                    Profit = allOrders.Where(o => o.CreatedTime.Date.Equals(checkDate)).Sum(o => o.EstimatedPrice)
                });
            }
            result.ProfitOverview = profitStatList;

            var customerAccounts = await _unitOfWork.AccountRepo.GetAllAccountByConditionAsync(
                acc => acc.Role.Equals(GlobalConstant.Customer)
                && acc.CreatedAt.Year.Equals(checkYear)
                && acc.IsActive);
            var customerAccountListStat = new List<AccountStatisticsAdminDto>();

            var freelancerAccounts = await _unitOfWork.FreelanceAccountRepo.GetManyByConditionsAsync(
                acc => acc.Account.IsActive 
                && acc.Account.CreatedAt.Year.Equals(checkYear));
            var freelancerAccountListStat = new List<AccountStatisticsAdminDto>();
            var teamAccountListStat = new List<AccountStatisticsAdminDto>();

            for (var monthNum = 1; monthNum < 13; monthNum++)
            {
                customerAccountListStat.Add(new()
                {
                    MonthNum = monthNum,
                    UsageCount = customerAccounts
                        .Where(acc => acc.CreatedAt.Month.Equals(month)).Count()
                });

                freelancerAccountListStat.Add(new()
                {
                    MonthNum = monthNum,
                    UsageCount = freelancerAccounts
                        .Where(acc => !acc.IsTeam
                            && acc.Account.CreatedAt.Month.Equals(month)).Count()
                });

                teamAccountListStat.Add(new()
                {
                    MonthNum = monthNum,
                    UsageCount = freelancerAccounts
                        .Where(acc => acc.IsTeam
                            && acc.Account.CreatedAt.Month.Equals(month)).Count()
                });
            }

            result.NewUsers =
            [
                new()
                {
                    Name = "Khách hàng",
                    Statistics = customerAccountListStat
                },
                new()
                {
                    Name = "Nhân viên",
                    Statistics = freelancerAccountListStat
                },
                new()
                {
                    Name = "Đội ngũ/Công ty",
                    Statistics = teamAccountListStat
                },
            ];

            return result;
        }
    }
}
