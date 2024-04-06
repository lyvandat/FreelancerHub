using RabbitMQ.Client.Events;
using DeToiServer.Dtos.OrderDtos;
using Microsoft.AspNetCore.SignalR.Client;
using DeToiServer.Dtos.RealTimeDtos;
using DeToiServerCore.Common.Helper;

namespace DeToiServer.RealTime
{
    public class RealtimeConsumer
    {
        static HubConnection? _connectionSignalR;

        public RealtimeConsumer()
        {
        }

        public async Task SendMessageToFreelancer(PostOrderDto postOrderDto)
        {
            try
            {
                await Connect();
                _connectionSignalR?.InvokeAsync("SendMessageToFreelancer", postOrderDto);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} | {ex.StackTrace}");
            }
        }

        public async Task SendOrderStatusToCustomer(UpdateOrderStatusRealTimeDto orderStatusRealTimeDto)
        {
            try
            {
                await Connect();
                _connectionSignalR?.InvokeAsync("SendOrderStatusToCustomer", orderStatusRealTimeDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} | {ex.StackTrace}");
            }
        }

        public static async Task Connect()
        {
            _connectionSignalR = new HubConnectionBuilder()
               .WithUrl(Helper.GetDockerHostUrl())
               .Build();
            await _connectionSignalR.StartAsync();
        }
    }
}
