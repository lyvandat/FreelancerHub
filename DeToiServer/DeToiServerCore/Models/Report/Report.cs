using DeToiServerCore.Models.Accounts;

namespace DeToiServerCore.Models.Report
{
    public class Report : ModelBase
    {
        public Guid StatusId { get; set; }
        // public ReportStatus? Status { get; set; }
        public Guid ActionId { get; set; }
        // public ReportAction? Action { get; set; }


        public Guid CustomerId { get; set; }
        public CustomerAccount? Customer { get; set; }
        public Guid FreelancerId { get; set; }
        public FreelanceAccount? Freelancer { get; set; }
    }
}
