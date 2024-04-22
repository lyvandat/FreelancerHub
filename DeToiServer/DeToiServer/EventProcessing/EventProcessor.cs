
using AutoMapper;
using DeToiServer.Dtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Services.OrderManagementService;
using System.Text.Json;

namespace DeToiServer.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public async Task ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case PaymentStatusEvent.PaymentStatusUpdated:
                    await UpdateOrderAndAddToPaymentHistory(message);
                    break;
                default:
                    break;
            }
        }

        PaymentStatusEvent DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch(eventType?.Event) 
            {
                case "PaymentStatusUpdated":
                    Console.WriteLine("--> Payment Status Updated Event Detected");
                    return PaymentStatusEvent.PaymentStatusUpdated;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return PaymentStatusEvent.Undetermined;
            }
        }

        private async Task UpdateOrderAndAddToPaymentHistory(string orderPlacedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IOrderManagementService>();

                var postPaymentStatusHistoryDto = JsonSerializer.Deserialize<PostPaymentStatusHistoryDto>(orderPlacedMessage);

                if (postPaymentStatusHistoryDto == null)
                {
                    Console.WriteLine("Payment status is null");
                    return;
                }

                try
                {
                    var updatedOrder = await service.UpdateStatusAndPostPaymentHistory(postPaymentStatusHistoryDto);

                    if (updatedOrder == null)
                    {
                        Console.WriteLine($"--> Could not add Order to DB: {postPaymentStatusHistoryDto.OrderId}");
                        return;
                    }

                    Console.WriteLine($"Payment status updated successfully: {postPaymentStatusHistoryDto.OrderId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Order to DB {ex.Message}");
                }
            }
        }
    }

    enum PaymentStatusEvent
    {
        PaymentStatusUpdated,
        Undetermined
    }
}
