using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models.Payment
{
    public class FreelancePaymentHistory : ModelBase
    {
        public string Value { get; set; } = string.Empty;
        public string Method { get; set; } = GlobalConstant.Payment.CoD;
        public string Wallet { get; set; } = GlobalConstant.Payment.Wallet.Personal;
        public DateTime Timestamp { get; set; }

        public required Guid FreelanceAccountId { get; set; }
        public required FreelanceAccount FreelanceAccount { get; set; }
    }


    //public Guid? CustomerAccountId { get; set; }
    //public CustomerAccount? CustomerAccount { get; set; }
}
