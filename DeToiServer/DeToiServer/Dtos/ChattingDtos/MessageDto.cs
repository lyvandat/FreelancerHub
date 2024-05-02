using DeToiServerCore.Common.Constants;
using Newtonsoft.Json;

namespace DeToiServer.Dtos.ChattingDtos
{
    public class MessageDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; } = null!;

        [JsonProperty(PropertyName = "time")]
        public DateTime Time { get; set; }

        [JsonProperty(PropertyName = "sender")]
        public MessageSenderDto Sender { get; set; } = null!;

        [JsonProperty(PropertyName = "isSystem")]
        public bool IsSystem { get; set; } = false;
        [JsonProperty(PropertyName = "sender")]
        public string? Image { get; set; } = null;
    }

    public class MessagePreviewDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; } = null!;

        [JsonProperty(PropertyName = "time")]
        public DateTime Time { get; set; }
    }

    public class MessageSenderDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; set; } = null!;

        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; } = null!;

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; } = GlobalConstant.ChatConst.Me;
    }

    public class GetMessagePreviewDto
    {
        [JsonProperty(PropertyName = "sender")]
        public Guid ConversationId { get; set; }

        [JsonProperty(PropertyName = "sender")]
        public MessageSenderDto Sender { get; set; } = null!;

        [JsonProperty(PropertyName = "latestMessage")]
        public MessagePreviewDto LatestMessage { get; set; } = null!;
    }

    public class PostSendMessageDto
    {
        public Guid SendTo { get; set; }
        public string Content { get; set; } = null!;
    }
}
