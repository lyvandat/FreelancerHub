using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models
{
    public class Review : ModelBase
    {
        public double Point { get; set; }
        public string? Comment { get; set; }
    }
}
