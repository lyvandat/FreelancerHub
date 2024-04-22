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
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly VnPayConfigModel _vnPayConfig;
        private readonly IOrderRepo _orderRepo;
        private readonly IMessageBusClient _messageBusClient;

        public PaymentController(IOptions<VnPayConfigModel> vnPayConfig, IOrderRepo orderRepo, IMessageBusClient messageBusClient)
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
                bool isGuidOrderId = Guid.TryParse(vnpay.GetResponseData("vnp_TxnRef"), out Guid orderId);
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

                    var order = await _orderRepo.GetOrderById(orderId);//get from DB
                    //Kiem tra tinh trang Order
                    if (order != null)
                    {
                        if (vnp_Amount == order.EstimatedPrice)
                        {
                            if (order.PaymentStatus == PaymentStatus.NotPaid)
                            {
                                if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                                {
                                    //Thanh toan thanh cong
                                    Console.WriteLine("Thanh toan thanh cong, OrderId={0}, VNPAY TranId={1}", orderId,
                                        vnpayTranId);
                                    isSuccess = true;
                                    _messageBusClient.UpdateOrderPaymentStatus(new PaymentStatusUpdatedDto()
                                    {
                                        OrderId = order.ExternalId,
                                        PaymentStatus = PaymentStatus.Paid,
                                        Event = "PaymentStatusUpdated"
                                    });

                                    returnContent = "{\"RspCode\":\"00\",\"Message\":\"Confirm Success\"}";
                                }
                                else
                                {
                                    //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
                                    //  displayMsg.InnerText = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
                                    Console.WriteLine("Thanh toan loi, OrderId={0}, VNPAY TranId={1},ResponseCode={2}",
                                        orderId,
                                        vnpayTranId, vnp_ResponseCode);
                                    returnContent = "{\"RspCode\":\"01\",\"Message\":\"Error while confirming payment\"}";
                                }
                            }
                            else
                            {
                                returnContent = "{\"RspCode\":\"02\",\"Message\":\"Payment status is not 'not paid'\"}";
                            }
                        }
                        else
                        {
                            returnContent = "{\"RspCode\":\"04\",\"Message\":\"Invalid amount\"}";
                        }


                        if (!isSuccess)
                        {
                            _messageBusClient.UpdateOrderPaymentStatus(new PaymentStatusUpdatedDto()
                            {
                                OrderId = order.ExternalId,
                                PaymentStatus = PaymentStatus.Failed,
                                Event = "PaymentStatusUpdated"
                            });
                        }
                    }
                    else
                    {
                        returnContent = "{\"RspCode\":\"01\",\"Message\":\"Order not found\"}";
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
                returnContent = "{\"RspCode\":\"99\",\"Message\":\"Input data required\"}";
            }

            return Ok(returnContent);
        }

        [HttpGet("test-vnpay-confirm")]
        public ActionResult PayWithVnPayConfirmWebHook2()
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
