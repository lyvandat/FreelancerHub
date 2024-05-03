using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.ServiceStatusDtos;
using Newtonsoft.Json;

namespace DeToiServer.Dtos.RealTimeDtos
{
    public class UpdateOnMovingOrderStatusDto
    {
        public AddressDto? Address { get; set; }
        public Guid ServiceStatusId { get; set; } 
    }

    public class UpdateOrderStatusRealTimeDto
    {
        public AddressDto? Address { get; set; }
        public Guid ServiceStatusId { get; set; } // thay bang orderId
        public string CustomerPhone { get; set; } = string.Empty; // thay bang orderId
    }

    public class UpdateMovingStatusDto
    {
        public RealTimeAddressDto Address { get; set; } = null!;
        public Guid OrderId { get; set; }
    }

    public class SendFeasibleOrderFreelancerDto
    {
        public IEnumerable<string> FreelancerPhones { get; set; } = null!;
        public GetOrderDto OrderToSend { get; set; } = null!;
    }

    public class RealtimeResponseDto
    {

        [JsonProperty(PropertyName = "status")]
        public bool Status { get; set; } = true;

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; } = null!;

        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; } = null!;
    }
}
