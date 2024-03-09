using AutoMapper;
using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [Route("api/v1/freelancer")]
    [ApiController]
    public class FreelanceAccountController : ControllerBase
    {
        private readonly IAccountService _accService;
        private readonly IFreelanceAccountService _freelanceAccService;
        private readonly IMapper _mapper;

        public FreelanceAccountController(IAccountService accService, IFreelanceAccountService freelanceAccountService, IMapper mapper)
        {
            _accService = accService;
            _freelanceAccService = freelanceAccountService;
            _mapper = mapper;
        }

        [HttpGet("detail"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult<GetFreelanceMatchingDto>> GetFreelancerDetail(Guid id)
        {
            var freelance = await _freelanceAccService.GetDetailWithStatistic(id);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản!"
                });
            }

            return Ok(freelance);
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
                    Message = "Không tìm thấy tài khoản!"
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
        public async Task<ActionResult<GetFreelanceDto>> GetCurrentFreelancerMatchingOrders()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid freelancerId);
            var freelance = await _freelanceAccService.GetByAccId(freelancerId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản!"
                });
            }
            var result = _mapper.Map<GetFreelanceDto>(freelance);
            result.Address = _mapper.Map<AddressDto>(freelance.Address?.FirstOrDefault());

            return Ok(result);
        }
    }
}
