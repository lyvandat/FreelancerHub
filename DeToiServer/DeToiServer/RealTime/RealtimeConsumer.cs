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

        public RealtimeConsumer()
        {
            Connect().Wait();
        }

        public async Task SendMessageToFreelancer(PostOrderDto postOrderDto)
        {
            try
            {
                if (_connectionSignalR == null)
                {
                    Console.WriteLine("Cannot send real time messages due to connection error");
                    return;
                }
                await _connectionSignalR.InvokeAsync("SendMessageToFreelancer", postOrderDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} | {ex.StackTrace}");
            }
        }

        public async Task SendReceiveOrderMessageToFreelancer(FreelanceAccount freelancer, GetOrderDto? getOrderDto)
        {
            try
            {
                if (_connectionSignalR == null)
                {
                    Console.WriteLine("Cannot send real time messages due to connection error");
                    return;
                }

                if (getOrderDto == null)
                {
                    Console.WriteLine("Cannot send real time messages due to data error");
                    return;
                }

                await _connectionSignalR.InvokeAsync("SendReceiveOrderMessageToFreelancer", freelancer.Account.Phone, getOrderDto);
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
                if (_connectionSignalR == null)
                {
                    Console.WriteLine("Cannot send real time messages due to connection error");
                    return;
                }
                await _connectionSignalR.InvokeAsync("SendOrderStatusToCustomer", orderStatusRealTimeDto);
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
