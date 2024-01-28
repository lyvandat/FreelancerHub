using DeToiServerCore.Models.Infos;

namespace DeToiServerCore.Models.Services
{
    public class RepairingService : Service
    {
        public int? DeviceInfoId { get; set; }
        public DeviceInfo? DeviceInfo { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
