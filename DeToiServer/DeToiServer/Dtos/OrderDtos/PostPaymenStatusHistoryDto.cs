namespace DeToiServer.Dtos.OrderDtos
{
    public class PostPaymentStatusHistoryDto
    {
        public Guid OrderId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
