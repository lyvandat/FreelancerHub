using DeToiServer.Dtos.ReportDtos;
using DeToiServerCore.Models.Reports;

namespace DeToiServer.Services.ReportService
{
    public interface IReportService
    {
        Task<IEnumerable<ReportAction>> GetAllReportActions();
        Task<IEnumerable<Report>> GetAllReports();
        Task<Report> PostReport(Guid fromId, PostReportDto postReport);
    }
}
