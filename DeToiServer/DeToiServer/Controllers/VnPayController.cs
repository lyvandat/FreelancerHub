using DeToiServer.ConfigModels;
using DeToiServer.Dtos;
using DeToiServer.Dtos.PaymentDtos;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.OrderManagementService;
using DeToiServer.Services.PaymentService;
using DeToiServerCore.Common.Constants;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Web;

namespace DeToiServer.Controllers
{
    [Route("api/v1/vnpay")]
    [ApiController]
    public class VnPayController : ControllerBase
    {
        private readonly VnPayConfigModel _vnPayConfig;
        private readonly IFreelanceAccountService _freelancerService;
        private readonly IPaymentService _paymentService;
        private readonly ILogger<VnPayController> _logger;
        private readonly UnitOfWork _uow;

        public VnPayController(IOptions<VnPayConfigModel> vnPayConfig, IFreelanceAccountService freelancerService, IPaymentService paymentService, ILogger<VnPayController> logger, UnitOfWork uow)
        {
            _vnPayConfig = vnPayConfig.Value;
            _freelancerService = freelancerService;
            _paymentService = paymentService;
            _logger = logger;
            _uow = uow;
        }

        [HttpGet("test")]
        public ActionResult TestGw()
        {

            return Ok("Enter gateway");
        }

        [HttpGet("confirm-redirect")]
        public async Task<ActionResult> Confirm(Guid freelancerId, double amount)
        {
            var freelancer = await _freelancerService.GetByAccId(freelancerId);

            if (freelancer == null)
            {
                _logger.LogError($"Top-up for freelancer: {freelancerId} - {amount} unsuccessfully");
                return Redirect("https://detoi.company");
            }

            var updated = await _paymentService
                                    .UpdateFreelancerBalance(new UpdateFreelanceBalanceDto()
                                    {
                                        Id = freelancerId,
                                        Method = GlobalConstant.Payment.Card,
                                        WalletType = GlobalConstant.Payment.Wallet.System,
                                        Value = amount,
                                    });

            if (!await _uow.SaveChangesAsync())
            {
                _logger.LogError($"Top-up for freelancer: {freelancerId} - {amount} unsuccessfully: cannot update balance in database");
            }
            return Redirect("https://detoi.company");
        }

        public static string GuidEncodeHandler(string guidString)
        {
            if (!Guid.TryParse(guidString, out Guid guid))
            {
                throw new ArgumentException("Invalid GUID format.", nameof(guidString));
            }

            Random random = new Random();
            int randomNumber = random.Next(100); // Generates a random number between 0 and 9

            return $"{guidString}{randomNumber}";
        }

        public static string GuidDecodeHandler(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
            }

            var guidLength = Guid.NewGuid().ToString().Length;


            // Trim the last element
            return input.Substring(0, guidLength);
        }

        [HttpGet("vnpay")]
        public ActionResult PayWithVnPay([FromQuery] GetVnPayPaymentDto vnPayPaymentDto)
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
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + vnPayPaymentDto.FreelancerId);
            vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other
            vnpay.AddRequestData("vnp_ReturnUrl", $"{vnp_Returnurl}?freelancerId={vnPayPaymentDto.FreelancerId.ToString()}&amount={vnPayPaymentDto.Price}");
            vnpay.AddRequestData("vnp_TxnRef", GuidEncodeHandler(vnPayPaymentDto.FreelancerId.ToString())); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            Response.Redirect(paymentUrl);

            return Ok(new
            {
                RedirectUrl = paymentUrl
            });
        }

        [HttpGet("vnpay-confirm")]
        public async Task<ActionResult> PayWithVnPayConfirmWebHook()
        {
            string returnContent = string.Empty;
            bool isSuccess = false;
            var query = HttpContext.Request.Query;
            if (query.Count > 0)
            {
                string vnp_HashSecret = _vnPayConfig.HashSecret; //Secret key
                VnPayLibrary vnpay = new VnPayLibrary();
                foreach (var item in query)
                {
                    //get all querystring data
                    var key = item.Key;
                    var value = item.Value.FirstOrDefault();
                    if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_") && !string.IsNullOrEmpty(value))
                    {
                        vnpay.AddResponseData(key, value);
                    }
                }
                // Now you can use 'vnpay' to process the VnPayLibrary logic
                //Lay danh sach tham so tra ve tu VNPAY
                //vnp_TxnRef: Ma don hang merchant gui VNPAY tai command=pay    
                //vnp_TransactionNo: Ma GD tai he thong VNPAY
                //vnp_ResponseCode:Response code from VNPAY: 00: Thanh cong, Khac 00: Xem tai lieu
                //vnp_SecureHash: HmacSHA512 cua du lieu tra ve
                bool isGuidOrderId = Guid.TryParse(GuidDecodeHandler(vnpay.GetResponseData("vnp_TxnRef")), out Guid freelancerId);
                long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
                long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
                string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
                string vnp_SecureHash = vnpay.GetResponseData("vnp_SecureHash");
                bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
                if (checkSignature)
                {
                    //Cap nhat ket qua GD
                    //Yeu cau: Truy van vao CSDL cua  Merchant => lay ra duoc OrderInfo
                    //Giả sử OrderInfo lấy ra được như giả lập bên dưới
                    if (!isGuidOrderId)
                    {
                        returnContent = "{\"RspCode\":\"01\",\"Message\":\"Order not found\"}";
                        return Ok(returnContent);
                    }

                    var freelancer = await _freelancerService.GetById(freelancerId);//get from DB
                    //Kiem tra tinh trang Order
                    if (freelancer != null)
                    {
                        if (vnp_Amount > 0)
                        {
                            if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                            {
                                //Thanh toan thanh cong
                                _logger.LogInformation($"Successfully top-up for freelancerId={freelancerId}, VNPAY TranId={vnpayTranId}");
                                isSuccess = true;
                                var updated = await _paymentService
                                    .UpdateFreelancerBalance(new UpdateFreelanceBalanceDto()
                                    {
                                        Id = freelancerId,
                                        Method = GlobalConstant.Payment.Card,
                                        WalletType = GlobalConstant.Payment.Wallet.System,
                                        Value = vnp_Amount,
                                    });
                                await _uow.SaveChangesAsync();
                                _logger.LogInformation($"Nap: {vnp_Amount} thanh cong cho freelancer: {freelancerId}");
                                returnContent = "{\"RspCode\":\"00\",\"Message\":\"Confirm Success\"}";
                            }
                            else
                            {
                                _logger.LogInformation($"Unsuccessfully top-up for, FreelancerId={freelancerId}, VNPAY TranId={vnpayTranId},ResponseCode={vnp_ResponseCode}");
                                returnContent = "{\"RspCode\":\"01\",\"Message\":\"Error while confirming payment\"}";
                            }
                        }
                        else
                        {
                            _logger.LogInformation($"Nap: {vnp_Amount} khong thanh cong cho freelancer: {freelancerId} - Invalid amount error");
                            returnContent = "{\"RspCode\":\"04\",\"Message\":\"Invalid amount\"}";
                        }


                        if (!isSuccess)
                        {
                            _logger.LogInformation($"Nap: {vnp_Amount} khong thanh cong cho freelancer: {freelancerId}");
                        }
                    }
                    else
                    {
                        _logger.LogInformation($"Nap: {vnp_Amount} khong thanh cong cho freelancer: {freelancerId} - Not found freelancer");
                        returnContent = "{\"RspCode\":\"01\",\"Message\":\"Freelancer not found\"}";
                    }
                }
                else
                {
                    Console.WriteLine("Invalid signature, InputData={0}", HttpContext.Request.GetDisplayUrl());
                    returnContent = "{\"RspCode\":\"97\",\"Message\":\"Invalid signature\"}";
                }
            }
            else
            {
                _logger.LogInformation($"Nap tien khong thanh cong - Not found freelancer");
                returnContent = "{\"RspCode\":\"99\",\"Message\":\"Input data required\"}";
            }

            return Ok(returnContent);
        }

        //[HttpGet("test-vnpay-confirm")]
        //public ActionResult PayWithVnPayConfirmWebHook2()
        //{
        //    _messageBusClient.UpdateOrderPaymentStatus(new PaymentStatusUpdatedDto()
        //    {
        //        OrderId = Guid.Parse("3D0E9407-3D1E-402E-9FAC-3861E5FE8262"),
        //        PaymentStatus = PaymentStatus.Paid,
        //        Event = "PaymentStatusUpdated"
        //    });

        //    return Ok("Confirm payment succeeds");
        //}
    }
}
