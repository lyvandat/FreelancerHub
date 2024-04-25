using DeToiServer.Dtos.AddressDtos;
using DeToiServerCore.Models.Services;

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

    public class ComparedToLastMonthOverviewDto
    {
        public double ProfitDifferent { get; set; }
        public double DiscountCostDifferent { get; set; }
        public double RevenueDifferent { get; set; }
        public double SuccessOrderCountDifferent { get; set; }
        public double FailedOrderCountDifferent { get; set; }
    }

    public class MonthlyOverviewAdminDto
    {
        // Doanh thu = 5% Tiền dịch vụ
        // Tổng tiền = Tiền dịch vụ + Doanh thu (Revenue)

        public double TotalProfit { get; set; }
        public double TotalDiscountCost { get; set; }
        public double TotalRevenue { get; set; }
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
        public Guid ServiceId { get; set; } // Service type
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
        public ComparedToLastMonthOverviewDto OverviewLastMonth { get; set; } = null!;
        public ServiceTypeStatisticsAdminDto PopularServices { get; set; } = null!;
        public IEnumerable<ProfitStatisticsAdminDto> ProfitOverview { get; set; } = null!;
        public IEnumerable<PromotionTypeStatisticsAdminDto> Promotions { get; set; } = null!;
        public IEnumerable<AccountTypeStatisticsAdminDto> NewUsers { get; set; } = null!;
    }


    #region Manage Account

    public class ManageCustomerAccountDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public DateOnly? DateOfBirth { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CombinedPhone { get; set; } = string.Empty;

        // Số đơn đặt
        // Điểm thưởng
        // Được đánh giá

        public string Role { get; set; } = string.Empty;
    }

    public class ManageFreelancerAccountDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public DateOnly? DateOfBirth { get; set; }

        // Thông tin cơ bản
        public string CountryCode { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CombinedPhone { get; set; } = string.Empty;
        public AddressDto Address { get; set; } = null!;

        // Dịch vụ
        // Số đơn đã hoàn thành
        // Số lượt yêu thích

        // Được đánh giá

        public string Role { get; set; } = string.Empty;
    }

    public class FreelancerAccountLicensingDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public DateOnly? DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;

        // Liên hệ
        public string CountryCode { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CombinedPhone { get; set; } = string.Empty;

        // CMND CCCD
        public string IdentityNumber { get; set; } = string.Empty;
        public string IdentityCardImage { get; set; } = string.Empty;
        public string IdentityCardImageBack { get; set; } = string.Empty;

        // Dịch vụ
        // Số đơn đã hoàn thành
        // Số lượt yêu thích

        // Được đánh giá

        public string Role { get; set; } = string.Empty;
    }

    #endregion

    #region Manage Service Category
    public class ManageListServiceCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ServiceTypeCount { get; set; } // count ICollection<ServiceType>? ServiceTypes;
    }

    public class ManageServiceTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Image { get; set; }
    }

    public class ManageServiceCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string? Description { get; set; }
        public required string ServiceClassName { get; set; }
        public string? Keys { get; set; }
        public ICollection<ManageServiceTypeDto>? ServiceTypes { get; set; }
        public int ServiceTypeCount { get; set; } // count ICollection<ServiceType>? ServiceTypes;
        public IEnumerable<ServicePercentageAdminDto> PopularServices { get; set; } = null!; // count ICollection<ServiceType>? ServiceTypes;
    }

    #endregion
}
