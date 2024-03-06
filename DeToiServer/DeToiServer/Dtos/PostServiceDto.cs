namespace DeToiServer.Dtos
{
    public class PostServiceDto
    {
        public Guid ServiceTypeId { get; set; }
        public string Note { get; set; } = string.Empty;
        public string AdditionalNote { get; set; } = string.Empty;
    }
}
