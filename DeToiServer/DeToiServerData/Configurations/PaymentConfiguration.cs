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
}
