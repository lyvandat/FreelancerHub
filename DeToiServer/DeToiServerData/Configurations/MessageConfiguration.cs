using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Chat;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Configurations
{
    internal class MessageConfiguration : EntityTypeConfigurationBase<Message>
    {
        protected override void OnConfigure(EntityTypeBuilder<Message> builder)
        {
            builder.HasOne(msg => msg.Sender)
                .WithMany(sd => sd.SentMessage)
                .HasForeignKey(msg => msg.SenderId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(msg => msg.Receiver)
                .WithMany(rc => rc.ReceivedMessage)
                .HasForeignKey(msg => msg.ReceiverId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Property(msg => msg.Time)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
