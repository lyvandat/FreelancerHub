using DeToiServerPayment.Dtos;

namespace DeToiServerPayment.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void UpdateOrderPaymentStatus(PaymentStatusUpdatedDto paymentStatusDto);
    }
}
