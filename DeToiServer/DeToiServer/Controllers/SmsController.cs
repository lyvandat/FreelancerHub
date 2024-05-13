using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace DeToiServer.Controllers
{
    [Route("api/v1/sms")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<SmsController> _logger;

        public class SmsRequestDto
        {
            public string Username { get; set; } = "LYVANDAT03102002@GMAIL.COM";
            public string Pass { get; set; } = "onesms";
            public string Key { get; set; } = "4C5956414E444154303331303230303240474D41494C2E434F4D4F4E45534D53";
            public string Phonesend { get; set; } = string.Empty;
            public string Smsid { get; set; } = "204638";
            public string Param { get; set; } = string.Empty;
            public string Sender { get; set; } = "0901800016";
        }

        public SmsController(IMapper mapper, IHttpClientFactory httpClientFactory, ILogger<SmsController> logger)
        {
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendSms(SmsRequestDto request)
        {
            // Validate and process the query parameters.

            // Construct the URL with the parameters.
            var apiUrl = $"http://210.211.108.20:9999/onsmsapi/sendsms.jsp" +
                         $"?username={request.Username}" +
                         $"&pass={request.Pass}" +
                         $"&key={request.Key}" +
                         $"&phonesend={request.Phonesend}" +
                         $"&smsid={request.Smsid}" +
                         $"&param={request.Param}" +
                         $"&sender={request.Sender}";

            // Create an HttpClient instance.
            using var httpClient = new HttpClient();

            try
            {
                // Send the GET request.
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    
                    if (content == "1")
                    {
                        return Ok(new
                        {
                            Message = "Mã xác thực đang được gửi đến số điện thoại của bạn"
                        });
                    }
                    else
                    {
                        _logger.LogError($"Error code from SMS Provider: {content}");
                        _logger.LogError($"Sms request url: {apiUrl}");
                        return BadRequest(new
                        {
                            Message = "Đã có lỗi trong quá trình gửi tin nhắn xác thực"
                        });
                    }
                }
                else
                {
                    _logger.LogError($"Error status code from SMS Provider: {response.StatusCode}");
                    _logger.LogError($"Sms request url: {apiUrl}");
                    return BadRequest(new
                    {
                        Message = "Đã có lỗi trong quá trình gửi tin nhắn xác thực"
                    });
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle exceptions (e.g., network issues).
                _logger.LogError($"Error when sending SMS: {ex.Message}");
                return StatusCode(500, new { Message = "Đã có lỗi trong quá trình gửi tin nhắn xác thực" });
            }
        }
    }
}
