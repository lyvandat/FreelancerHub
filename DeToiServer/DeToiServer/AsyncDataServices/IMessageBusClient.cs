using DeToiServer.Dtos.OrderDtos;

namespace DeToiServer.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewOrder(OrderPlacedDto orderPlacedDto);
    }
}
