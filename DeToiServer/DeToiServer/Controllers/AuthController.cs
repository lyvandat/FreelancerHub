using DeToiServer.Dtos;
using DeToiServer.Services.AccountService;
using Microsoft.AspNetCore.Mvc;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        readonly IConfiguration _configuration;
        readonly IAccountService _accService;

        public AuthController(IConfiguration configuration, IAccountService accService)
        {
            _configuration = configuration;
            _accService = accService;
        }

        [HttpGet("detail")]
        public async Task<ActionResult<AccountDto>> GetById(int id)
        {
            var user = await _accService.GetAccountById(id);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAll()
        {
            var user = await _accService.GetAllAccount();
            return Ok(user);
        }
    }
}
