namespace DeToiServerCore.Models.Reports
{
    public class ReportAction : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Report>? ReportsOnFreelancer { get; set; }
        public ICollection<Report>? ReportsOnCustomer { get; set; }
    }
}
