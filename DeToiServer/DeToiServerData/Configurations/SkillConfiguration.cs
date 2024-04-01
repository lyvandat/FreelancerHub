using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeToiServerData.Configurations
{
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

    internal class FreelancerServiceTypeConfiguration : EntityTypeConfigurationBaseClass<FreelanceServiceType>
    {
        protected override void OnConfigure(EntityTypeBuilder<FreelanceServiceType> builder)
        {
            builder.HasKey(fst => new { fst.FreelancerId, fst.ServiceTypeId });

            builder.HasOne(fst => fst.Freelancer)
                .WithMany(fl => fl.FreelancerFeasibleServices)
                .HasForeignKey(fst => fst.FreelancerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(fst => fst.ServiceType)
                .WithMany(st => st.FreelancerInService)
                .HasForeignKey(fst => fst.ServiceTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

    internal class SkillServiceTypeConfiguration : EntityTypeConfigurationBaseClass<SkillServiceType>
    {
        protected override void OnConfigure(EntityTypeBuilder<SkillServiceType> builder)
        {
            builder.HasKey(sst => new { sst.ServiceTypeId, sst.SkillId });

            builder.HasOne(sst => sst.ServiceType)
                .WithMany(fl => fl.SkillOfService)
                .HasForeignKey(sst => sst.ServiceTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(sst => sst.Skill)
                .WithMany(c => c.ServiceTypeOfSkill)
                .HasForeignKey(sst => sst.SkillId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

    internal class OrderSkillRequireTypeConfiguration : EntityTypeConfigurationBaseClass<OrderSkillRequired>
    {
        protected override void OnConfigure(EntityTypeBuilder<OrderSkillRequired> builder)
        {
            builder.HasKey(osr => new { osr.OrderId, osr.SkillId });

            builder.HasOne(osr => osr.Order)
                .WithMany(fl => fl.SkillRequired)
                .HasForeignKey(osr => osr.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(osr => osr.Skill)
                .WithMany(c => c.RequiredOrders)
                .HasForeignKey(osr => osr.SkillId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
