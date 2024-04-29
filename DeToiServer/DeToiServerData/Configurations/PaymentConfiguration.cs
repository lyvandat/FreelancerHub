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
                .WithMany(fl => fl.PaymentHistory)
                .HasForeignKey(fph => fph.FreelancerId)
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
                    Id = GlobalConstant.Fee.Id.PlatformFee,
                    Type = GlobalConstant.Fee.PlatformFee,
                    Amount = GlobalConstant.Fee.ValueConst.PlatformFee
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
