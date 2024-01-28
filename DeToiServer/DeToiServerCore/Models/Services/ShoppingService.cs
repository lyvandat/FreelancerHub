using DeToiServerCore.Models.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models.Services
{
    public class ShoppingService : Service
    {
        public int? ShoppingInfoId { get; set; }
        public ShoppingInfo? ShoppingInfo { get; set; }
        public double Price { get; set; }
    }
}
