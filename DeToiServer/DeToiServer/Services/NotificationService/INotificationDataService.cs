using DeToiServer.Dtos.NotificationDtos;

namespace DeToiServer.Services.NotificationService
{
    public interface INotificationDataService
    {
        Task<IEnumerable<GetNotificationDto>> GetAllNotificationByAcountId(Guid accountId);
    }
}
