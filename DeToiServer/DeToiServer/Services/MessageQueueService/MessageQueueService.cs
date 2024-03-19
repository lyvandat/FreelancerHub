using DeToiServer.Dtos.FreelanceDtos;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace DeToiServer.Services.MessageQueueService
{
    public class MessageQueueService : IMessageQueueService
    {
        public void SendFreelancerDetailToCustomer(Guid orderId, GetFreelanceMatchingDto freelanceDto)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            var orderIdString = orderId.ToString();
            channel.QueueDeclare(orderIdString);

            var json = JsonConvert.SerializeObject(freelanceDto);
            var bytes = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: orderIdString, body: bytes);
        }
    }
}
