using AutoMapper;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.PaymentDtos;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.PaymentService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [Route("api/v1/payos")]
    [ApiController]
    public class PayOsController : ControllerBase
    {
        private readonly PayOS _payOS = new("7eb00d7f-5c50-4f85-ae17-0db04ba25cc8", "d121e543-276a-4c32-9c97-b8eed1d2d5ac", "d2951f25120901cab05921fd8b783c9d033f8e79282bcc439cf5aa91b100e609");
        private readonly IFreelanceAccountService _freelanceAccService;
        private readonly IPaymentService _paymentService;
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<PayOsController> _logger;

        public PayOsController(UnitOfWork uow, IFreelanceAccountService freelanceAccService, IPaymentService paymentService, IMapper mapper, ILogger<PayOsController> logger)
        {
            _freelanceAccService = freelanceAccService;
            _paymentService = paymentService;
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        private long GenerateTimestampBasedID()
        {
            return long.Parse(DateTimeOffset.Now.ToString("ffffff"));
        }

        [HttpPost("payment-link"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult<CreatePaymentResult>> CreateNewPaymentLink(PostFreelancePaymentDto paymentDto)
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelancer = await _freelanceAccService.GetByAccId(accountId);

            if (freelancer == null)
            {
                return BadRequest(new
                {
                    Message = "Tài khoản freelancer không tồn tại"
                });
            }

            var phoneNumber = long.Parse(freelancer.Account.Phone);
            Random random = new Random();
            int randomDigits = random.Next(1000, 10000); // Generates a random 4-digit number
            long finalOrderCode = phoneNumber * 10000 + randomDigits;
            string description = $"Nạp tiền vào ví tài khoản: {accountId}";
            ItemData item = new ItemData(description, 1, paymentDto.Amount);
            List<ItemData> items = [item];
            PaymentData paymentData = new PaymentData(
                finalOrderCode,
                paymentDto.Amount,
                "Nạp tiền vào ví cá nhân",
                items,
                "https://localhost:7140/api/v1/payos/failed",
                "https://localhost:7140/api/v1/payos/success"
            );

            CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

            return Ok(createPayment);
        }

        [HttpGet("order")]
        public async Task<ActionResult<PaymentLinkInformation>> GetOrder(int orderId)
        {
            PaymentLinkInformation paymentLinkInformation = await _payOS.getPaymentLinkInfomation(orderId);

            return Ok(paymentLinkInformation);
        }

        [HttpDelete("order")]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            PaymentLinkInformation paymentLinkInformation = await _payOS.cancelPaymentLink(orderId);

            return Ok(paymentLinkInformation);
        }

        [HttpPost("confirm-webhook")]
        public async Task<IActionResult> ConfirmWebhook(ConfirmWebhook body)
        {
            try
            {
                await _payOS.confirmWebhook(body.Webhook_url);
                return Ok(body.Webhook_url);
            }
            catch (System.Exception exception)
            {
                _logger.LogError(exception.Message);
                return BadRequest(new
                {
                    Message = "Không thể xác nhận webhook"
                });
            }
        }

        [HttpPost("payos-confirm")]
        public async Task<ActionResult> payOSTransferHandler(WebhookType body)
        {
            try
            {
                WebhookData data = _payOS.verifyPaymentWebhookData(body);
                _logger.LogInformation("---Confirm web hook is running");
                if (data.description == "Ma giao dich thu nghiem" || data.description == "VQRIO123")
                {
                    return Ok("Xác nhận thanh toán mẫu thành công");
                }

                // Update top-up status
                var phoneNumber = data.orderCode.ToString().Substring(0, data.orderCode.ToString().Length - 4);
                _logger.LogInformation("Freelancer deposit number: " + phoneNumber);
                var freelance = await _freelanceAccService.GetByAccPhone(phoneNumber);

                if (freelance is null)
                {
                    return BadRequest(new
                    {
                        Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                    });
                }

                var updated = await _paymentService
                    .UpdateFreelancerBalance(new UpdateFreelanceBalanceDto()
                    {
                        Id = freelance.Id,
                        Method = GlobalConstant.Payment.Card,
                        WalletType = GlobalConstant.Payment.Wallet.System,
                        Value = data.amount,
                    });

                if (!await _uow.SaveChangesAsync())
                {
                    return BadRequest(new
                    {
                        Message = $"Lỗi lưu lịch sử thanh toán cho Freelancer với Id = {freelance.Id}"
                    });
                }

                return Ok("Xác nhận thanh toán thành công");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Ok("Xác nhận thanh toán thất bại");
            }

        }

        [HttpPost("payos-confirm-test")]
        public async Task<ActionResult> payOSTransferHandleTest()
        {
            try
            {
                // Update top-up status
                var phoneNumber = "9145103131234".Substring(0, "9145103131234".Length - 4); ;
                var freelance = await _freelanceAccService.GetByAccPhone(phoneNumber);

                if (freelance is null)
                {
                    return BadRequest(new
                    {
                        Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                    });
                }

                var updated = await _paymentService
                    .UpdateFreelancerBalance(new UpdateFreelanceBalanceDto()
                    {
                        Id = freelance.Id,
                        Method = GlobalConstant.Payment.Card,
                        WalletType = GlobalConstant.Payment.Wallet.System,
                        Value = 50000,
                    });

                if (!await _uow.SaveChangesAsync())
                {
                    return BadRequest(new
                    {
                        Message = $"Lỗi lưu lịch sử thanh toán cho Freelancer với Id = {freelance.Id}"
                    });
                }

                return Ok("Xác nhận thanh toán thành công");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Ok("Xác nhận thanh toán thất bại");
            }

        }
    }
}
