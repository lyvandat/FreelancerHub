using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;

namespace DeToiServerCore.Models.Reports
{
    public class Report : ModelBase
    {
        public bool Rejected { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ReportDescription { get; set; } = string.Empty;
        public string ResolvingDescription { get; set; } = string.Empty;

        public Guid ActionIdOnCustomer { get; set; } = GlobalConstant.Report.NoAction;
        public ReportAction? ActionOnCustomer { get; set; }
        public Guid ActionIdOnFreelance { get; set; } = GlobalConstant.Report.NoAction;
        public ReportAction? ActionOnFreelance { get; set; }

        public Guid OrderId { get; set; }
        public Order? Order { get; set; }

        public Guid FromAccountId { get; set; }
        public Account? FromAccount { get; set; }
        public ICollection<ReportImage>? Images { get; set; }
    }

    public class ApplyReportAction
    {
        public Guid ReportId { get; set; }
        public Guid ActionIdOnCustomer { get; set; }
        public Guid ActionIdOnFreelance { get; set; }
    }
}
