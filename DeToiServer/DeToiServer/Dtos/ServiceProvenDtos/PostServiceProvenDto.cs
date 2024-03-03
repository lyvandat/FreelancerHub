using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Dtos.ServiceProvenDtos
{
    public class PostServiceProvenDto
    {
        public string Image { get; set; } = string.Empty;
        public Guid OrderId { get; set; }
        public Guid FreelancerId { get; set; }
        public Guid ServiceTypeId { get; set; }
    }
}
