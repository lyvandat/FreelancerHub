using DeToiServerCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerData.Configurations
{
    internal class AccountConfiguration : EntityTypeConfigurationBase<Account>
    {
        protected override void OnConfigure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(e => e.Id).HasName("fk_accounts");

            builder.Property(e => e.Email).HasMaxLength(255);
            builder.Property(e => e.FullName).HasMaxLength(255);
            builder.Property(e => e.PasswordHash).HasMaxLength(512);
            builder.Property(e => e.PasswordResetToken).HasMaxLength(512);
            builder.Property(e => e.PasswordSalt).HasMaxLength(512);
            builder.Property(e => e.Phone).HasMaxLength(12);
            builder.Property(e => e.RefreshToken).HasMaxLength(512);
            builder.Property(e => e.Role).HasMaxLength(12);
        }
    }
}
