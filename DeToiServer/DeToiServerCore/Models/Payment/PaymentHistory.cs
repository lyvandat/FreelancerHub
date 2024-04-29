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
        public string Method { get; set; } = GlobalConstant.Payment.Card;
        public string Wallet { get; set; } = GlobalConstant.Payment.Wallet.Personal;
        public string Description { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public PaymentType PaymentType { get; set; } = PaymentType.Add;
        public required Guid FreelancerId { get; set; }
        public required FreelanceAccount FreelanceAccount { get; set; }
    }

    public enum PaymentType
    {
        Add,
        Subtract
    }
}
