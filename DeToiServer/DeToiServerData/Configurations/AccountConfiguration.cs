using DeToiServerCore.Models;
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

    internal class FavoriteConfiguration : EntityTypeConfigurationBaseClass<Favorite>
    {
        protected override void OnConfigure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasKey(fv => new { fv.FreelancerId, fv.CustomerId });

            builder.HasOne(fv => fv.Freelancer)
                .WithMany(fl => fl.FavoriteBy)
                .HasForeignKey(fv => fv.FreelancerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(fv => fv.Customer)
                .WithMany(c => c.Favorites)
                .HasForeignKey(fv => fv.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Favorites");
        }
    }

    internal class FreelancerSkillConfiguration : EntityTypeConfigurationBaseClass<FreelanceSkill>
    {
        protected override void OnConfigure(EntityTypeBuilder<FreelanceSkill> builder)
        {
            builder.HasKey(fv => new { fv.FreelancerId, fv.SkillId });

            builder.HasOne(fv => fv.Freelancer)
                .WithMany(fl => fl.FreelanceSkills)
                .HasForeignKey(fv => fv.FreelancerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(fv => fv.Skill)
                .WithMany(c => c.FreelanceSkills)
                .HasForeignKey(fv => fv.SkillId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
