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
        public Guid FreelancerId { get; set; }
        public FreelanceAccount? Freelancer { get; set; }
        public Guid CustomerId { get; set; }
        public CustomerAccount? Customer { get; set; }
    }
}
