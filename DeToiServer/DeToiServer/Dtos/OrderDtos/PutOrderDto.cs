namespace DeToiServer.Dtos.OrderDtos
{
    public class PutOrderFreelancerImageDto
    {
        public required Guid OrderId { get; set; }
        public required string Image { get; set; }
    }
}
