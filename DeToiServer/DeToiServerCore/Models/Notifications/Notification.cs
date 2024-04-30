using DeToiServerCore.Enums;
using System.Collections.ObjectModel;

namespace DeToiServerCore.Models.Notifications
{
    public class Notification : ModelBase
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Collection<NotificationAccount>? NotificationAccounts { get; set; }

        public string PushTo { get; set; } = null!; // List<string>
        public string PushData { get; set; } = null!; // object
        public string PushTitle { get; set; } = null!;
        public string PushBody { get; set; } = null!;
        //public int? PushTTL { get; set; }
        //public int? PushExpiration { get; set; }
        //public string PushPriority { get; set; } = "default";
        public string PushSubTitle { get; set; } = null!;
        public string PushSound { get; set; } = "default";
        public int? PushBadgeCount { get; set; } = null;
        //public string PushChannelId { get; set; } = null!;
        //public string PushCategoryId { get; set; } = null!;
    }
}
