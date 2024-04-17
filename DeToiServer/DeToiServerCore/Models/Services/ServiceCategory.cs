using DeToiServerCore.Models.Services;

namespace DeToiServerCore.Models
{
    public class ServiceCategory : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string? Description { get; set; }
        public required string ServiceClassName { get; set; }
        public string? Keys { get; set; } // Thêm field createdAt, thêm trạng thái đang hoạt động | ngưng hoạt động (ServiceActivationStatus).
        public ICollection<ServiceType>? ServiceTypes { get; set; }
    }
}
