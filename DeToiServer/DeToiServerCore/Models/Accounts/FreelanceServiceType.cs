using DeToiServerCore.Models.Services;

namespace DeToiServerCore.Models.Accounts
{
    public class FreelanceServiceType
    {
        public required Guid FreelancerId { get; set; }
        public required FreelanceAccount Freelancer { get; set; }
        public required Guid ServiceTypeId { get; set; }
        public required ServiceType ServiceType { get; set; }
    }
}
