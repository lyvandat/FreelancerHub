using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models
{
    public class ServiceOrder : ModelBase
    {
        public string Address { get; set; } = string.Empty;
        public double EstimatedPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ScheduleTime { get; set; }
        public DateTime CreatedTime { get; set; }

        public int? FreelancerId { get; set; }
        public int CustomerId { get; set; }
        public required int ServiceTypeId { get; set; }
        public required ServiceType ServiceType { get; set; }
    }
}
