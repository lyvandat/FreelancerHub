using DeToiServerCore.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models
{
    public class Favorite
    {
        public required Guid FreelancerId { get; set; }
        public required FreelanceAccount Freelance { get; set; }
        public required Guid CustomerId { get; set; }
        public required CustomerAccount Customer { get; set; }
    }
}
