namespace DeToiServerCore.Models.Accounts
{
    public class Account : ModelBase
    {
        public string? Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty; // auto generated
        public DateOnly DateOfBirth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty; // default
        //public string PasswordHash { get; set; } = string.Empty;
        //public string PasswordSalt { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        //public string PasswordResetToken { get; set; } = string.Empty;
        //public DateTime ResetTokenExpires { get; set; } = DateTime.Now;
        public string LoginToken { get; set; } = "default";
        public DateTime LoginTokenExpires { get; set; } = DateTime.Now;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsVerified { get; set; } = false;
    }
}
