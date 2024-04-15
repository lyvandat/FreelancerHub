namespace DeToiServerPayment.ConfigModels
{
    public class VnPayConfigModel
    {
        public string Url { get; set; } = string.Empty;
        public string Api { get; set; } = string.Empty;
        public string TmnCode { get; set; } = string.Empty;
        public string HashSecret { get; set; } = string.Empty;
        public string ReturnUrl { get; set; } = string.Empty;
    }
}
