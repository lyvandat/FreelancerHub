using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.ServiceStatusDtos;

namespace DeToiServer.Dtos.RealTimeDtos
{
    public class UpdateOnMovingOrderStatusDto
    {
        public AddressDto? Address { get; set; }
        public Guid ServiceStatusId { get; set; } 
    }

    public class UpdateOnMovingOrderStatusRealTimeDto
    {
        public AddressDto? Address { get; set; }
        public Guid ServiceStatusId { get; set; }
        public string CustomerPhone { get; set; } = string.Empty;
    }
}
