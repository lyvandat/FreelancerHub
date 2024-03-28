namespace DeToiServer.Dtos.FreelanceDtos
{
    public class GetFreelanceReviewDto
    {
        public Guid CustomerId { get; set; } //id: string;
        public string Avt { get; set; } = string.Empty; //avt: string;
        public string Name { get; set; } = string.Empty; //name: string;
        public string Content { get; set; } = string.Empty; //content: string;
        public double RatingPoint { get; set; } //ratingPoint: number;
        public DateOnly ReviewDate { get; set; }
    }
}
