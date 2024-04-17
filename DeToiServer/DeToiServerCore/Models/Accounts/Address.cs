using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models.Accounts
{
    public class Address : ModelBase
    {
        public CustomerAccount CustomerAccount { get; set; } = null!;
        public Guid? CustomerAccountId { get; set; }
        public FreelanceAccount FreelanceAccount { get; set; } = null!;
        public Guid? FreelanceAccountId { get; set; }
        public ICollection<Order>? Orders { get; set; }

        public double Lat { get; set; }
        public double Lon { get; set; }
        public string AddressLine { get; set; } = string.Empty; // thêm lat lon
        public string Ward { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
