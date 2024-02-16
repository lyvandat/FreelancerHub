using DeToiServerCore.Models;
using DeToiServerCore.Models.Accounts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeToiServerData.Configurations
{
    internal class PromotionConfiguration : EntityTypeConfigurationBase<Promotion>
    {
        protected override void OnConfigure(EntityTypeBuilder<Promotion> builder)
        {
        }
    }

    internal class CustomerPromotionConfiguration : EntityTypeConfigurationBaseClass<CustomerPromotion>
    {
        protected override void OnConfigure(EntityTypeBuilder<CustomerPromotion> builder)
        {
            builder.HasKey(entity => new { entity.PromotionId, entity.CustomerId });

            builder.HasOne(entity => entity.Customer)
                .WithMany(source => source.CustomerPromotions)
                .HasForeignKey(entity => entity.CustomerId);

            builder.HasOne(entity => entity.Promotion)
                .WithMany(source => source.CustomerPromotions)
                .HasForeignKey(entity => entity.PromotionId);

            // Configure custom columns
            //builder.Property(je => je.CustomerId).IsRequired();
            //builder.Property(je => je.PromotionId).IsRequired();
        }
    }
}
