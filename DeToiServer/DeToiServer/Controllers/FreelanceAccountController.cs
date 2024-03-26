using AutoMapper;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.SkillDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.FreelanceQuizService;
using DeToiServer.Services.FreelanceSkillService;
using DeToiServer.Services.OrderManagementService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.QueryModels.OrderQueryModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [Route("api/v1/freelancer")]
    [ApiController]
    public class FreelanceAccountController : ControllerBase
    {
        private readonly IAccountService _accService;
        private readonly IFreelanceAccountService _freelanceAccService;
        private readonly IOrderManagementService _orderService;
        private readonly IFreelanceQuizService _quizService;
        private readonly IFreelanceSkillService _skillService;
        private readonly IMapper _mapper;

        public FreelanceAccountController(
            IAccountService accService, 
            IFreelanceAccountService freelanceAccountService, 
            IOrderManagementService orderService, 
            IFreelanceQuizService quizService, 
            IFreelanceSkillService skillService,
            IMapper mapper)
        {
            _accService = accService;
            _freelanceAccService = freelanceAccountService;
            _orderService = orderService;
            _quizService = quizService;
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<GetFreelanceMatchingDto>> GetAllFreelancer()
        {
            var freelance = await _freelanceAccService.GetAllFreelanceDetail();
            return Ok(freelance);
        }

        [HttpGet("detail")] // , AuthorizeRoles(GlobalConstant.Freelancer)
        public async Task<ActionResult<GetFreelanceMatchingDto>> GetFreelancerDetail(Guid id)
        {
            var freelance = await _freelanceAccService.GetDetailWithStatistic(id);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản Freelancer"
                });
            }

            return Ok(freelance);
        }

        [HttpGet("short-detail"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult<GetFreelanceAccountShortDetailDto>> GetFreelancerShortDetail()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid freelancerAccountId);
            var freelancer = await _freelanceAccService.GetByAccId(freelancerAccountId);
            if (freelancer is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản!"
                });
            }

            return Ok(_mapper.Map<GetFreelanceAccountShortDetailDto>(freelancer));
        }

        [HttpGet("current"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult<GetFreelanceDto>> GetCurrentFreelancerDetail()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid freelancerId);
            var freelance = await _freelanceAccService.GetByAccId(freelancerId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }
            var result = _mapper.Map<GetFreelanceDto>(freelance);
            result.Address = _mapper.Map<AddressDto>(freelance.Address!.FirstOrDefault());

            return Ok(new
            {
                result,
                freelance
            });
        }

        [HttpGet("orders"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> GetCurrentFreelancerMatchingOrders([FromQuery] FilterFreelancerOrderQuery filterQuery)
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid freelancerId);
            var freelance = await _freelanceAccService.GetByAccId(freelancerId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            var result = await _orderService.GetFreelancerSuitableOrders(freelance.Id, filterQuery);
            var orderPage = PageList<GetOrderDto>.ToPageList(result.AsQueryable(), filterQuery.Page, filterQuery.PageSize);

            return Ok(result);
        }

        [HttpGet("orders/incoming"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> GetFreelancerIncomingOrders()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid freelancerId);
            var freelance = await _freelanceAccService.GetByAccId(freelancerId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            var result = await _orderService.GetFreelancerIncomingOrders(freelance.Id);

            return Ok(result);
        }

        [HttpGet("added-skills-and-done-test"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult<IsFreelancerAddedSkillAndDoneTest>> IsFreelancerHaveSkillsAndDoneTest()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelance = await _freelanceAccService.GetByAccId(accountId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Có lỗi xảy ra trong quá trình đăng nhập, xin hãy thử lại"
                });
            }

            var result = _mapper.Map<GetFreelanceDto>(freelance);

            return Ok(new IsFreelancerAddedSkillAndDoneTest()
            {
                IsAddedSkill = !(result.Skills == null || result.Skills.Count == 0),
                IsDoneTest = await _quizService.IsFreelancerDoneQuiz(freelance.Id),
            });
        }

        [HttpGet("skill/all")]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetAllSkills()
        {
            //_ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            //var freelance = await _freelanceAccService.GetByAccId(accountId);

            //if (freelance is null)
            //{
            //    return BadRequest(new
            //    {
            //        Message = "Có lỗi xảy ra trong quá trình đăng nhập, xin hãy thử lại"
            //    });
            //}

            var result = await _skillService.GetAllSkills();

            return Ok(result);
        }
    }
}
