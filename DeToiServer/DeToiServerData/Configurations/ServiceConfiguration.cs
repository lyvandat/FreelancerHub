using DeToiServerCore.Models;
using DeToiServerCore.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeToiServerData.Configurations
{
    internal class ServiceConfiguration : EntityTypeConfigurationBase<Service>
    {
        protected override void OnConfigure(EntityTypeBuilder<Service> builder)
        {
            builder.HasOne(s => s.ServiceCategory)
                .WithMany(sc => sc.Services)
                .HasForeignKey(s => s.ServiceCategoryId);

            builder.HasMany(s => s.Orders)
                .WithMany(o => o.Services)
                .UsingEntity(j => j.ToTable("OrderService")); // name of the join table
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
                .HasForeignKey(o => o.FreelancerId);

            builder.HasOne(o => o.ServiceStatus)
                .WithMany(ss => ss.Orders)
                .HasForeignKey(o => o.ServiceStatusId);
        }
    }

    internal class CleaningServiceConfiguration : EntityTypeConfigurationBase<CleaningService>
    {
        protected override void OnConfigure(EntityTypeBuilder<CleaningService> builder)
        {
            builder.HasBaseType<Service>();
        }
    }

    internal class RepairingServiceConfiguration : EntityTypeConfigurationBase<RepairingService>
    {
        protected override void OnConfigure(EntityTypeBuilder<RepairingService> builder)
        {
            builder.HasBaseType<Service>();
        }
    }

    internal class ShoppingServiceConfiguration : EntityTypeConfigurationBase<ShoppingService>
    {
        protected override void OnConfigure(EntityTypeBuilder<ShoppingService> builder)
        {
            builder.HasBaseType<Service>();
        }
    }
}
