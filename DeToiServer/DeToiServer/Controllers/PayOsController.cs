using Azure;
using DeToiServer.Dtos.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Net.payOS;
using Net.payOS.Types;

namespace DeToiServer.Controllers
{
    [Route("api/v1/payos")]
    [ApiController]
    public class PayOsController : ControllerBase
    {
        private readonly PayOS _payOS = new("_clientId", "_apiKey", "_checksum_key");

        [HttpPost("new-link")]
        public async Task<ActionResult<IEnumerable<RevGeoCodeResultDto>>> CreateNewPaymentLink()
        {
            
            int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
            ItemData item = new ItemData("Niềm Tin", 1, 5000);
            List<ItemData> items = new List<ItemData>();
            items.Add(item);
            PaymentData paymentData = new PaymentData(orderCode, 5000, "TestPay", items, "https://localhost:7140/api/v1/payos/failed", "https://localhost:7140/api/v1/payos/success");

            CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

            return Ok(createPayment);
            
        }

        [HttpGet("order")]
        public async Task<IActionResult> GetOrder([FromRoute] int orderId)
        {
            PaymentLinkInformation paymentLinkInformation = await _payOS.getPaymentLinkInfomation(orderId);

            return Ok(paymentLinkInformation);
        }

        [HttpDelete("order")]
        public async Task<IActionResult> CancelOrder([FromRoute] int orderId)
        {
            PaymentLinkInformation paymentLinkInformation = await _payOS.cancelPaymentLink(orderId);

            return Ok(paymentLinkInformation);
        }

        [HttpGet("success")]
        public async Task<ActionResult> SuccessOrder([FromQuery] WebhookDataDto receive)
        {
            return Ok(receive);
        }

        [HttpGet("failed")]
        public async Task<ActionResult> FailedOrder([FromQuery] WebhookDataDto receive)
        {
            return Ok(receive);
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Data
        {
            public int orderCode { get; set; }
            public int amount { get; set; }
            public string description { get; set; }
            public string accountNumber { get; set; }
            public string reference { get; set; }
            public string transactionDateTime { get; set; }
            public string currency { get; set; }
            public string paymentLinkId { get; set; }
            public string code { get; set; }
            public string desc { get; set; }
            public string counterAccountBankId { get; set; }
            public string counterAccountBankName { get; set; }
            public string counterAccountName { get; set; }
            public string counterAccountNumber { get; set; }
            public string virtualAccountName { get; set; }
            public string virtualAccountNumber { get; set; }
        }

        public class WebhookDataDto
        {
            public string code { get; set; }
            public string desc { get; set; }
            public Data data { get; set; }
            public string signature { get; set; }
        }
    }
}
