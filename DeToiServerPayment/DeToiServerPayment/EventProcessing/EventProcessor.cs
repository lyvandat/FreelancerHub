using AutoMapper;
using DeToiServerPayment.Data;
using DeToiServerPayment.Dtos;
using DeToiServerPayment.Models;
using System.Text.Json;

namespace DeToiServerPayment.EventProcessing
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
                case OrderEventType.OrderPlaced:
                    await AddOrder(message);
                    break;
                default:
                    break;
            }
        }

        private OrderEventType DetermineEvent(string notifcationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notifcationMessage);

            switch (eventType?.Event)
            {
                case "OrderPlaced":
                    Console.WriteLine("--> Platform Published Event Detected");
                    return OrderEventType.OrderPlaced;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return OrderEventType.Undetermined;
            }
        }

        private async Task AddOrder(string orderPlacedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IOrderRepo>();

                var orderPublishedDto = JsonSerializer.Deserialize<OrderPlacedDto>(orderPlacedMessage);

                try
                {
                    var order = _mapper.Map<Order>(orderPublishedDto);
                    if (!repo.ExternalOrderExists(order.ExternalId))
                    {
                        repo.AddOrder(order);
                        await repo.SaveChangesAsync();
                        Console.WriteLine("--> Order added!");
                    }
                    else
                    {
                        Console.WriteLine("--> Order already exisits...");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Order to DB {ex.Message}");
                }
            }
        }
    }

    enum OrderEventType
    {
        OrderPlaced,
        Undetermined
    }
}
