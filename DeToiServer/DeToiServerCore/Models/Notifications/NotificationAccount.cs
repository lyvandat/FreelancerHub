using DeToiServerCore.Models.Accounts;

namespace DeToiServerCore.Models.Notifications
{
    public class NotificationAccount
    {
        public Guid NotificationId { get; set; }
        public required Notification Notification { get; set; }
        public Guid AccountId { get; set; }
        public required Account Account { get; set; }
    }
}
