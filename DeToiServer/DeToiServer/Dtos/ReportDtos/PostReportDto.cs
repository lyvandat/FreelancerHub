using DeToiServerCore.Models.Accounts;

namespace DeToiServer.Dtos.ReportDtos
{
    public class PostReportDto
    {
        public Guid OrderId { get; set; }
        public string ReportDescription { get; set; } = string.Empty;
        public ICollection<string>? Images { get; set; }
    }

    public class PostRejectReportDto
    {
        public Guid ReportId { get; set; }
        public string ResolvingDescription { get; set; } = string.Empty;
    }
}
