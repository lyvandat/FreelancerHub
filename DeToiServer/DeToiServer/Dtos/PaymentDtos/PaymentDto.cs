using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Payment;

namespace DeToiServer.Dtos.PaymentDtos
{
    public class AddFreelancePaymentHistoryDto
    {
        public string Value { get; set; } = string.Empty;
        public string Method { get; set; } = GlobalConstant.Payment.Card;
        public string Wallet { get; set; } = GlobalConstant.Payment.Wallet.Personal;
        public PaymentType PaymentType { get; set; } = PaymentType.Add;
        public required Guid FreelancerId { get; set; }
    }

    public class GetFreelancePaymentHistoryDto
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public string Method { get; set; } = GlobalConstant.Payment.Card;
        public string Wallet { get; set; } = GlobalConstant.Payment.Wallet.Personal;
        public DateTime Timestamp { get; set; }
        public PaymentType PaymentType { get; set; }
        public required Guid FreelanceAccountId { get; set; }
        public required FreelanceAccount FreelanceAccount { get; set; }
    }

    public class GetFreelanceShortPaymentHistoryDto
    {
        public string PaymentType { get; set; } = string.Empty;
        public double Value { get; set; }
        public string Method { get; set; } = string.Empty;
    }

    public class UpdateFreelanceBalanceDto
    {
        public Guid Id { get; set; }
        public string Method { get; set; } = GlobalConstant.Payment.Card;
        public double Value { get; set; } = 0;
        public string WalletType { get; set; } = GlobalConstant.Payment.Wallet.Personal;
    }

    public class PostFreelancePaymentDto
    {
        public int Amount { get; set; }
    }

    public class ConfirmWebhook
    {
        public string Webhook_url { get; set; } = string.Empty;
    }
}
