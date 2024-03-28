using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using DeToiServer.Dtos.OrderDtos;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using DeToiServer.Dtos.RealTimeDtos;
using DeToiServerCore.Common.Helper;

namespace DeToiServer.RealTime
{
    public class RabbitMQConsumer
    {
        static HubConnection? _connectionSignalR;

        public RabbitMQConsumer()
        {
        }

        public void ReceiveMessageFromQ()
        {
            try
            {
                var factory = new ConnectionFactory() {
                    HostName = Helper.GetMessageQueueConnectionString(),
                    UserName = "user",
                    Password = "mypass",
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    Connect().Wait();

                    channel.QueueDeclare(queue: "order",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    var eventConsumer = new EventingBasicConsumer(channel);

                    eventConsumer.Received += EventConsumer_Received;

                    void EventConsumer_Received(object? sender, BasicDeliverEventArgs e)
                    {
                        var body = e.Body.ToArray();
                        var data = Encoding.UTF8.GetString(body);

                        // Add signalR real time handling here if we want asynchronous realtime communication
                        PostOrderDto? postOrder = JsonConvert.DeserializeObject<PostOrderDto>(data);
                        _connectionSignalR?.InvokeAsync("SendMessageToFreelancer", postOrder);
                        Console.WriteLine($"post order dto: {postOrder}");
                    }

                    channel.BasicConsume("order", true, eventConsumer);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} | {ex.StackTrace}");
            }
        }

        public void ReceiveOrderStatusFromQ()
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = Helper.GetMessageQueueConnectionString(),
                    UserName = "user",
                    Password = "mypass",
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    Connect().Wait();

                    channel.QueueDeclare(queue: "order-status",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    var eventConsumer = new EventingBasicConsumer(channel);

                    eventConsumer.Received += EventConsumer_Received;

                    void EventConsumer_Received(object? sender, BasicDeliverEventArgs e)
                    {
                        var body = e.Body.ToArray();
                        var data = Encoding.UTF8.GetString(body);

                        // Add signalR real time handling here if we want asynchronous realtime communication
                        UpdateOrderStatusRealTimeDto? orderStatus = JsonConvert.DeserializeObject<UpdateOrderStatusRealTimeDto>(data);
                        _connectionSignalR?.InvokeAsync("SendOrderStatusToCustomer", orderStatus);
                    }

                    channel.BasicConsume("order-status", true, eventConsumer);
                }

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
