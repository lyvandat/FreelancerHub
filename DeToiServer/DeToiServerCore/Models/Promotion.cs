using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;

namespace DeToiServerCore.Models
{
    public class Promotion : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Value { get; set; }
        public string DiscountType { get; set; } = DiscountTypeConst.Direct;
        public string RequiredRank { get; set; } = CustomerRankConst.Bronze;
        public int Quantity { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        public ICollection<CustomerPromotion>? CustomerPromotions { get; set; }
    }

    public class CustomerPromotion
    {
        public Guid CustomerId { get; set; }
        public CustomerAccount? Customer { get; set; }
        public Guid PromotionId { get; set; }
        public Promotion? Promotion { get; set; }

        public int Quantity { get; set; }
    }

    public class PromotionRedeemHistory
    {
        public Guid CustomerId { get; set; }
        public CustomerAccount? Customer { get; set; }
        public Guid PromotionId { get; set; }
        public Promotion? Promotion { get; set; }

        public int Quantity { get; set; }
        public DateTime RecordedAt { get; set; }
    }
}
