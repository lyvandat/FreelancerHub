using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.RealTimeDtos;
using DeToiServerCore.Common.Helper;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace DeToiServer.RealTime
{
    public class RabbitMQProducer
    {
        public RabbitMQProducer()
        {
        }

        public bool PushMessageToQ(PostOrderDto postOrderDto)
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
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "order",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                        var postOrderData = JsonConvert.SerializeObject(postOrderDto);
                        var messageBody = Encoding.UTF8.GetBytes(postOrderData);

                        channel.BasicPublish(exchange: "", routingKey: "order", body: messageBody, basicProperties: null);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} | {ex.StackTrace}");
                return false;
            }
        }

        public bool PushOrderStatusToQ(UpdateOrderStatusRealTimeDto orderStatus)
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
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "order-status",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                        var postOrderData = JsonConvert.SerializeObject(orderStatus);
                        var messageBody = Encoding.UTF8.GetBytes(postOrderData);

                        channel.BasicPublish(exchange: "", routingKey: "order-status", body: messageBody, basicProperties: null);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} | {ex.StackTrace}");
                return false;
            }
        }
    }
}
