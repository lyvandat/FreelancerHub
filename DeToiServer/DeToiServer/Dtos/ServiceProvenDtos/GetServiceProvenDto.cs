namespace DeToiServer.Dtos.ServiceProvenDtos
{
    public class GetServiceProvenDto
    {
        public Guid Id { get; set; }
        public string ImageBefore { get; set; } = string.Empty;
        public string ImageAfter { get; set; } = string.Empty;
        public double EstimatedPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string ServiceType { get; set; } = string.Empty;
    }
}