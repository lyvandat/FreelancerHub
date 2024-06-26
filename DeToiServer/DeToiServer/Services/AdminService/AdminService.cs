﻿using AutoMapper;
using DeToiServer.Dtos.AdminDto;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.QueryModels.AccountQueryModels;
using Microsoft.AspNetCore.Authorization.Infrastructure;
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

        public async Task<GetOverviewDataAdminDto> GetAllOverviewDataAdmin(ServiceOverviewQueryDto queryStat)
        {
            GetOverviewDataAdminDto result = new();
            var curDate = DateTime.Now.Date;

            #region Overview
            var overviewDate = queryStat.Overview ?? new() {
                Month = curDate.Month,
                Year = curDate.Year,
            };
            DateTime thisDate = new DateTime(overviewDate.Year, overviewDate.Month, 1).AddDays(-1);
            var monthlyOverview = await GetOverviewDataAdminByMonth(overviewDate.Month, overviewDate.Year);
            var lastOverview = await GetOverviewDataAdminByMonth(thisDate.Month, thisDate.Year);

            result.Overview = monthlyOverview;
            result.OverviewLastMonth = ComparedToLastMonthOverview(monthlyOverview, lastOverview);
            #endregion

            #region Income
            var incomeDate = queryStat.Income ?? new()
            {
                Month = curDate.Month,
                Year = curDate.Year,
            };
            var dateCount = DateTime.DaysInMonth(incomeDate.Year, incomeDate.Month);
            DateOnly finalDate = new(incomeDate.Year, incomeDate.Month, dateCount);
            var allOrders = (await _unitOfWork.OrderRepo.QueryOrdersByMonthAsync(incomeDate.Month, incomeDate.Year))
                .Where(o => o.ServiceStatusId.Equals(StatusConst.Completed));

            var profitStatList = new List<ProfitStatisticsAdminDto>();
            for (var dayCount = 1; dayCount <= dateCount; dayCount++)
            {
                var checkDate = new DateOnly(incomeDate.Year, incomeDate.Month, dayCount);
                profitStatList.Add(new()
                {
                    Date = checkDate,
                    Profit = allOrders.Where(o => o.CreatedTime.Date.Equals(checkDate)).Sum(o => o.EstimatedPrice)
                });
            }
            result.ProfitOverview = profitStatList;
            #endregion

            #region NewUsers
            var newUsersDate = queryStat.NewUsers ?? new()
            {
                Month = curDate.Month,
                Year = curDate.Year,
            };
            var customerAccounts = (await _unitOfWork.AccountRepo
                .QueryAccountByCreationTimeAndRoleAsync(new AccountCreationDateAndRolesQuery
                {
                    Month = null,
                    Year = newUsersDate.Year,
                    Roles = [GlobalConstant.Customer]
                })).Where(acc => acc.IsActive);
            var customerAccountListStat = new List<AccountStatisticsAdminDto>();

            var freelancerAccounts = await _unitOfWork.FreelanceAccountRepo.GetManyByConditionsAsync(
                acc => acc.Account.IsActive 
                && acc.Account.CreatedAt.Year.Equals(newUsersDate.Year));
            var freelancerAccountListStat = new List<AccountStatisticsAdminDto>();
            var teamAccountListStat = new List<AccountStatisticsAdminDto>();

            for (var monthNum = 1; monthNum < 13; monthNum++)
            {
                customerAccountListStat.Add(new()
                {
                    MonthNum = monthNum,
                    UsageCount = customerAccounts
                        .Where(acc => acc.CreatedAt.Month.Equals(monthNum)).Count()
                });

                freelancerAccountListStat.Add(new()
                {
                    MonthNum = monthNum,
                    UsageCount = freelancerAccounts
                        .Where(acc => !acc.IsTeam
                            && acc.Account.CreatedAt.Month.Equals(monthNum)).Count()
                });

                teamAccountListStat.Add(new()
                {
                    MonthNum = monthNum,
                    UsageCount = freelancerAccounts
                        .Where(acc => acc.IsTeam
                            && acc.Account.CreatedAt.Month.Equals(monthNum)).Count()
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
            #endregion

            #region Discount
            var discountDate = queryStat.Discount ?? new()
            {
                Month = curDate.Month,
                Year = curDate.Year,
            };
            #endregion

            #region Global stat
            var allAccount = await _unitOfWork.AccountRepo.GetAllAsync();
            result.NeedResolve = new()
            {
                UnresolvedReportCount = 0,
                FreelancerRequestCount = allAccount.Where(acc => acc.Role.Equals(GlobalConstant.UnverifiedFreelancer)).Count()
            };

            result.PopularServices = new()
            {
                Statistics = _mapper.Map<IEnumerable<ServicePercentageAdminDto>>(await _unitOfWork.AdminRepo.GetServiceTypePercentage())
            };
            #endregion

            return result;
        }

        public async Task<AdminAccount> GetAdminByAccId(Guid accId)
        {
            return await _unitOfWork.AdminRepo.GetAdminByAccIdAsync(accId);
        }

        public async Task<AdminAccount> Add(AdminAccount admin)
        {
            return await _unitOfWork.AdminRepo.CreateAsync(admin);
        }
    }
}
