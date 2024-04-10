using DeToiServerCore.Enums;

namespace DeToiServerCore.Models.Notifications
{
    public class NotificationContent : ModelBase
    {
        public string Title { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string PreviewImage { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }
        public Role Role { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? FreelancerId { get; set; }
    }

    public class Notification : ModelBase
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public ICollection<string>? Images { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }
        public Role Role { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? FreelancerId { get; set; }
    }
}
