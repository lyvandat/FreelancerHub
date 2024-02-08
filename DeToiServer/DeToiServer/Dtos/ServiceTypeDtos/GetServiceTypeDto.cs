using DeToiServer.Dtos.ServiceCategoryDtos;

namespace DeToiServer.Dtos.ServiceTypeDtos
{
    public class GetServiceTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public string? Description { get; set; }
        public GetServiceCategoryDto? ServiceCategory { get; set; }
    }
}
