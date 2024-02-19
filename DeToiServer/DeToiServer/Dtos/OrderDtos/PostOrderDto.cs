using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Dtos.OrderDtos
{
    public class PostOrderDto
    {
        public string Address { get; set; } = string.Empty;
        public double EstimatedPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ScheduleTime { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public double Rating { get; set; } = 0;
        public required int ServiceCategoryId { get; set; }
        public required ServiceCategory ServiceCategory { get; set; }
        public int ServiceStatusId { get; set; }
        public ServiceStatus? ServiceStatus { get; set; }
        public ICollection<OrderService>? OrderServices { get; set; }
    }
}
