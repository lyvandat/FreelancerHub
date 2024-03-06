namespace DeToiServer.Dtos.ServiceProvenDtos
{
    public class GetServiceProvenDto
    {
        public Guid Id { get; set; }
        public string Image { get; set; } = string.Empty;
        public double EstimatedPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string ServiceType { get; set; } = string.Empty;
    }
}