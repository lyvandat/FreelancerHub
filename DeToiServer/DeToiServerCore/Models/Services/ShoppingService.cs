using DeToiServerCore.Models.Infos;

namespace DeToiServerCore.Models.Services
{
    public class ShoppingService : Service
    {
        public Guid? ShoppingInfoId { get; set; }
        public ShoppingInfo? ShoppingInfo { get; set; }
        public double Price { get; set; }
        public string ShoppingItems { get; set; } = string.Empty;
    }
}
