using DeToiServer.Dtos.CleaningServiceDtos;
using DeToiServer.Dtos.RepairingServiceDtos;
using DeToiServer.Dtos.ShoppingServiceDtos;

namespace DeToiServer.Dtos.OrderDtos
{
    public class PostOrderDto
    {
        public string Address { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public Guid CustomerId { get; set; }
        public PostCleaningServiceDto? CleaningService { get; set; }
        //public PostRepairingServiceDto? RepairingService { get; set; }
        //public PostShoppingServiceDto? ShoppingService { get; set; }
    }
}
