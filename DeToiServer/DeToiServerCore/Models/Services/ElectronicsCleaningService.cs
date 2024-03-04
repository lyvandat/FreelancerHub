namespace DeToiServerCore.Models.Services
{
    public class ElectronicsCleaningService : Service
    {
        public string DeviceName { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string CurrentDeviceState { get; set; } = string.Empty;
    }
}
