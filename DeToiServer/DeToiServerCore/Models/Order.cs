using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;

namespace DeToiServerCore.Models
{
    public class Order : ModelBase
    {
        public Guid AddressId { get; set; }
        public Address? Address { get; set; }
        public double EstimatedPrice { get; set; }
        public double RecommendPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public Guid? FreelancerId { get; set; }
        public FreelanceAccount? Freelance { get; set; }
        public Guid CustomerId { get; set; }
        public CustomerAccount? Customer { get; set; }
        public double Rating { get; set; }
        public string? Comment { get; set; }
        public double FreelancerRating { get; set; } = 0;
        public Guid ServiceStatusId { get; set; } = new Guid("a888efc3-1d7b-445a-b38c-758737b67bad");
        public ServiceStatus? ServiceStatus { get; set; }
        public ICollection<OrderService>? OrderServices { get; set; }
        public ICollection<OrderServiceType>? OrderServiceTypes { get; set; }
        public ICollection<ServiceProven>? ServiceProven { get; set; }
        public ICollection<BiddingOrder>? BiddingOrders { get; set; }
        public ICollection<OrderSkillRequired>? SkillRequired { get; set; }
    }
}
