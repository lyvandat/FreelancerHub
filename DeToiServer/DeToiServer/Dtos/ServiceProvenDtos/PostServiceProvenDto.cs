using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Dtos.ServiceProvenDtos
{
    public class PostServiceProvenDto
    {
        public string ImageBefore { get; set; } = string.Empty;
        public string ImageAfter { get; set; } = string.Empty;
        public string MediaType { get; set; } = string.Empty;
        public Guid OrderId { get; set; }
        public Guid FreelancerId { get; set; }
        public Guid ServiceTypeId { get; set; }
    }
}
