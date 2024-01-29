using DeToiServerCore.Models;
using DeToiServerCore.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DeToiServerData.Configurations
{
    internal class ServiceConfiguration : EntityTypeConfigurationBase<Service>
    {
        protected override void OnConfigure(EntityTypeBuilder<Service> builder)
        {
            builder.HasOne(s => s.ServiceCategory)
                .WithMany(sc => sc.Services)
                .HasForeignKey(s => s.ServiceCategoryId);

            //builder.HasMany(s => s.Orders)
            //    .WithMany(o => o.Services)
            //    .UsingEntity(j => j.ToTable("OrderService").HasOne()
            //        .OnDelete(DeleteBehavior.Restrict));

            // Configure the inheritance hierarchy using the Discriminator column
            builder.HasDiscriminator<string>("Discriminator")
                .HasValue<CleaningService>("CleaningService")
                .HasValue<RepairingService>("RepairingService")
                .HasValue<ShoppingService>("ShoppingService");

            
        }
    }

    internal class OrderConfiguration : EntityTypeConfigurationBase<Order>
    {
        protected override void OnConfigure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.ServiceCategory)
                .WithMany(sc => sc.Orders)
                .HasForeignKey(o => o.ServiceCategoryId);

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            builder.HasOne(o => o.Freelance)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.FreelancerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.ServiceStatus)
                .WithMany(ss => ss.Orders)
                .HasForeignKey(o => o.ServiceStatusId);
        }
    }
}
