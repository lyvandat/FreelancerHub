using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;

namespace DeToiServer.Dtos.PaymentDtos
{
    public class AddFreelancePaymentHistoryDto
    {
        public double Value { get; set; }
        public string Method { get; set; } = GlobalConstant.Payment.CoD;
        public string Wallet { get; set; } = GlobalConstant.Payment.Wallet.Personal;
        public required Guid FreelanceAccountId { get; set; }
    }

    public class GetFreelancePaymentHistoryDto
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public string Method { get; set; } = GlobalConstant.Payment.CoD;
        public string Wallet { get; set; } = GlobalConstant.Payment.Wallet.Personal;
        public DateTime Timestamp { get; set; }

        public required Guid FreelanceAccountId { get; set; }
        public required FreelanceAccount FreelanceAccount { get; set; }
    }

    public class UpdateFreelanceBalanceDto
    {
        public Guid Id { get; set; }
        public string Method { get; set; } = GlobalConstant.Payment.CoD;
        public double Value { get; set; } = 0;
        public string WalletType { get; set; } = GlobalConstant.Payment.Wallet.Personal;
    }
}
