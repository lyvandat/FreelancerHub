using DeToiServerCore.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models
{
    public class OrderAddress
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public Guid AddressId { get; set; }
        public Address Address { get; set; } = null!;
    }
}
