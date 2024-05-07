using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Chat;
using DeToiServerCore.Models.Notifications;
using DeToiServerCore.Models.Reports;
using System.Collections.ObjectModel;

namespace DeToiServerCore.Models.Accounts
{
    public class Account : ModelBase
    {
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
        public string EncriptingToken { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public ICollection<NotificationAccount>? NotificationAccounts { get; set; }
        public ICollection<Message> SentMessage { get; set; } = null!;
        public ICollection<Message> ReceivedMessage { get; set; } = null!;
        public ICollection<Report> PostedReports { get; set; } = null!;
    }
}
