using AutoMapper;
using DeToiServer.Dtos.LocationDtos;
using DeToiServer.Dtos.NotificationDtos;
using DeToiServerCore.Models.Notifications;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace DeToiServer.Services.NotificationService
{
    public class NotificationService : INotificationService
    {
        private const string _expoBackendHost = "https://exp.host";
        private const string _pushSendPath = "/--/api/v2/push/send";
        private const string _pushGetReceiptsPath = "/--/api/v2/push/getReceipts";

        //Make this static to avoid socket saturation and limit concurrent server connections to 6, but only for instances of this class.
        private static readonly HttpClientHandler _httpHandler = new() { MaxConnectionsPerServer = 6 };
        private static readonly HttpClient _httpClient = new(_httpHandler);

        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public NotificationService(
            IMapper mapper,
            IServiceProvider serviceProvider
        )
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;

            _httpClient.BaseAddress = new Uri(_expoBackendHost);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<PushTicketResponse?> PushNotificationAsync(PushNotificationDto notificationDto, IEnumerable<Guid> accountIds)
        {
            // Resolve UnitOfWork within the method
            using (var scope = _serviceProvider.CreateScope())
            {
                UnitOfWork _unitOfWork = scope.ServiceProvider.GetRequiredService<UnitOfWork>();

                var notificationId = Guid.NewGuid();
                notificationDto.Data.NotificationId = notificationId;
                var notiToAdd = _mapper.Map<Notification>(notificationDto);

                notiToAdd.NotificationAccounts = [];
                notiToAdd.Id = notificationId;

                foreach (var accId in accountIds)
                {
                    notiToAdd.NotificationAccounts.Add(new()
                    {
                        NotificationId = notiToAdd.Id,
                        Notification = null!,
                        AccountId = accId,
                        Account = null!
                    });
                }

                await _unitOfWork.NotificationRepo.CreateAsync(notiToAdd);
                await _unitOfWork.SaveChangesAsync();
            }

            var result = await PushSendAsync(_mapper.Map<PushTicketRequest>(notificationDto));

            return result;
        }

        public async Task<PushTicketResponse?> PushSendAsync(PushTicketRequest pushTicketRequest)
        {
            var ticketResponse = await PostAsync<PushTicketRequest, PushTicketResponse>(pushTicketRequest, _pushSendPath);
            return ticketResponse;
        }

        public async Task<PushReceiptResponse?> PushGetReceiptsAsync(PushReceiptRequest pushReceiptRequest)
        {
            var receiptResponse = await PostAsync<PushReceiptRequest, PushReceiptResponse>(pushReceiptRequest, _pushGetReceiptsPath);
            return receiptResponse;
        }

        public async Task<U?> PostAsync<T, U>(T requestObj, string path) where T : new()
        {

            var serializedRequestObj = JsonConvert.SerializeObject(requestObj, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var requestBody = new StringContent(serializedRequestObj, System.Text.Encoding.UTF8, "application/json");
            var responseBody = default(U);
            var response = await _httpClient.PostAsync(path, requestBody);

            if (response.IsSuccessStatusCode)
            {
                var rawResponseBody = await response.Content.ReadAsStringAsync();
                responseBody = JsonConvert.DeserializeObject<U>(rawResponseBody);
            }

            return responseBody;
        }
    }
}
