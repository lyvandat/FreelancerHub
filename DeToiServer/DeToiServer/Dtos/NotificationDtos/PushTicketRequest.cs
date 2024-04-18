using DeToiServerCore.Common.Constants;
using Newtonsoft.Json;

namespace DeToiServer.Dtos.NotificationDtos
{
    public class PushNotificationDataDto
    {
        public string NotificationType { get; set; } = GlobalConstant.Notification.CustomerChooseThisFreelancer;

    }

    public class PushNotificationDto
    {
        public required List<string> ExpoPushTokens { get; set; }
        public required string Title { get; set; }
        public required string Body { get; set; }
        public string? SubTitle { get; set; }
        public PushNotificationDataDto? Data { get; set; }
    }


    #pragma warning disable CS8618
    [JsonObject(MemberSerialization.OptIn)]
    public class PushTicketRequest
    {
        [JsonProperty(PropertyName = "to")]
        public List<string> PushTo { get; set; }

        [JsonProperty(PropertyName = "data")]
        public object PushData { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string PushTitle { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string PushBody { get; set; }

        [JsonProperty(PropertyName = "ttl")]
        public int? PushTTL { get; set; }

        [JsonProperty(PropertyName = "expiration")]
        public int? PushExpiration { get; set; }

        [JsonProperty(PropertyName = "priority")]  //'default' | 'normal' | 'high'
        public string PushPriority { get; set; } = "default";

        [JsonProperty(PropertyName = "subtitle")]
        public string PushSubTitle { get; set; }

        [JsonProperty(PropertyName = "sound")] //'default' | null	
        public string PushSound { get; set; } = "default";

        [JsonProperty(PropertyName = "badge")]
        public int? PushBadgeCount { get; set; }

        [JsonProperty(PropertyName = "channelId")]
        public string PushChannelId { get; set; }

        [JsonProperty(PropertyName = "categoryId")]
        public string PushCategoryId { get; set; }
    }
}
