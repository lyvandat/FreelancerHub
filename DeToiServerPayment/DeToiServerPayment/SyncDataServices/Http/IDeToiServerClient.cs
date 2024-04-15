namespace DeToiServerPayment.SyncDataServices.Http
{
    public interface IDeToiServerClient
    {
        Task SendOrderPaymentStatus(Guid orderId);
    }
}
