namespace DeToiServerCore.Models.Report
{
    public class ReportStatus : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Report>? Reports { get; set; }
    }
}
