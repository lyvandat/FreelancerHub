namespace DeToiServerCore.Models.Services
{
    public class ServiceStatus : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Order>? Orders { get; set; }
    }

    public class ServiceActivationStatus : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<ServiceType>? ServiceTypes { get; set; }
        public ICollection<ServiceCategory>? ServiceCategories { get; set; }
    }
}
