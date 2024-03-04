namespace DeToiServerCore.Models.Services
{
    public class RepairingService : Service
    {
        public string Name { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
