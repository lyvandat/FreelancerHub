using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.PaymentDtos;
using DeToiServer.Dtos.ServiceCategoryDtos;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.PaymentService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [Route("api/v1/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IFreelanceAccountService _freelanceAccService;
        private readonly UnitOfWork _uow;

        public PaymentController(UnitOfWork uow, IFreelanceAccountService freelanceAccService, IPaymentService paymentService)
        {
            _paymentService = paymentService;
            _freelanceAccService = freelanceAccService;
            _uow = uow;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<GetFreelancePaymentHistoryDto>>> GetAllFreelancePayment()
        {
            
            return Ok(await _paymentService.GetAllFreelancePayment());
        }

        [HttpPut("personal"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult<GetFreelanceAccountShortDetailDto>> UpdatePersonalWallet(double value)
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid freelancerAccountId);
            var freelance = await _freelanceAccService.GetByAccId(freelancerAccountId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            var updated = await _paymentService
                .UpdateFreelancerBalance(new UpdateFreelanceBalanceDto() {
                    Id = freelancerAccountId,
                    Method = GlobalConstant.Payment.Card,
                    WalletType = GlobalConstant.Payment.Wallet.Personal,
                    Value = value,
                });

            if (!await _uow.SaveChangesAsync())
            {
                return BadRequest(new
                {
                    Message = $"Lỗi lưu lịch sử thanh toán cho Freelancer với Id = {freelance.Id}"
                });
            }

            return Ok(updated);
        }
    }
}
