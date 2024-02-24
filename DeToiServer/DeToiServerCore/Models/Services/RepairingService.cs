using DeToiServerCore.Models.Infos;

namespace DeToiServerCore.Models.Services
{
    public class RepairingService : Service
    {
        public Guid? DeviceInfoId { get; set; }
        public DeviceInfo? DeviceInfo { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
