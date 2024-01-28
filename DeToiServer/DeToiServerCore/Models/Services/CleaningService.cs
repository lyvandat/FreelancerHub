using DeToiServerCore.Models.Infos;

namespace DeToiServerCore.Models.Services
{
    public class CleaningService : Service
    {
        public int? HomeInfoId { get; set; }
        public HomeInfo? HomeInfo { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int Floor { get; set; }
        public double Price { get; set; }
    }
}
