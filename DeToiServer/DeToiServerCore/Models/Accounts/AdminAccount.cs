using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models.Accounts
{
    public class AdminAccount : ModelBase
    {
        public required Guid AccountId { get; set; }
        public required Account Account { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public string PasswordResetToken { get; set; } = string.Empty;
        public DateTime ResetTokenExpires { get; set; } = DateTime.Now;
    }
}
