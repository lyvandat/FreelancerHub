using DeToiServer.Models;
using DeToiServerCore.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeToiServerData.Configurations
{
    internal class UserConfiguration : EntityTypeConfigurationBaseClass<User>
    {
        protected override void OnConfigure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Connections)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserPhone)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
