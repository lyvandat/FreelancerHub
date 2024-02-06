using AutoMapper;
using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Services.AccountService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accService, IMapper mapper)
        {
            _accountService = accService;
            _mapper = mapper;
        }

        [HttpGet("detail")]
        public async Task<ActionResult<GetAccountDto>> GetById(int id)
        {
            var user = await _accountService.GetById(id);

            if (user is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản!"
                });
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAccountDto>>> GetAll()
        {
            return Ok(await _accountService.GetAll());
        }

        [HttpGet("current-account"), Authorize]
        public async Task<ActionResult<GetAccountDto>> GetCurrentAccount()
        {
            int.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out int accountId);
            var result = await _accountService.GetAccountDetailsById(accountId);

            if (result is null)
                return NotFound(new
                {
                    message = "Không tìm thấy tài khoản!"
                });

            return Ok(result);
        }

        [HttpPut(""), Authorize]
        public async Task<ActionResult<int>> UpdateAccount(PutAccountDto putAccountDto)
        {
            int.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out int accountId);
            var account = await _accountService.GetById(accountId);

            if (account is null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy tài khoản!"
                });
            }

            _mapper.Map(putAccountDto, account);

            var result = await _accountService.Update(account);

            if (result is null)
                return NotFound(new
                {
                    message = "Không tìm thấy tài khoản!"
                });

            return Ok(new
            {
                Message = "Cập nhật tài khoản thành công"
            });
        }

        [HttpPut("ban"), Authorize(Roles = GlobalConstant.Admin)]
        public async Task<IActionResult> BanAccount(BanAccountDto acc)
        {
            int.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out int accountId);

            if (acc.Id == accountId)
            {
                return BadRequest(new
                {
                    Message = "Không thể tự cấm tài khoản này!"
                });
            }

            await _accountService.BanAccount(acc.Id);
            return Ok(new { Message = "Cấm tài khoản thành công" });
        }

        //[HttpGet("search"), Authorize(Roles = GlobalConstant.Admin)]
        //public async Task<ActionResult<ResponseMessageDetails<int>>> SearchAccount(
        //    [FromQuery] string name,
        //    [FromQuery] string role,
        //    [FromQuery] string gender,
        //    [FromQuery] PagingDto pageDto,
        //    [FromQuery] string sortingCol,
        //    [FromQuery] string sortType
        //)
        //{
        //    List<AccountInfoDto> result;
        //    try
        //    {
        //        result = await _accountService.GetAllAccountInfo(new FilterAccountDto(name, role, gender, sortingCol, sortType));
        //    }
        //    catch (Microsoft.Data.SqlClient.SqlException exception)
        //    {
        //        return BadRequest(new
        //        {
        //            message = exception.Message
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            message = ex.Message
        //        });
        //    }

        //    var Accounts = PageList<AccountInfoDto>.ToPageList(result.AsQueryable(), pageDto.page_number, pageDto.page_size);

        //    return Ok(new
        //    {
        //        Accounts,
        //        totalCount = Accounts.TotalCount,
        //        pageSize = Accounts.PageSize,
        //        currentPage = Accounts.CurrentPage,
        //        totalPages = Accounts.TotalPages,
        //        hasNext = Accounts.HasNext,
        //        hasPrevious = Accounts.HasPrevious
        //    });
        //}
    }
}
