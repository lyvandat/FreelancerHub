using DeToiServerCore.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeToiServerData.Configurations
{
    internal class AccountConfiguration : EntityTypeConfigurationBase<Account>
    {
        protected override void OnConfigure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(e => e.Id).HasName("pk_accounts");

            builder.Property(e => e.Email).HasMaxLength(255);
            builder.Property(e => e.FullName).HasMaxLength(255);
            //builder.Property(e => e.PasswordHash).HasMaxLength(512);
            //builder.Property(e => e.PasswordResetToken).HasMaxLength(512);
            //builder.Property(e => e.PasswordSalt).HasMaxLength(512);
            builder.Property(e => e.Phone).HasMaxLength(12);
            builder.Property(e => e.RefreshToken).HasMaxLength(512);
            builder.Property(e => e.Role).HasMaxLength(12);
        }
    }

    internal class FreelanceConfiguration : EntityTypeConfigurationBase<FreelanceAccount>
    {
        protected override void OnConfigure(EntityTypeBuilder<FreelanceAccount> builder)
        {
            builder.HasMany(fl => fl.Skills)
                .WithMany(s => s.Freelancers)
                .UsingEntity(j => j.ToTable("FreelanceSkills")); // name of the join table
        }
    }

    internal class AccountAddressConfiguration : EntityTypeConfigurationBase<Address>
    {
        protected override void OnConfigure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(ad => ad.CustomerAccount)
                .WithMany(cus => cus.Addresses)
                .HasForeignKey(ad => ad.CustomerAccountId)
                .IsRequired(false);

            builder.HasOne<FreelanceAccount>(ad => ad.FreelanceAccount)
                .WithOne(frl => frl.Address)
                .HasForeignKey<Address>(ad => ad.FreelanceAccountId)
                .IsRequired(false);
        }
    }
}
