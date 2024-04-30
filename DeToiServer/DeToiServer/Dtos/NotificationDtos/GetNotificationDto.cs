using DeToiServerCore.Models.Notifications;
using System.Collections.ObjectModel;

namespace DeToiServer.Dtos.NotificationDtos
{
    public class NotificationContentDto
    {
        public PushNotificationDataDto Data { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
        public bool AutoDismiss { get; set; } = true;
        public int? Badge { get; set; } = null;
        public string Sound { get; set; } = "default";
        public bool Sticky { get; set; } = true;
        public string Subtitle { get; set; } = string.Empty;
    }

    public class NotificationRequestDto
    {
        public NotificationContentDto Content { get; set; } = null!;
        public string? Identifier { get; set; } = null;
        public string? Trigger { get; set; } = null;
    }

    public class GetNotificationDto
    {
        public long Date { get; set; }
        public NotificationRequestDto Request { get; set; } = null!;
        
    }
}
