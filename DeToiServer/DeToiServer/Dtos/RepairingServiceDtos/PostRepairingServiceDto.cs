using DeToiServerCore.Models.Infos;

namespace DeToiServer.Dtos.RepairingServiceDtos
{
    public class PostRepairingServiceDto : PostServiceDto
    {
        public DeviceInfo? DeviceInfo { get; set; }
        public double Quantity { get; set; }
    }
}
