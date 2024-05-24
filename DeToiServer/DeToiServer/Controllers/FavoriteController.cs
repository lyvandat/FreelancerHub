using System.Security.Claims;
using DeToiServer.Dtos.FavoriteDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FavoriteService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.CustomAttribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("/api/v1/favorite")]
    public class FavoriteController : Controller
    {
        private readonly IFavoriteService _favoriteService;
        private readonly IAccountService _accountService;
        private readonly ICustomerAccountService _customerService;
        private readonly IFreelanceAccountService _freelanceService;
        

        public FavoriteController(IFavoriteService favoriteService, IAccountService accountService, ICustomerAccountService customerService, IFreelanceAccountService freelanceAccount)
        {
            _favoriteService = favoriteService;
            _accountService = accountService;
            _customerService = customerService;
            _freelanceService = freelanceAccount;
        }

        [HttpPost(), AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult> AddFavorite(AddFavoriteDto addFavoriteDto)
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var customer = await _customerService.GetByAccId(accountId);

            if (customer is null)
            {
                return NotFound(new
                {
                    Message = "Không thể thêm Freelancer vào yêu thích, hãy đăng nhập để thử lại."
                });
            }

            var freelancer = await _freelanceService.GetByAccId(addFavoriteDto.FreelancerId);
            if (freelancer is null)
            {
                return NotFound(new
                {
                    Message = "Không tìm thấy tài khoản freelancer"
                });
            }

            var result = await _favoriteService.AddFavorite(customer.Id, addFavoriteDto.FreelancerId);
            if (result is null)
            {
                return BadRequest(new
                {
                    Message = "Lỗi thêm freelancer vào danh sách yêu thích"
                });
            }

            return Ok(new
            {
                Message = "Thêm freelancer vào danh sách yêu thích thành công!"
            });
        }
    }
}