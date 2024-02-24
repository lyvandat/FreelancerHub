
namespace DeToiServer.Dtos.ServiceTypeDtos
{
    public class PutServiceTypeDto
    {
        public Guid id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public string? Description { get; set; }
        public Guid? ServiceCategoryId { get; set; }
    }
}
