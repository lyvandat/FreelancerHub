namespace DeToiServerCore.Models.Services
{
    public class ServiceTypeStatus
    {
        public Guid ServiceTypeId { get; set; }
        public required ServiceType ServiceType { get; set; }
        public Guid ServiceStatusId { get; set; }
        public required ServiceStatus ServiceStatus { get; set; }
    }
}
