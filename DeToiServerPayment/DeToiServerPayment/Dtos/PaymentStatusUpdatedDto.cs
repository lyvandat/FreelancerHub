using DeToiServerPayment.Models;

namespace DeToiServerPayment.Dtos
{
    public class PaymentStatusUpdatedDto
    {
        public Guid OrderId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string Event { get; set; } = string.Empty;
    }
}
