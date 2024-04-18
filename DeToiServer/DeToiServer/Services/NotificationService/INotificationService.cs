using DeToiServer.Dtos.NotificationDtos;

namespace DeToiServer.Services.NotificationService
{
    public interface INotificationService
    {
        Task<PushTicketResponse?> PushSendAsync(PushTicketRequest pushTicketRequest);
        Task<PushReceiptResponse?> PushGetReceiptsAsync(PushReceiptRequest pushReceiptRequest);
    }
}
