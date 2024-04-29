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

            builder.HasMany(o => o.PaymentHistories)
                .WithOne(ph => ph.Order)
                .HasForeignKey(ph => ph.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    internal class OrderAddressConfiguration : EntityTypeConfigurationBaseClass<OrderAddress>
    {
        protected override void OnConfigure(EntityTypeBuilder<OrderAddress> builder)
        {
            builder.HasKey(oa => new { oa.OrderId, oa.AddressId });

            builder.HasOne(oa => oa.Address)
                .WithMany(add => add.OrderAddress)
                .HasForeignKey(oa => oa.AddressId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(oa => oa.Order)
                .WithMany(ord => ord.OrderAddress)
                .HasForeignKey(oa => oa.OrderId)
                .OnDelete(DeleteBehavior.ClientCascade);
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
                    new ServiceStatus { Id = StatusConst.Created, Name = "Đơn vừa tạo", Icon = "faWandMagicSparkles", Priority = 0 },
                    new ServiceStatus { Id = StatusConst.OnMatching, Name = "Đang ghép cặp", Icon = "faHandshake", Priority = 1 },
                    new ServiceStatus { Id = StatusConst.Waiting, Name = "Chưa đến giờ hoạt động", Icon = "faRoadCircleXmark", Priority = 2 },
                    new ServiceStatus { Id = StatusConst.OnDoingService, Name = "Đang làm việc", Icon = "faPersonDigging", Priority = 3 },
                    new ServiceStatus { Id = StatusConst.OnMoving, Name = "Đang di chuyển", Icon = "faPersonRunning", Priority = 3 },
                    new ServiceStatus { Id = StatusConst.OnDelivering, Name = "Đang vận chuyển", Icon = "faTruckFast", Priority = 3 },
                    new ServiceStatus { Id = StatusConst.Completed, Name = "Đã hoàn thành nhiệm vụ", Icon = "faPersonCircleCheck", Priority = 4 },
                    new ServiceStatus { Id = StatusConst.Canceled, Name = "Đơn đã hủy", Icon = "faHandshakeSimpleSlash", Priority = 5 }
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
            builder.Property(c => c.AddressRequireOption)
                .HasDefaultValue(GlobalConstant.AddressOption.Destination);
            builder.Property(st => st.Keys).HasDefaultValue("");
        }
    }

    internal class ServiceTypeStatusConfiguration : EntityTypeConfigurationBaseClass<ServiceTypeStatus>
    {
        protected override void OnConfigure(EntityTypeBuilder<ServiceTypeStatus> builder)
        {
            builder.HasKey(sts => new { sts.ServiceTypeId, sts.ServiceStatusId });

            builder.HasOne(sts => sts.ServiceType)
                .WithMany(st => st.ServiceStatusList)
                .HasForeignKey(sts => sts.ServiceTypeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(sts => sts.ServiceStatus)
                .WithMany(s => s.ServiceStatusList)
                .HasForeignKey(sts => sts.ServiceStatusId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
