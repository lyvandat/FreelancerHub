using AutoMapper;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.QuizDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.FreelanceQuizService;
using DeToiServer.Services.OrderManagementService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [Route("api/v1/freelancer/quiz")]
    [ApiController]
    public class FreelanceQuizController : ControllerBase
    {
        private readonly IAccountService _accService;
        private readonly IFreelanceAccountService _freelanceAccService;
        private readonly IFreelanceQuizService _quizService;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _uow;

        public FreelanceQuizController(IAccountService accService, IFreelanceAccountService freelanceAccountService, IFreelanceQuizService quizService, IMapper mapper, UnitOfWork uow)
        {
            _accService = accService;
            _freelanceAccService = freelanceAccountService;
            _quizService = quizService;
            _mapper = mapper;
            _uow = uow;
        }

        [HttpGet("result/all")]
        public async Task<ActionResult<IEnumerable<FreelanceQuizResultDto>>> GetAllFreelanceQuizResult()
        {
            var res = await _quizService.GetAllQuizResult();

            return Ok(res);
        }

        [HttpGet("latest-result"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<FreelanceQuizResultDto>> GetLatestQuizResult()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelance = await _freelanceAccService.GetByAccId(accountId);

            if (freelance == null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            var result = await _quizService.GetLatestQuizResult(freelance.Id);

            return Ok(result);
        }

        [HttpGet("new-set"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<GetPreDefinedQuizDto>> GetNewQuizSet()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelance = await _freelanceAccService.GetByAccId(accountId);

            if (freelance == null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            var result = await _quizService.GetFreelancerUncompleteQuiz(freelance.Id);
            if (result == null)
            {
                return BadRequest(new
                {
                    Message = "Lỗi tạo bộ đề mới cho Freelancer"
                });
            }

            return Ok(result);
        }

        [HttpPost("result"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<string>> PostFreelancerResult(PostFreelanceQuizResultDto postResult)
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelance = await _freelanceAccService.GetByAccId(accountId);

            if (freelance == null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            postResult.FreelancerId = freelance.Id;
            var result = await _quizService.PostFreelanceQuizResult(postResult);

            if (result == null)
            {
                return BadRequest(new
                {
                    Message = "Lỗi gửi kết quả kiểm tra"
                });
            }

            await _uow.SaveChangesAsync();

            return Ok(new
            {
                Message = "Gửi kết quả kiểm tra thành công"
            });
        }
    }
}
