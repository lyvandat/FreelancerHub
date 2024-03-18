namespace DeToiServer.Dtos.FreelanceDtos
{
    public class GetFreelanceReviewDto
    {
        public Guid CustomerId { get; set; }
        public string Avatar { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
