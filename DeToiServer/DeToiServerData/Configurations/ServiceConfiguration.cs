using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models;
using DeToiServerCore.Models.Accounts;
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
        }
    }

    internal class OrderConfiguration : EntityTypeConfigurationBase<Order>
    {
        protected override void OnConfigure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Freelance)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.FreelancerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.ServiceStatus)
                .WithMany(ss => ss.Orders)
                .HasForeignKey(o => o.ServiceStatusId);

            builder.HasMany(o => o.ServiceProven)
                .WithOne(sp => sp.Order)
                .HasForeignKey(sp => sp.OrderId);

            builder.HasOne(o => o.Address)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(o => o.PaymentHistories)
                .WithOne(ph => ph.Order)
                .HasForeignKey(ph => ph.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    internal class BiddingOrderConfiguration : EntityTypeConfigurationBase<BiddingOrder>
    {
        protected override void OnConfigure(EntityTypeBuilder<BiddingOrder> builder)
        {
            builder.HasOne(bo => bo.Order)
                .WithMany(o => o.BiddingOrders)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bo => bo.Freelancer)
                .WithMany(f => f.BiddingOrders)
                .HasForeignKey(o => o.FreelancerId)
                .OnDelete(DeleteBehavior.Cascade);
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

    internal class OrderServiceTypeConfiguration : EntityTypeConfigurationBaseClass<OrderServiceType>
    {
        protected override void OnConfigure(EntityTypeBuilder<OrderServiceType> builder)
        {
            builder.HasKey(ost => new { ost.OrderId, ost.ServiceTypeId });

            builder.HasOne(ost => ost.Order)
                .WithMany(o => o.OrderServiceTypes)
                .HasForeignKey(os => os.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ost => ost.ServiceType)
                .WithMany(st => st.OrderServiceTypes)
                .HasForeignKey(ost => ost.ServiceTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    internal class ServiceStatusConfiguration : EntityTypeConfigurationBaseClass<ServiceStatus>
    {
        protected override void OnConfigure(EntityTypeBuilder<ServiceStatus> builder)
        {
            builder.HasData(
                new List<ServiceStatus>
                {
                    new ServiceStatus { Id = StatusConst.Created, Name = "Đơn vừa tạo" },
                    new ServiceStatus { Id = StatusConst.OnMatching, Name = "Đang ghép cặp" },
                    new ServiceStatus { Id = StatusConst.Waiting, Name = "Chưa đến giờ hoạt động" },
                    new ServiceStatus { Id = StatusConst.OnMoving, Name = "Đang di chuyển, hãy kiên nhẫn" },
                    new ServiceStatus { Id = StatusConst.OnDoingService, Name = "Đang làm việc" },
                    new ServiceStatus { Id = StatusConst.Completed, Name = "Đã hoàn thành nhiệm vụ" },
                    new ServiceStatus { Id = StatusConst.Canceled, Name = "Đơn đã hủy" },
                }
            );
        }
    }

    internal class ServiceCategoryConfiguration : EntityTypeConfigurationBaseClass<ServiceCategory>
    {
        protected override void OnConfigure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.Property(c => c.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.IsActivated)
                .HasDefaultValue(true);
        }
    }

    internal class ServiceTypeConfiguration : EntityTypeConfigurationBaseClass<ServiceType>
    {
        protected override void OnConfigure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.HasMany(st => st.ServiceProven)
                .WithOne(sp => sp.ServiceType)
                .HasForeignKey(sp => sp.ServiceTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.IsActivated)
                .HasDefaultValue(true);
        }
    }
}
