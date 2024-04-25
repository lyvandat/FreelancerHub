using DeToiServerCore.Models.Payment;
using DeToiServerCore.Models.Quiz;
using DeToiServerCore.Models.Services;

namespace DeToiServerCore.Models.Accounts
{
    public class FreelanceAccount : ModelBase
    {
        public required Account Account { get; set; }
        public required Guid AccountId { get; set; }
        public double Rating { get; set; }
        public string Balance { get; set; } = string.Empty;
        public string SystemBalance { get; set; } = string.Empty;
        public int OrderCount { get; set; }
        public int LoveCount { get; set; }
        public int PositiveReviewCount { get; set; }
        public int TotalReviewCount { get; set; }
        public ICollection<Address>? Address { get; set; }
        public string IdentityNumber { get; set; } = string.Empty;
        public string IdentityCardImage { get; set; } = string.Empty;
        public string IdentityCardImageBack { get; set; } = string.Empty;
        public bool IsTeam { get; set; } = false;
        public string Description { get; set; } = string.Empty;
        public int TeamMemberCount { get; set; } = 1;
        public int MarkCount { get; set; } = 0;
        public ICollection<FreelanceSkill>? FreelanceSkills { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<ServiceProven>? ServiceProven { get; set; }
        public ICollection<Favorite>? FavoriteBy { get; set; }
        public ICollection<FreelanceQuiz>? QuizCollection { get; set; }
        public ICollection<BiddingOrder>? BiddingOrders { get; set; }
        public ICollection<FreelancePaymentHistory>? PaymentHistories { get; set; }
        public ICollection<FreelanceServiceType>? FreelancerFeasibleServices { get; set; }
    }
}
