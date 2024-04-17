namespace DeToiServer.Dtos.AccountDtos
{
    public class PutCustomerAccountDto
    {
        public string? FullName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public DateOnly? DateOfBirth { get; set; }
        public string? CountryCode { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
    }
}
