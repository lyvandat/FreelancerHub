namespace DeToiServer.Dtos.ServiceStatusDtos
{
    public class GetServiceStatusDto
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }
}
