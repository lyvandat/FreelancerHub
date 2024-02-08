using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Dtos.ServiceCategoryDtos
{
    public class GetServiceCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class GetServiceCategoryWithChildDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<GetServiceTypeDto>? ServiceTypes { get; set; }
    }
}
