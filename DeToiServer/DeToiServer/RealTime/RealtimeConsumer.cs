﻿using RabbitMQ.Client.Events;
using DeToiServer.Dtos.OrderDtos;
using Microsoft.AspNetCore.SignalR.Client;
using DeToiServer.Dtos.RealTimeDtos;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models.Accounts;
using DeToiServer.Dtos.ChattingDtos;

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
                Connect().Wait();
                _logger.LogInformation("Connect to real time hub successfully!");
            }
            catch(Exception ex)
            {
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

        public async Task SendReceiveOrderMessageToFreelancer(FreelanceAccount freelancer, Guid orderId)
        {
            try
            {
                if (_connectionSignalR == null)
                {
                    _logger.LogError("Cannot send real time messages due to connection error");
                    return;
                }

                await _connectionSignalR.InvokeAsync("SendReceiveOrderMessageToFreelancer", freelancer.Account.CombinedPhone, orderId);
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

        public async Task SendFeasibleOrderToFreelancer(SendFeasibleOrderFreelancerDto orderToSend)
        {
            try
            {
                if (_connectionSignalR == null)
                {
                    _logger.LogError("Cannot send real time messages due to connection error");
                    return;
                }
                await _connectionSignalR.InvokeAsync("SendFeasibleOrderToFreelancer", orderToSend);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} | {ex.StackTrace}");
            }
        }

        public async Task SendRealtimeMessageToAccount(PostSendMessageRealtimeDto message)
        {
            try
            {
                if (_connectionSignalR == null)
                {
                    _logger.LogError("Cannot send real time messages due to connection error");
                    return;
                }
                await _connectionSignalR.InvokeAsync("SendChatMessageToAccount", message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} | {ex.StackTrace}");
            }
        }

        public async Task Connect()
        {
            // build deployment: _configuration["RealTimeHub"] ?? Helper.GetDockerHostUrl()
            _connectionSignalR = new HubConnectionBuilder()
               .WithUrl(Helper.GetRealtimeConnectionString())
               .Build();
            await _connectionSignalR.StartAsync();
        }
    }
}
