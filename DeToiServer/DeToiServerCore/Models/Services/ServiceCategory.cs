using DeToiServerCore.Models.Services;

namespace DeToiServerCore.Models
{
    public class ServiceCategory : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<ServiceType>? ServiceTypes { get; set; }
        public ICollection<Service>? Services { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
