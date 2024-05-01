using RabbitMQ.Client.Events;
using DeToiServer.Dtos.OrderDtos;
using Microsoft.AspNetCore.SignalR.Client;
using DeToiServer.Dtos.RealTimeDtos;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models.Accounts;

namespace DeToiServer.RealTime
{
    public class RealtimeConsumer
    {
        static HubConnection? _connectionSignalR;
        private readonly ILogger<RealtimeConsumer> _logger;
        readonly IConfiguration _configuration;

        public RealtimeConsumer(IConfiguration configuration, ILogger<RealtimeConsumer> logger)
        {
            _logger = logger;
            _configuration = configuration;

            try
            {
                Connect(string.Empty).Wait();
            }
            catch(Exception ex)
            {
                Connect("http://127.0.0.1:8000").Wait();
                _logger.LogError($"ERROR: Cannot connect to real time endpoints: {ex.Message}");
            }
        }

        public async Task SendMessageToFreelancer(PostOrderDto postOrderDto)
        {
            try
            {
                if (_connectionSignalR == null)
                {
                    _logger.LogError("Cannot send real time messages due to connection error");
                    return;
                }
                await _connectionSignalR.InvokeAsync("SendMessageToFreelancer", postOrderDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} | {ex.StackTrace}");
            }
        }

        public async Task SendReceiveOrderMessageToFreelancer(FreelanceAccount freelancer, GetOrderDto? getOrderDto)
        {
            try
            {
                if (_connectionSignalR == null)
                {
                    _logger.LogError("Cannot send real time messages due to connection error");
                    return;
                }

                if (getOrderDto == null)
                {
                    _logger.LogError("Cannot send real time messages due to data error");
                    return;
                }

                await _connectionSignalR.InvokeAsync("SendReceiveOrderMessageToFreelancer", freelancer.Account.Phone, getOrderDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} | {ex.StackTrace}");
            }
        }

        public async Task SendOrderStatusToCustomer(UpdateOrderStatusRealTimeDto orderStatusRealTimeDto)
        {
            try
            {
                if (_connectionSignalR == null)
                {
                    _logger.LogError("Cannot send real time messages due to connection error");
                    return;
                }
                await _connectionSignalR.InvokeAsync("SendOrderStatusToCustomer", orderStatusRealTimeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} | {ex.StackTrace}");
            }
        }

        public async Task Connect(string newTry)
        {
            // build deployment: _configuration["RealTimeHub"] ?? Helper.GetDockerHostUrl()
            _connectionSignalR = new HubConnectionBuilder()
               .WithUrl(string.IsNullOrEmpty(newTry) ? Helper.GetRealtimeConnectionString() : newTry)
               .Build();
            await _connectionSignalR.StartAsync();
        }
    }
}
