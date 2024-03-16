using DeToiServer.Dtos.ServiceTypeDtos;

namespace DeToiServer.Dtos.ServiceCategoryDtos
{
    public class PostServiceCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public ICollection<PostServiceTypeDto>? ServiceTypes { get; set; }
    }
}
