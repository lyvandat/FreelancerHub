namespace DeToiServerPayment.Dtos.PaymentDtos
{
    public class GetVnPayPaymentDto
    {
        public Guid OrderId { get; set; }
        public double Price { get; set; }
        public string Command { get; set; } = "pay";
        public string BankCode { get; set; } = "VNBANK";
        public string Locale { get; set; } = "vn";
    }
}
