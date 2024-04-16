namespace DeToiServer.Dtos.AdminDto
{

    public class FeedbackCountAdminDto
    {
        public int ServiceRequestCount { get; set; }
        public int SystemErrorCount { get; set; }
        public int FeedbackCount { get; set; }
    }

    public class NeedResolveCountAdminDto
    {
        public int UnresolvedReportCount { get; set; }
        public int FreelancerRequestCount { get; set; }
    }

    public class MonthlyOverviewAdminDto
    {
        // Doanh thu = 5% Tiền dịch vụ
        // Tổng tiền = Tiền dịch vụ + Doanh thu (Revenue)

        public double TotalProfit { get; set; }
        public double TotalDiscountCost { get; set; }
        public int TotalRevenue { get; set; }
        public int SuccessOrderCount { get; set; }
        public int FailedOrderCount { get; set; }
    }

    public class ProfitStatisticsAdminDto
    {
        public DateOnly Date { get; set; }
        public double Profit { get; set; }
    }

    public class PromotionStatisticsAdminDto
    {
        public int MonthNum { get; set; }
        public string Month { get; set; } = null!;
        public int UsageCount { get; set; }
    }

    public class PromotionTypeStatisticsAdminDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<PromotionStatisticsAdminDto> Statistics { get; set; } = null!;
    }

    public class AccountStatisticsAdminDto
    {
        public int MonthNum { get; set; }
        public string Month { get; set; } = null!;
        public int UsageCount { get; set; }
    }

    public class AccountTypeStatisticsAdminDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<AccountStatisticsAdminDto> Statistics { get; set; } = null!;
    }

    public class ServicePercentageAdminDto
    {
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public double Percentage { get; set; }
    }

    public class ServiceTypeStatisticsAdminDto
    {
        public IEnumerable<ServicePercentageAdminDto> Statistics { get; set; } = null!;
    }

    public class GetOverviewDataAdminDto
    {
        public FeedbackCountAdminDto Feedback { get; set; } = null!;
        public NeedResolveCountAdminDto NeedResolve { get; set; } = null!;
        public MonthlyOverviewAdminDto Overview { get; set; } = null!;
        public ServiceTypeStatisticsAdminDto PopularServices { get; set; } = null!;
        public IEnumerable<ProfitStatisticsAdminDto> ProfitOverview { get; set; } = null!;
        public IEnumerable<PromotionTypeStatisticsAdminDto> Promotions { get; set; } = null!;
        public IEnumerable<AccountTypeStatisticsAdminDto> NewUsers { get; set; } = null!;
    }
}
