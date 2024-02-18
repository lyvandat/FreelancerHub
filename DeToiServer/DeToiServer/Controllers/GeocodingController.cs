using DeToiServer.Dtos.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/geo-code")]
    public class GeocodingController : ControllerBase
    {
        private readonly UnitOfWork _uow;
        private readonly string _apiKey;

        public GeocodingController(UnitOfWork uow, IOptions<ApplicationSecretSettings> appSecret)
        {
            _uow = uow;
            _apiKey = (appSecret.Value ?? throw new ArgumentException(null, nameof(appSecret))).GeoCoding.ApiKey;
        }

        [HttpGet("reverse")]
        public async Task<ActionResult<GeoCodeResponseDto>> GetRevGeoCodeInfo(
            [FromQuery, Required] double latitude = 10.7627917,
            [FromQuery, Required] double longitude = 106.6813989
        )
        {
            //GeoCodeResult? rawResult = null;
            //GeoCodeResultDto? result = null;
            //var handler = new HttpClientHandler();

            //handler.ServerCertificateCustomValidationCallback +=
            //    (sender, certificate, chain, errors) =>
            //    {
            //        return true;
            //    };

            //using (var httpClient = new HttpClient(handler))
            //{
            //    var httpRequestMessage = new HttpRequestMessage
            //    {
            //        RequestUri = new Uri($"https://geocode.maps.co/reverse?lat={latitude}&lon={longitude}&api_key={_apiKey}"),
            //        Method = HttpMethod.Get,
            //        Headers = {
            //            { HttpRequestHeader.Accept.ToString(), "application/json" },
            //        },
            //        //Content = new StringContent(JsonConvert.SerializeObject(svm))
            //    };

            //    using var response = await httpClient.SendAsync(httpRequestMessage);

            //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        rawResult = JsonConvert.DeserializeObject<GeoCodeResult>(apiResponse);
            //        result = _mapper.Map<GeoCodeResultDto>(rawResult?.Address);
            //        result.Display_name = await ToVieLocation(rawResult!.Display_name!);
            //        result.Latt = latitude;
            //        result.Longt = longitude;
            //    }
            //}

            //if (result is null)
            //{
            //    return NotFound(new
            //    {
            //        message = "Không tìm thấy vị trí dựa trên tọa độ đã cung cấp."
            //    });
            //}

            await Task.Delay(10);

            return Ok(new
            {
                message = "test"
            });
        }
    }
}
