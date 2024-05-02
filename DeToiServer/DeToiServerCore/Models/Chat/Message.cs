using DeToiServerCore.Models.Accounts;

namespace DeToiServerCore.Models.Chat
{
    public class Message : ModelBase
    {
        public string Content { get; set; } = null!;
        public DateTime Time { get; set; }
        public bool IsSystem { get; set; } = false;
        public string? Image { get; set; } = null;

        public Guid SenderId { get; set; }
        public Account Sender { get; set; } = null!;
        public Guid ReceiverId { get; set; }
        public Account Receiver { get; set; } = null!;
    }

    public class MessageAccount : ModelBase
    {

    }
}
