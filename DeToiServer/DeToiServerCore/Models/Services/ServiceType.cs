using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.SevicesUIElement;

namespace DeToiServerCore.Models.Services
{
    public class ServiceType : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string Keys { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsActivated { get; set; }
        public string AddressRequireOption { get; set; } = GlobalConstant.AddressOption.Destination;
        public Guid? ServiceCategoryId { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }
        public ICollection<OrderServiceType>? OrderServiceTypes { get; set; }
        public ICollection<Service>? Services { get; set; }
        public ICollection<ServiceProven>? ServiceProven { get; set; }
        public ICollection<UIElementServiceRequirement>? Requirements { get; set; }
        public ICollection<UIElementAdditionServiceRequirement>? AdditionalRequirements { get; set; }
        public ICollection<FreelanceServiceType>? FreelancerInService { get; set; }
        public ICollection<SkillServiceType>? SkillOfService { get; set; }
        public ICollection<ServiceTypeStatus> ServiceStatusList { get; set; } = null!;
    }
}
