
using DeToiServer.Dtos.UIElementDtos;

namespace DeToiServer.Dtos.ServiceTypeDtos
{
    public class PutServiceTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public Guid? ServiceCategoryId { get; set; }
    }

    public class PutServiceTypeWithRequirementDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string AddressRequireOption { get; set; } = null!;
        public bool IsActivated { get; set; } = true;
        //public Guid ServiceCategoryId { get; set; }
        public ICollection<string>? Keys { get; set; }
        public ICollection<PostUIElementServiceRequirementDto>? Requirements { get; set; }
        public ICollection<PostUIElementAdditionServiceRequirementDto>? AdditionalRequirements { get; set; }
    }

    public class PutServiceTypeAddressOptionDto
    {
        public Guid Id { get; set; }
        public required string AddressRequireOption { get; set; }
    }
}
