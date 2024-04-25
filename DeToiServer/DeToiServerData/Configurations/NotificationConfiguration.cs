using DeToiServerCore.Models.Payment;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeToiServerCore.Models.Notifications;

namespace DeToiServerData.Configurations
{
    internal class NotificationConfiguration : EntityTypeConfigurationBase<Notification>
    {
        protected override void OnConfigure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(b => b.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");
        }
    }

    internal class NotificationAccountConfiguration : EntityTypeConfigurationBaseClass<NotificationAccount>
    {
        protected override void OnConfigure(EntityTypeBuilder<NotificationAccount> builder)
        {
            builder.HasKey(na => new { na.AccountId, na.NotificationId });

            builder.HasOne(notiAcc => notiAcc.Notification)
                .WithMany(noti => noti.NotificationAccounts)
                .HasForeignKey(notiAcc => notiAcc.NotificationId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(notiAcc => notiAcc.Account)
                .WithMany(acc => acc.NotificationAccounts)
                .HasForeignKey(notiAcc => notiAcc.AccountId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
