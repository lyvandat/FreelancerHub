using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Reports;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories.ReportRepo
{
    public class ReportRepo(DataContext context) : RepositoryBase<Report>(context), IReportRepo
    {
        private readonly DataContext _context = context;

        public async Task<IEnumerable<ReportAction>> GetAllReportActionAsync()
        {
            return await _context.ReportActions.AsSplitQuery().AsNoTracking().ToListAsync();
        }

        public async Task<Report> ApplyActionAsync(ApplyReportAction applyReportAction)
        {
            var report = await _context.Reports.AsSplitQuery()
                .Include(r => r.Order)
                .FirstOrDefaultAsync(r => r.Id.Equals(applyReportAction.ReportId));

            if (!GlobalConstant.Report.NoAction.Equals(applyReportAction.ActionIdOnFreelance))
            {
                var freelance = await _context.Freelancers
                    .Include(fl => fl.Account)
                    .FirstOrDefaultAsync(fl => fl.Id.Equals(report.Order.FreelancerId));

                if (GlobalConstant.Report.MarkFreelancer.Equals(applyReportAction.ActionIdOnFreelance))
                {
                    freelance.MarkCount += 1;
                    if (++freelance.MarkCount == GlobalConstant.Report.MarkToBan)
                    {
                        freelance.Account.IsActive = false;
                    }
                }
                else if (GlobalConstant.Report.BanFreelancer.Equals(applyReportAction.ActionIdOnFreelance))
                {
                    freelance.Account.IsActive = false;
                }
            }
            if (!GlobalConstant.Report.NoAction.Equals(applyReportAction.ActionIdOnCustomer))
            {

            }

            report.ActionIdOnCustomer = applyReportAction.ActionIdOnCustomer;
            report.ActionIdOnFreelance = applyReportAction.ActionIdOnFreelance;

            return report;
        }

        public async Task<Report> PostRejectReportAsync(Guid reportId, string resolvingDescription)
        {
            var report = await _context.Reports.AsSplitQuery()
                .FirstOrDefaultAsync(r => r.Id.Equals(reportId));

            report.Rejected = true;
            report.ResolvingDescription = resolvingDescription;

            return report;
        }
    }
}
