using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.ServiceStatusDtos;

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
        public RealTimeAddressDto Address { get; set; }
        public Guid OrderId { get; set; }
    }

    public class SendFeasibleOrderFreelancerDto
    {
        public IEnumerable<string> FreelancerPhones { get; set; } = null!;
        public GetOrderDto OrderToSend { get; set; } = null!;
    }

    public class RealtimeResponseDto
    {
        public bool Status { get; set; } = true;
        public string Message { get; set; } = null!;
        public object Data { get; set; } = null!;
    }
}
