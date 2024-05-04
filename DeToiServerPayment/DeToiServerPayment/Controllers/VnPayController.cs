using DeToiServer.Payment;
using DeToiServerPayment.AsyncDataServices;
using DeToiServerPayment.ConfigModels;
using DeToiServerPayment.Data;
using DeToiServerPayment.Dtos;
using DeToiServerPayment.Dtos.PaymentDtos;
using DeToiServerPayment.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DeToiServerPayment.Controllers
{
    [Route("api/vnpay")]
    [ApiController]
    public class VnPayController : ControllerBase
    {
        private readonly VnPayConfigModel _vnPayConfig;
        private readonly IOrderRepo _orderRepo;
        private readonly IMessageBusClient _messageBusClient;

        public VnPayController(IOptions<VnPayConfigModel> vnPayConfig, IOrderRepo orderRepo, IMessageBusClient messageBusClient)
        {
            _vnPayConfig = vnPayConfig.Value;
            _orderRepo = orderRepo;
            _messageBusClient = messageBusClient;
        }

        [HttpGet("test")]
        public ActionResult TestGw()
        {

            return Ok("Enter gateway");
        }

        [HttpGet("confirm-redirect")]
        public ActionResult Redirect()
        {

            return Redirect("youtube.com");
        }

        [HttpGet("vnpay")]
        public ActionResult PayWithVnPay(GetVnPayPaymentDto vnPayPaymentDto)
        {
            //Get Config Info
            string vnp_Returnurl = _vnPayConfig.ReturnUrl; //URL nhan ket qua tra ve 
            string vnp_Url = _vnPayConfig.Url; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = _vnPayConfig.TmnCode; //Ma định danh merchant kết nối (Terminal Id)
            string vnp_HashSecret = _vnPayConfig.HashSecret; //Secret Key

            //Build URL for VNPAY
            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", vnPayPaymentDto.Command);
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_BankCode", vnPayPaymentDto.BankCode);
            vnpay.AddRequestData("vnp_Amount", (vnPayPaymentDto.Price * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(HttpContext));
            vnpay.AddRequestData("vnp_Locale", vnPayPaymentDto.Locale);
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + vnPayPaymentDto.OrderId);
            vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", vnPayPaymentDto.OrderId.ToString()); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            Response.Redirect(paymentUrl);

            return Ok(new
            {
                RedirectUrl = paymentUrl
            });
        }

        [HttpGet("test-vnpay-confirm")]
        private ActionResult PayWithVnPayConfirmWebHook2()
        {
            _messageBusClient.UpdateOrderPaymentStatus(new PaymentStatusUpdatedDto()
            {
                OrderId = Guid.Parse("3D0E9407-3D1E-402E-9FAC-3861E5FE8262"),
                PaymentStatus = PaymentStatus.Paid,
                Event = "PaymentStatusUpdated"
            });

            return Ok("Confirm payment succeeds");
        }
    }
}
