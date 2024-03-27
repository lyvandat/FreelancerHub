using AutoMapper;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.SkillDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.FreelanceQuizService;
using DeToiServer.Services.FreelanceSkillService;
using DeToiServer.Services.OrderManagementService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using DeToiServerCore.QueryModels.FreelanceSkillQueryModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [Route("api/v1/freelancer/skill")]
    [ApiController]
    public class FreelanceSkillController : ControllerBase
    {
        private readonly IFreelanceAccountService _freelanceAccService;
        private readonly IFreelanceSkillService _skillService;
        private readonly IMapper _mapper;

        public FreelanceSkillController(
            IFreelanceAccountService freelanceAccountService,
            IFreelanceSkillService skillService,
            IMapper mapper)
        {
            _freelanceAccService = freelanceAccountService;
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet("all")]
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

        [HttpGet("all-in-category")]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetAllSkillInCategory(
            [FromQuery] Guid categoryId,
            [FromQuery] int? length
        )
        {
            var result = await _skillService.GetAllSkillInCategory(categoryId, length);

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SkillDto>>> SearchFreelancerSkills(
            [FromQuery] string? key,
            [FromQuery] Guid? categoryId
        )
        {
            var result = await _skillService.SearchFreelancerSkills(new FreelanceSkillQuery()
            {
                Key = key,
                CategoryId = categoryId,
            });

            return Ok(result);
        }

        [HttpPost("add-multiple"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult<IEnumerable<SkillDto>>> AddMultipleFreelancerSkills(ChooseFreelancerSkillsDto postSkills)
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

            postSkills.FreelancerId = freelance.Id;
            var result = await _skillService.AddSkillsFreelancer(postSkills);
            if (!result)
            {
                return BadRequest(new
                {
                    Message = "Có lỗi xảy ra trong quá trình thêm kỹ năng, xin hãy thử lại"
                });
            }

            return Ok(new
            {
                Message = "Thêm kỹ năng cho Freelancer thành công"
            });
        }
    }
}
