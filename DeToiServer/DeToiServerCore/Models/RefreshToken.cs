namespace DeToiServerCore.Models
{
    public class RefreshToken
    {
        public string Value { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expired { get; set; }
    }
}
