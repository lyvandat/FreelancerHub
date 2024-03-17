using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.ServiceStatusDtos;

namespace DeToiServer.Dtos.RealTimeDtos
{
    public class UpdateOnMovingOrderStatusDto
    {
        public AddressDto? Address { get; set; }
        public Guid ServiceStatusId { get; set; } 
    }

    public class UpdateOrderStatusDto
    {
        public Guid FreelancerAccountId { get; set; }
        public GetServiceStatusDto? ServiceStatus { get; set; }
    }
}
