using System.ComponentModel.DataAnnotations;

namespace DeToiServerPayment.Dtos
{
    public class OrderPlacedDto
    {
        public Guid Id { get; set; }
        public Guid ExternalId { get; set; }
        public double EstimatedPrice { get; set; }
        public double RecommendPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public Guid? FreelancerId { get; set; }
        public Guid CustomerId { get; set; }
        public double Rating { get; set; }
        public string? Comment { get; set; }
        public Guid ServiceStatusId { get; set; }
        public string Event { get; set; } = string.Empty;
    }
}
