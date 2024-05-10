using DeToiServer.Dtos.ServiceTypeDtos;

namespace DeToiServer.Dtos.ServiceCategoryDtos
{
    public class PutServiceCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public ICollection<string>? Keys { get; set; }
        public string ServiceClassName { get; set; } = string.Empty;
        public bool IsActivated { get; set; } = true;
    }
}
