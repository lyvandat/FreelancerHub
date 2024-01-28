namespace DeToiServerCore.Models.Services
{
    public class ServiceStatus : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Order>? Orders { get; set; }
    }
}
