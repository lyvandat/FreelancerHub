namespace DeToiServerCore.Models.Services
{
    public abstract class Service : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public string Note { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ServiceCategoryId { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
