
namespace DeToiServer.Dtos.ServiceTypeDtos
{
    public class PostServiceTypeDto
    {
        public string Name { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public string? Description { get; set; }
        public int? ServiceCategoryId { get; set; }
    }
}
