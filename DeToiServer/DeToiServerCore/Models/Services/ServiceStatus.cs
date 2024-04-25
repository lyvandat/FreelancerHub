namespace DeToiServerCore.Models.Services
{
    public class ServiceStatus : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public ICollection<Order>? Orders { get; set; }
        public ICollection<ServiceTypeStatus> ServiceStatusList { get; set; } = null!;
    }
}
