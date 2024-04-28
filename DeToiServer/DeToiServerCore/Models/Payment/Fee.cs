using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models.Payment
{
    public class Fee : ModelBase
    {
        public string Type { get; set; } = null!;
        public double Amount { get; set; }
    }
}
