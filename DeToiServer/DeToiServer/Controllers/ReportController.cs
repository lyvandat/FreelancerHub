using AutoMapper;
using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.ReportDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.NotificationService;
using DeToiServer.Services.ReportService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [Route("api/v1/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IReportService _reportService;
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public ReportController(
            IAccountService accService,
            IReportService reportService,
            UnitOfWork uow,
            IMapper mapper)
        {
            _accountService = accService;
            _reportService = reportService;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<GetReportDto>> GetAllReport()
        {
            var result = await _reportService.GetAllReports();

            return Ok(_mapper.Map<IEnumerable<GetReportDto>>(result));
        }

        [HttpPost(), AuthorizeRoles(GlobalConstant.Customer, GlobalConstant.Freelancer)]
        public async Task<ActionResult<GetReportDto>> PostReport(PostReportDto reportDto)
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var account = await _accountService.GetAccountDetailsById(accountId);

            if (account == null)
            {
                return BadRequest(new
                {
                    Message = "Tài khoản không tồn tại. Vui lòng đăng nhập lại"
                });
            }

            var result = await _reportService.PostReport(accountId, reportDto);

            if (!await _uow.SaveChangesAsync())
            {
                return StatusCode(500, new
                {
                    Message = "Có lỗi xảy ra trong lúc gửi báo cáo."
                });
            }

            return Ok(_mapper.Map<GetReportDto>(result));
        }
    }
}
