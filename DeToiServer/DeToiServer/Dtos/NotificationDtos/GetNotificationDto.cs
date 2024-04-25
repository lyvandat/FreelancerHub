using DeToiServerCore.Models.Notifications;
using System.Collections.ObjectModel;

namespace DeToiServer.Dtos.NotificationDtos
{
    public class GetNotificationDto
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public IEnumerable<string> ExpoPushTokens { get; set; } = null!;
        public PushNotificationDataDto Data { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}
