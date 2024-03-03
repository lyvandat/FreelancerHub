using DeToiServerCore.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeToiServerData.Configurations
{
    internal class AccountConfiguration : EntityTypeConfigurationBase<Account>
    {
        protected override void OnConfigure(EntityTypeBuilder<Account> builder)
        {
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

            builder.HasMany(fl => fl.ServiceProven)
                .WithOne(sp => sp.Freelancer)
                .HasForeignKey(sp => sp.FreelancerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    internal class AddressConfiguration : EntityTypeConfigurationBase<Address>
    {
        protected override void OnConfigure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(ad => ad.CustomerAccount)
                .WithMany(cus => cus.Addresses)
                .HasForeignKey(ad => ad.CustomerAccountId)
                .IsRequired(false);

            builder.HasOne(ad => ad.FreelanceAccount)
                .WithMany(frl => frl.Address)
                .HasForeignKey(ad => ad.FreelanceAccountId)
                .IsRequired(false);
        }
    }
}
