using AutoMapper;
using Azure;
using DeToiServer.Dtos.LocationDtos;
using DeToiServer.Dtos.PaymentDtos;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.PaymentService;
using DeToiServerCore.Common.Constants;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;
using Newtonsoft.Json.Linq;
using System;

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

        public PayOsController(UnitOfWork uow, IFreelanceAccountService freelanceAccService, IPaymentService paymentService, IMapper mapper)
        {
            _freelanceAccService = freelanceAccService;
            _paymentService = paymentService;
            _uow = uow;
            _mapper = mapper;
        }

        private long GenerateTimestampBasedID()
        {
            return long.Parse(DateTimeOffset.Now.ToString("ffffff"));
        }

        [HttpPost("payment-link")]
        public async Task<ActionResult<CreatePaymentResult>> CreateNewPaymentLink(PostFreelancePaymentDto paymentDto)
        {
            long orderCode = GenerateTimestampBasedID();
            string description = $"Nạp tiền vào ví tài khoản: {paymentDto.FreelancerId}";
            ItemData item = new ItemData(description, 1, paymentDto.Amount);
            List<ItemData> items = [item];
            PaymentData paymentData = new PaymentData(
                orderCode,
                paymentDto.Amount,
                paymentDto.FreelancerId.ToString().Substring(0, 25),
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
                Console.WriteLine(exception.Message);
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

                if (data.description == "Ma giao dich thu nghiem" || data.description == "VQRIO123")
                {
                    return Ok("Xác nhận thanh toán mẫu thành công");
                }

                // Update top-up status
                var phoneNumber = data.orderCode.ToString();
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
                Console.WriteLine(e.Message);
                return Ok("Xác nhận thanh toán thất bại");
            }

        }

        [HttpPost("payos-confirm-test")]
        public async Task<ActionResult> payOSTransferHandleTest()
        {
            try
            {
                // Update top-up status
                var phoneNumber = "914510313";
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
                Console.WriteLine(e.Message);
                return Ok("Xác nhận thanh toán thất bại");
            }

        }
    }
}
