using DeToiServerCore.Common.Constants;

namespace DeToiServer.Dtos.AccountDtos
{
    public class GetAccountDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public DateOnly? DateOfBirth { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CombinedPhone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string ExpoPushToken { get; set; } = null!;
    }

    public class AccountDecryptedDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty; // auto generated
        public DateOnly? DateOfBirth { get; set; } = null;
        public string CountryCode { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CombinedPhone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string Gender { get; set; } = GlobalConstant.Gender.Male;
        public string RefreshToken { get; set; } = string.Empty;
        public string LoginToken { get; set; } = "default";
        public DateTime LoginTokenExpires { get; set; } = DateTime.Now;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsVerified { get; set; } = false;
        public string ExpoPushToken { get; set; } = string.Empty;
        public Guid SessionId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
