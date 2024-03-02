namespace DeToiServer.Dtos.CleaningServiceDtos
{
    public class PostCleaningServiceDto : PostServiceDto
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public int Floor { get; set; }
        public int RoomNumber { get; set; }
    }
}
