using Newtonsoft.Json;

namespace DeToiServer.Dtos.NotificationDtos
{
    #pragma warning disable CS8618
    [JsonObject(MemberSerialization.OptIn)]
    public class PushReceiptRequest
    {
        [JsonProperty(PropertyName = "ids")]
        public List<string> PushTicketIds { get; set; }
    }
}
