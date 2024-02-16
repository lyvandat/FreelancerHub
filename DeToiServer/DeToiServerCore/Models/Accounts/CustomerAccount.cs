using DeToiServerCore.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models.Accounts
{
    public class CustomerAccount : ModelBase
    {
        public required Account Account { get; set; }
        public required int AccountId { get; set; }
        public ICollection<Address>? Addresses { get; set; }
        public ICollection<Order>? Orders { get; set; }

        // promotion
        public string CustomerRank { get; set; } = CustomerRankConst.Unranked;
        public int MemberPoint { get; set; } = 0;
        public ICollection<CustomerPromotion>? CustomerPromotions { get; set; }
    }
}
