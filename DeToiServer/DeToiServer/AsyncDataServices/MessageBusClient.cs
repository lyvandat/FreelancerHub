﻿using DeToiServer.Dtos.OrderDtos;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace DeToiServer.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MessageBusClient> _logger;
        private readonly IConnection? _connection;
        private readonly IModel? _channel;

        public MessageBusClient(IConfiguration configuration, ILogger<MessageBusClient> logger)
        {
            _configuration = configuration;
            _logger = logger;
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"] ?? "5672")
            };

            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

                _logger.LogInformation("--> Connected to MessageBus");

            }
            catch (Exception ex)
            {
                _logger.LogError($"--> Could not connect to the Message Bus: {ex.Message}");
            }
        }

        public void PublishNewOrder(OrderPlacedDto orderPlacedDto)
        {
            var message = JsonSerializer.Serialize(orderPlacedDto);

            if (_connection != null && _connection.IsOpen)
            {
                _logger.LogInformation("--> RabbitMQ Connection Open, sending message...");
                SendMessage(message);
            }
            else
            {
                _logger.LogInformation("--> RabbitMQ connections closed, not sending");
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "trigger",
                            routingKey: "",
                            basicProperties: null,
                            body: body);
            _logger.LogInformation($"--> We have sent {message}");
        }

        public void Dispose()
        {
            _logger.LogInformation("MessageBus Disposed");
            if (_channel != null && _channel.IsOpen)
            {
                _channel.Close();
                _connection?.Close();
            }
        }

        private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            _logger.LogInformation("--> RabbitMQ Connection Shutdown");
        }
    }
}
