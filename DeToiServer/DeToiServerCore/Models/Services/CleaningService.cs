namespace DeToiServerCore.Models.Services
{
    public class CleaningService : Service
    {
        public string AddressLine { get; set; } = string.Empty;
        public string CleanningType { get; set; } = string.Empty;
        public int RoomNumber { get; set; }
        public bool HasPets { get; set; }
        public bool HasElectronics { get; set; }
        public bool FreelancerBringTools { get; set; }
    }
}
