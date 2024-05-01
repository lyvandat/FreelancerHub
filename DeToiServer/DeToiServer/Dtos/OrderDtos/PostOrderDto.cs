using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.ServiceDtos;

namespace DeToiServer.Dtos.OrderDtos
{
    public class PostOrderDto
    {
        public ICollection<PostOrderAddressDto> Address { get; set; } = null!;
        public TimeOnly StartTime { get; set; }
        public DateOnly StartDate { get; set; }
        public Guid CustomerId { get; set; }
        public required PostServiceDto Services { get; set; }
    }

    public class PostOrderResultDto
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class PutOrderPriceAndFreelancerDto
    {
        public Guid OrderId { get; set; }
        public Guid FreelancerId { get; set; }
        public double ActualPrice { get; set; }
    }

    public class PutOrderStatus
    {
        public Guid OrderId { get; set; }
        public Guid StatusId { get; set; }
    }

    public class PutOrderMovingStatusDto
    {
        public Guid OrderId { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class PostOrderCustomerReviewDto
    {
        public Guid OrderId { get; set; }
        public double Rating { get; set; }
        public string? Comment { get; set; } = null;
    }

    public class UpdateOrderResultDto
    {
        public Order? Order { get; set; } = null;
        public string Message { get; set; } = string.Empty;
    }

    public class UpdateOrderResultWithOldPreviewPriceDto
    {
        public Order? Order { get; set; } = null;
        public double OldPreviewPrice{ get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class PostOrderFreelancerReviewDto
    {
        public Guid OrderId { get; set; }
        public double Rating { get; set; }
        public string? Comment { get; set; } = null;
    }
}
