using System.ComponentModel.DataAnnotations;

namespace DeToiServer.Dtos.ServiceProvenDtos
{
    public class PostServiceProvenDto
    {
        [Required]
        public required ICollection<string> MediaPath { get; set; }
        [Required]
        public string MediaType { get; set; } = string.Empty;
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public Guid FreelancerId { get; set; }
        [Required]
        public Guid ServiceTypeId { get; set; }
    }
}
