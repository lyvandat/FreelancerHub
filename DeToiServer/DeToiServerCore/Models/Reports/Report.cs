using DeToiServerCore.Models.Accounts;

namespace DeToiServerCore.Models.Reports
{
    public class Report : ModelBase
    {
        public bool Rejected { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ReportDescription { get; set; } = string.Empty;
        public string ResolvingDescription { get; set; } = string.Empty;

        public Guid ActionIdOnCustomer { get; set; }
        public ReportAction? ActionOnCustomer { get; set; }
        public Guid ActionIdOnFreelance { get; set; }
        public ReportAction? ActionOnFreelance { get; set; }

        public Guid FromId { get; set; }
        public Account? FromAccount { get; set; }
        public Guid ToId { get; set; }
        public Account? ToAccount { get; set; }
    }

    public class ApplyReportAction
    {
        public Guid ReportId { get; set; }
        public Guid ActionIdOnCustomer { get; set; }
        public Guid ActionIdOnFreelance { get; set; }
    }
}
