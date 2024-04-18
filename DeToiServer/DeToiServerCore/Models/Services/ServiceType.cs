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
        public string? Keys { get; set; } // Thêm field createdAt, 
        public DateTime CreatedAt { get; set; } // thêm trạng thái đang hoạt động | ngưng hoạt động (ServiceActivationStatus).
        public Guid? ServiceCategoryId { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }
        public ICollection<OrderServiceType>? OrderServiceTypes { get; set; }
        public ICollection<Service>? Services { get; set; }
        public ICollection<ServiceProven>? ServiceProven { get; set; }
        public ICollection<UIElementServiceRequirement>? Requirements { get; set; }
        public ICollection<UIElementAdditionServiceRequirement>? AdditionalRequirements { get; set; }
        public ICollection<FreelanceServiceType>? FreelancerInService { get; set; }
        public ICollection<SkillServiceType>? SkillOfService { get; set; }
        public Guid? ActivationStatusId { get; set; }
        public ServiceActivationStatus? ActivationStatus { get; set; }
    }
}
