using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models;
using DeToiServerCore.Models.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeToiServerData.Configurations
{
    internal class ReportConfiguration : EntityTypeConfigurationBaseClass<Report>
    {
        protected override void OnConfigure(EntityTypeBuilder<Report> builder)
        {
            builder.Property(r => r.Rejected)
                .HasDefaultValue(false);
            builder.Property(r => r.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(r => r.ActionIdOnCustomer)
                .HasDefaultValue(GlobalConstant.Report.NoAction);
            builder.Property(r => r.ActionIdOnCustomer)
                .HasDefaultValue(GlobalConstant.Report.NoAction);

            builder.HasOne(r => r.ActionOnCustomer)
                .WithMany(ac => ac.ReportsOnCustomer)
                .HasForeignKey(r => r.ActionIdOnCustomer)
                .OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(r => r.ActionOnFreelance)
                .WithMany(ac => ac.ReportsOnFreelancer)
                .HasForeignKey(r => r.ActionIdOnFreelance)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(r => r.FromAccount)
                .WithMany(acc => acc.ReportedBy)
                .HasForeignKey(r => r.FromId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(r => r.ToAccount)
                .WithMany(acc => acc.ReportAccounts)
                .HasForeignKey(r => r.ToId)
                .OnDelete(DeleteBehavior.ClientNoAction);

        }
    }

    internal class ReportActionConfiguration : EntityTypeConfigurationBaseClass<ReportAction>
    {
        protected override void OnConfigure(EntityTypeBuilder<ReportAction> builder)
        {

            builder.HasData(new List<ReportAction>()
            {
                new() { Id = GlobalConstant.Report.NoAction, Name = "Không hành động", Description = "", },
                new() { Id = GlobalConstant.Report.RefundAll, Name = "Hoàn tiền 100%", Description = "", },
                new() { Id = GlobalConstant.Report.RefundHalf, Name = "Hoàn tiền 50%", Description = "", },
                new() { Id = GlobalConstant.Report.BanCustomer, Name = "Cấm tài khoản Customer", Description = "", },
                new() { Id = GlobalConstant.Report.BanFreelancer, Name = "Cấm tài khoản Freelancer", Description = "", },
                new() { Id = GlobalConstant.Report.MarkFreelancer, Name = "Đánh gậy tài khoản Freelancer", Description = "", },
            });
        }
    }
}
