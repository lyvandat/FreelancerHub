namespace DeToiServerCore.Models.Services
{
    public class Service : ModelBase
    {
        public string Note { get; set; } = string.Empty;
        public required int ServiceTypeId { get; set; }
        public required ServiceType ServiceType { get; set; }
        public ICollection<OrderService>? OrderServices { get; set; }
    }
}
