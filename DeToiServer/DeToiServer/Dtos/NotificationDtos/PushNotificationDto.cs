﻿using DeToiServerCore.Common.Constants;

namespace DeToiServer.Dtos.NotificationDtos
{
    public class PushNotificationDataDto
    {
        public Guid NotificationId { get; set; }
        public string ActionKey { get; set; } = GlobalConstant.Notification.CustomerChooseThisFreelancer;
    }

    public class PushNotificationDto
    {
        public required List<string> ExpoPushTokens { get; set; }
        public required string Title { get; set; }
        public required string Body { get; set; }
        public string Sound { get; set; } = "default"; // 'default' | 'defaultCritical' | 'custom' | null
        public string SubTitle { get; set; } = string.Empty;
        public int? Badge { get; set; } = null;
        public required PushNotificationDataDto Data { get; set; } = new();
    }

    public class NotificationDto
    {
        public string NotificationType { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }

    public enum NotificationType
    {
        Information,
        Error,
        Warning
    }
}
