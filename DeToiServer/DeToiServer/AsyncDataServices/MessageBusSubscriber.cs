﻿using DeToiServer.EventProcessing;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

namespace DeToiServer.AsyncDataServices
{
    public class MessageBusSubscriber : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IEventProcessor _eventProcessor;
        private IConnection? _connection;
        private IModel? _channel;
        private string? _queueName;

        public MessageBusSubscriber(IConfiguration configuration, IEventProcessor eventProcessor)
        {
            _configuration = configuration;
            _eventProcessor = eventProcessor;

            var factory = new ConnectionFactory() { HostName = _configuration["RabbitMQHost"], Port = int.Parse(_configuration["RabbitMQPort"] ?? "5672") };

            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
                _queueName = _channel.QueueDeclare().QueueName;
                _channel.QueueBind(queue: _queueName,
                    exchange: "trigger",
                    routingKey: "");

                Console.WriteLine("--> Listenting on the Message Bus...");

                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: Cannot create message bus connection: {ex.Message}");
            }
        }

        private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine("--> Connection Shutdown");
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            if (_channel != null)
            {
                var consumer = new EventingBasicConsumer(_channel);

                consumer.Received += (ModuleHandle, ea) =>
                {
                    Console.WriteLine("--> Event Received!");

                    var body = ea.Body;
                    var notificationMessage = Encoding.UTF8.GetString(body.ToArray());

                    _eventProcessor.ProcessEvent(notificationMessage);
                };

                _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
            }

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            if (_channel != null && _channel.IsOpen)
            {
                _channel.Close();
                _connection?.Close();
            }

            base.Dispose();
        }
    }
}
