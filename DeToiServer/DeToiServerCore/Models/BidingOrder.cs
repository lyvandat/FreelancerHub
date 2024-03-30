using DeToiServerCore.Models.Accounts;

namespace DeToiServerCore.Models
{
    public class BiddingOrder : ModelBase
    {
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public Guid FreelancerId { get; set; }
        public FreelanceAccount? Freelancer { get; set; }
        public double PreviewPrice { get; set; }
    }
}
