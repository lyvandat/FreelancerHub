namespace DeToiServer.EventProcessing
{
    public interface IEventProcessor
    {
        Task ProcessEvent(string message);
    }
}
