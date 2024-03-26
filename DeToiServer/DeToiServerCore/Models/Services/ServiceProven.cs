using DeToiServerCore.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models.Services
{
    public class ServiceProven : ModelBase
    {
        public string ImageBefore { get; set; } = string.Empty;
        public string ImageAfter { get; set; } = string.Empty;
        public string MediaType { get; set; } = string.Empty;
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public Guid FreelancerId { get; set; }
        public FreelanceAccount? Freelancer { get; set; }
        public Guid ServiceTypeId { get; set; }
        public ServiceType? ServiceType { get; set; }
    }
}
