namespace DeToiServerCore.Models.Services
{
    public class ShoppingService : Service
    {
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ShoppingItems { get; set; } = string.Empty;
    }
}
