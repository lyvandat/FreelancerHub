using AutoMapper;
using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FreelanceAccountService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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

        [HttpGet("detail")]
        public async Task<ActionResult<GetFreelanceDto>> GetById(Guid id)
        {
            var freelance = await _freelanceAccService.GetByAccId(id);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản!"
                });
            }
            var result = _mapper.Map<GetFreelanceDto>(freelance);
            result.Address = _mapper.Map<AddressDto>(freelance.Address?.FirstOrDefault());

            return Ok(new
            {
                result
            });
        }
    }
}
