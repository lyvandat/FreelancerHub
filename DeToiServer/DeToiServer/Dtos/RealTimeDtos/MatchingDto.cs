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
        public Guid ServiceStatusId { get; set; }
        public string CustomerPhone { get; set; } = string.Empty;
    }

    public class SendFeasibleOrderFreelancerDto
    {
        public IEnumerable<string> FreelancerPhones { get; set; } = null!;
        public GetOrderDto OrderToSend { get; set; } = null!;
    }
}
