using DeToiServerCore.Models.Infos;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Dtos.CleaningServiceDtos
{
    public class PostCleaningServiceDto : PostServiceDto
    {
        public HomeInfo? HomeInfo { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int Floor { get; set; }
    }
}
