namespace DeToiServerCore.Models.Services
{
    public class OrderService
    {
        public int OrderId { get; set; }
        public required Order Order { get; set; }

        public int ServiceId { get; set; }
        public required Service Service { get; set; }
    }
}
