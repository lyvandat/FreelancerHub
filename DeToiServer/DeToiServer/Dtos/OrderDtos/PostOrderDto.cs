using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.CleaningServiceDtos;

namespace DeToiServer.Dtos.OrderDtos
{
    public class PostOrderDto
    {
        public string Address { get; set; } = string.Empty;

        public string AddressLine { get; set; } = string.Empty; // thêm lat lon
        public DateTime StartTime { get; set; }
        public Guid CustomerId { get; set; }
        public PostCleaningServiceDto? CleaningService { get; set; }
        //public PostRepairingServiceDto? RepairingService { get; set; }
        //public PostShoppingServiceDto? ShoppingService { get; set; }
    }

    public class PostTestOrderDto
    {
        public required PostOrderAddressDto Address { get; set; }
        public DateTime StartTime { get; set; }
        public Guid CustomerId { get; set; }
        public PostCleaningServiceDto? CleaningService { get; set; }
        //public PostRepairingServiceDto? RepairingService { get; set; }
        //public PostShoppingServiceDto? ShoppingService { get; set; }
    }
}
