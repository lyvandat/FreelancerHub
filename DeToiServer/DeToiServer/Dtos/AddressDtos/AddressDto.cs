namespace DeToiServer.Dtos.AddressDtos
{
    public class AddressDto
    {
        public string AddressLine { get; set; } = string.Empty; // thêm lat lon
        public string Ward { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
