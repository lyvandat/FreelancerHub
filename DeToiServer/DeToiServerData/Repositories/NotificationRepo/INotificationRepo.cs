using DeToiServerCore.Models.Notifications;

namespace DeToiServerData.Repositories.NotificationRepo
{
    public interface INotificationRepo : IRepository<Notification>
    {
        Task<IEnumerable<Notification>> RemoveOldNotificationsAsync();
        Task<IEnumerable<NotificationAccount>> GetAllNotificationByAccountIdAsync(Guid accountId);
    }
}
