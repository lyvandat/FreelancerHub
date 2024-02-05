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
            builder.HasOne(s => s.ServiceType)
                .WithMany(st => st.Services)
                .HasForeignKey(s => s.ServiceTypeId);

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

    internal class OrderServiceConfiguration : EntityTypeConfigurationBaseClass<OrderService>
    {
        protected override void OnConfigure(EntityTypeBuilder<OrderService> builder)
        {
            builder.HasKey(os => new { os.OrderId, os.ServiceId });

            builder.HasOne(os => os.Order)
                .WithMany(o => o.OrderServices)
                .HasForeignKey(os => os.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(os => os.Service)
                .WithMany(s => s.OrderServices)
                .HasForeignKey(os => os.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            // Optionally, set the table name for the joint table
            builder.ToTable("OrderService");
        }
    }

    internal class CleaningServiceConfiguration : EntityTypeConfigurationBaseClass<CleaningService>
    {
        protected override void OnConfigure(EntityTypeBuilder<CleaningService> builder)
        {
            builder.ToTable(
                    "CleaningServices",
                    tableBuilder => tableBuilder.Property(cat => cat.Id).HasColumnName("CleaningServiceId"));
        }
    }

    internal class RepairingServiceConfiguration : EntityTypeConfigurationBaseClass<RepairingService>
    {
        protected override void OnConfigure(EntityTypeBuilder<RepairingService> builder)
        {
            builder.ToTable(
                    "RepairingServices",
                    tableBuilder => tableBuilder.Property(cat => cat.Id).HasColumnName("RepairingServiceId"));
        }
    }

    internal class ShoppingServiceConfiguration : EntityTypeConfigurationBaseClass<ShoppingService>
    {
        protected override void OnConfigure(EntityTypeBuilder<ShoppingService> builder)
        {
            builder.ToTable(
                    "ShoppingServices",
                    tableBuilder => tableBuilder.Property(cat => cat.Id).HasColumnName("ShoppingServiceId"));
        }
    }
}
