
using DeToiServer.Dtos.UIElementDtos;

namespace DeToiServer.Dtos.ServiceTypeDtos
{
    public class PostServiceTypeDto
    {
        public string Name { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string AddressRequireOption { get; set; } = null!;
        public Guid? ServiceCategoryId { get; set; }
    }

    public class PostServiceTypeWithRequirementDto
    {
        public string Name { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string AddressRequireOption { get; set; } = null!;
        public bool IsActivated { get; set; }
        public Guid ServiceCategoryId { get; set; }
        public ICollection<string>? Keys { get; set; }
        public ICollection<PostUIElementServiceRequirementDto>? Requirements { get; set; }
        public ICollection<PostUIElementAdditionServiceRequirementDto>? AdditionalRequirements { get; set; }
    }
}
