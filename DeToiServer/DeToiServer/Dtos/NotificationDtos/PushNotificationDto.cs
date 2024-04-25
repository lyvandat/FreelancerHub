using DeToiServerCore.Common.Constants;

namespace DeToiServer.Dtos.NotificationDtos
{
    public class PushNotificationDataDto
    {// ActionKey
        public string ActionKey { get; set; } = GlobalConstant.Notification.CustomerChooseThisFreelancer;
    }

    public class PushNotificationDto
    {
        public required List<string> ExpoPushTokens { get; set; }
        public required string Title { get; set; }
        public required string Body { get; set; }
        public required PushNotificationDataDto Data { get; set; } = new();
    }
}
