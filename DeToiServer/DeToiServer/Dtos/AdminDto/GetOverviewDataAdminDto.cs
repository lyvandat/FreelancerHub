namespace DeToiServer.Dtos.AdminDto
{

    public class FeedbackCountAdminDto
    {
        public int ServiceRequestCount { get; set; }
        public int SystemErrorCount { get; set; }
        public int FeedbackCount { get; set; }
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
        public DateOnly Date { get; set; }
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
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<PromotionStatisticsAdminDto> Statistics { get; set; } = null!;
    }

    public class GetOverviewDataAdminDto
    {

    }
}
