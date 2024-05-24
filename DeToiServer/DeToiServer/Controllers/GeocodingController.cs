using AutoMapper;
using DeToiServer.Dtos.LocationDtos;
using DeToiServerCore.Common.Helper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/geo-code")]
    public class GeocodingController : ControllerBase
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly string _apiKey;

        public GeocodingController(UnitOfWork uow, IOptions<ApplicationSecretSettings> appSecret, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
            _apiKey = appSecret.Value.GeoCoding == null ? Helper.GetGeocodingApiKey() : appSecret.Value.GeoCoding.ApiKey;
        }

        [HttpGet("reverse")]
        public async Task<ActionResult<IEnumerable<RevGeoCodeResultDto>>> GetRevGeoCodeInfo(
            [FromQuery, Required] double lat = 10.7625844,
            [FromQuery, Required] double lon = 106.68168516587875
        )
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                return NotFound(new
                {
                    message = "[Server] Không tìm thấy api key cho dịch vụ này (Geocoding)."
                });
            }

            IEnumerable<RevGeoCodeResultDto> result = [];

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback +=
                (sender, certificate, chain, errors) =>
                {
                    return true;
                };

            var requestUrl = new StringBuilder("https://rsapi.goong.io/geocode");
            requestUrl.Append($"?latlng={lat},{lon}&api_key={_apiKey}");

            using (var httpClient = new HttpClient(handler))
            {
                var httpRequestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri(requestUrl.ToString()),
                    Method = HttpMethod.Get,
                    Headers = {
                        //{ HttpRequestHeader.Accept.ToString(), "application/json" },
                    },
                    //Content = new StringContent(JsonConvert.SerializeObject(svm))
                };

                using var response = await httpClient.SendAsync(httpRequestMessage);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var rawResult = JsonConvert.DeserializeObject<GeoCodeResponseDto>(apiResponse);

                    if (rawResult != null)
                    {
                        result = _mapper.Map<IEnumerable<RevGeoCodeResultDto>>(rawResult.Results);
                    }
                }
                else
                {
                    var res = await response.Content.ReadAsStringAsync();
                    var error = JsonConvert.DeserializeObject<GeoCodeErrorResponseDto>(res);
                    return StatusCode(500, new
                    {
                        Message = error == null
                            ? "Lỗi dịch vụ Geocoding"
                            : error.Error == null ? "Lỗi dịch vụ Geocoding" : error.Error.Message
                    });
                }
            }

            if (!result.Any())
            {
                return NotFound(new
                {
                    message = "Không tìm thấy vị trí dựa trên tọa độ đã cung cấp."
                });
            }

            return Ok(result);
        }

        [HttpGet("forward")]
        public async Task<ActionResult<IEnumerable<GeoCodeResultDto>>> GetGeoCodeInfo(
            [FromQuery, Required] string search
        )
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                return NotFound(new
                {
                    message = "[Server] Không tìm thấy api key cho dịch vụ này (Geocoding)."
                });
            }

            IEnumerable<GeoCodeResultDto> result = [];

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback +=
                (sender, certificate, chain, errors) =>
                {
                    return true;
                };

            var requestUrl = new StringBuilder("https://rsapi.goong.io/geocode");
            requestUrl.Append($"?address={search}&api_key={_apiKey}");

            using (var httpClient = new HttpClient(handler))
            {
                var httpRequestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri(requestUrl.ToString()),
                    Method = HttpMethod.Get,
                    Headers = {
                        //{ HttpRequestHeader.Accept.ToString(), "application/json" },
                    },
                    //Content = new StringContent(JsonConvert.SerializeObject(svm))
                };

                using var response = await httpClient.SendAsync(httpRequestMessage);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var rawResult = JsonConvert.DeserializeObject<GeoCodeResponseDto>(apiResponse);

                    if (rawResult != null)
                    {
                        result = _mapper.Map<IEnumerable<GeoCodeResultDto>>(rawResult.Results);
                    }
                }
                else
                {
                    var res = await response.Content.ReadAsStringAsync();
                    var error = JsonConvert.DeserializeObject<GeoCodeErrorResponseDto>(res);
                    return StatusCode(500, new
                    {
                        Message = error == null 
                            ? "Lỗi dịch vụ Geocoding" 
                            : error.Error == null ? "Lỗi dịch vụ Geocoding" : error.Error.Message
                    });
                }
            }

            if (!result.Any())
            {
                return NotFound(new
                {
                    message = "Không tìm thấy vị trí dựa trên chuỗi tìm kiếm cung cấp."
                });
            }

            return Ok(result);
        }
    }
}
