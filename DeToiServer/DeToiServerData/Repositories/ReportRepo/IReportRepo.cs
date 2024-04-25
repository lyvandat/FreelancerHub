using DeToiServerCore.Models.Reports;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories.ReportRepo
{
    public interface IReportRepo : IRepository<Report>
    {
        Task<IEnumerable<ReportAction>> GetAllReportActionAsync();
        Task<Report> ApplyActionAsync(ApplyReportAction applyReportAction);
        Task<Report> PostRejectReportAsync(Guid reportId, string resolvingDescription);
    }
}
