
using Newtonsoft.Json;

namespace DeToiServer.Dtos.ServiceProvenDtos
{
    public class GetServiceProvenDto
    {
        public Guid Id { get; set; }
        public ICollection<string>? MediaPathBefore { get; set; }
        public ICollection<string>? MediaPathAfter { get; set; }
        public string MediaType { get; set; } = string.Empty;
        public double EstimatedPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public bool IsFastestPossible { get; set; }
        public string ServiceType { get; set; } = string.Empty;
    }
}