using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models.Services
{
    public class OrderServiceType
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public Guid ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; } = null!;
    }
}
