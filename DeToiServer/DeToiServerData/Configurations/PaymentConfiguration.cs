using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeToiServerData.Configurations
{
    internal class FreelancePaymentConfiguration : EntityTypeConfigurationBase<FreelancePaymentHistory>
    {
        protected override void OnConfigure(EntityTypeBuilder<FreelancePaymentHistory> builder)
        {
            builder.Property(b => b.Timestamp)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(fph => fph.FreelanceAccount)
                .WithMany(fl => fl.PaymentHistories)
                .HasForeignKey(fph => fph.FreelanceAccountId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }

    internal class FeeConfiguration : EntityTypeConfigurationBase<Fee>
    {
        protected override void OnConfigure(EntityTypeBuilder<Fee> builder)
        {
            builder.HasIndex(e => e.Type).IsUnique();

            builder.HasData(new List<Fee>()
            {
                new() {
                    Id = GlobalConstant.Fee.Id.Platform,
                    Type = GlobalConstant.Fee.Platform,
                    Amount = GlobalConstant.Fee.ValueConst.Platform
                },
                new() {
                    Id = GlobalConstant.Fee.Id.MinServicePrice,
                    Type = GlobalConstant.Fee.MinServicePrice,
                    Amount = GlobalConstant.Fee.ValueConst.MinServicePrice
                },
            });;
        }
    }
}
