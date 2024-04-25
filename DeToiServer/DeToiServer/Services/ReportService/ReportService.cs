using AutoMapper;
using DeToiServer.Dtos.ReportDtos;
using DeToiServerCore.Models.Reports;

namespace DeToiServer.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public ReportService(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReportAction>> GetAllReportActions()
        {
            return await _uow.ReportRepo.GetAllReportActionAsync();
        }

        public async Task<Report> PostReport(Guid fromId, PostReportDto postReport)
        {
            var reportToPost = _mapper.Map<Report>(postReport);
            reportToPost.FromId = fromId;

            return await _uow.ReportRepo.CreateAsync(reportToPost);
        }

        //public async Task<Report> RejectReport(PostRejectReportDto rejectDto)
        //{
            

        //}

        public async Task<Report> ApplyReportAction(ApplyReportAction reportAction)
        {
            return await _uow.ReportRepo.ApplyActionAsync(reportAction);
        }

    }
}
