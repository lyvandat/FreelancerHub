using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;

namespace DeToiServerCore.Models
{
    public class Order : ModelBase
    {
        public string Address { get; set; } = string.Empty;
        public double EstimatedPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ScheduleTime { get; set; }
        public DateTime CreatedTime { get; set; }

        public int FreelancerId { get; set; }
        public FreelanceAccount? Freelance { get; set; }
        public int CustomerId { get; set; }
        public CustomerAccount? Customer { get; set; }
        public double Rating { get; set; }
        public required int ServiceCategoryId { get; set; }
        public required ServiceCategory ServiceCategory { get; set; }
        public int ServiceStatusId { get; set; }
        public ServiceStatus? ServiceStatus { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}
