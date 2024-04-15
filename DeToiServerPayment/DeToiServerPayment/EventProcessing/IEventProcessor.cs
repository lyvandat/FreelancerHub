namespace DeToiServerPayment.EventProcessing
{
    public interface IEventProcessor
    {
        Task ProcessEvent(string message);
    }
}
