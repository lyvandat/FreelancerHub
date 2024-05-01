using DeToiServerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.QueryModels.OrderQueryModels
{
    public class OrderFeasibleFreelancersQuery
    {
        public IEnumerable<string> FreelancerPhones { get; set; } = null!;
        public Order OrderDetail { get; set; } = null!;
    }
}
