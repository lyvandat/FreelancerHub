using DeToiServer.Dtos.ServiceCategoryDtos;
using DeToiServer.Dtos.ServiceStatusDtos;
using DeToiServer.Dtos.UIElementDtos;

namespace DeToiServer.Dtos.ServiceTypeDtos
{
    public class GetServiceTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string AddressRequireOption { get; set; } = null!;
        public bool IsActivated { get; set; }
    }

    public class GetServiceTypeDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string AddressRequireOption { get; set; } = null!;
        public bool IsActivated { get; set; }
        public ICollection<string> Keys { get; set; } = null!;
        public ICollection<UIElementServiceRequirementDto>? Requirements { get; set; }
        public ICollection<UIElementAdditionServiceRequirementDto>? AdditionalRequirements { get; set; }
        public ICollection<GetServiceStatusDto> ServiceStatusList { get; set; } = null!;
    }

    public class GetServiceTypeWithCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string AddressRequireOption { get; set; } = null!;
        public GetServiceCategoryDto ServiceCategory { get; set; } = null!;
    }

    public class SearchServiceTypeAndCategoryDto
    {
        public IEnumerable<GetServiceCategoryDto> Categories { get; set; } = null!;
        public IEnumerable<GetServiceTypeWithCategoryDto> Services { get; set; } = null!;
    }

}
