using DeToiServerCore.Models.Services;

namespace DeToiServer.Dtos.ServiceCategoryDtos
{
    public class GetServiceCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
