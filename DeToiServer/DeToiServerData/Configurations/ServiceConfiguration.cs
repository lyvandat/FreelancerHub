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

    internal class ServiceStatusConfiguration : EntityTypeConfigurationBaseClass<ServiceStatus>
    {
        protected override void OnConfigure(EntityTypeBuilder<ServiceStatus> builder)
        {
            builder.HasData(
                new List<ServiceStatus>
                {
                    new ServiceStatus { Id = Guid.Parse("8a9f22f1-3c67-49f7-bd84-ec290e4a37fd"), Name = "Chờ xử lí" },
                    new ServiceStatus { Id = Guid.NewGuid(), Name = "Đã tiếp nhận" },
                    new ServiceStatus { Id = Guid.NewGuid(), Name = "Đã hoàn thành" },
                }
            );
        }
    }

    internal class ServiceCategoryConfiguration : EntityTypeConfigurationBaseClass<ServiceCategory>
    {
        protected override void OnConfigure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasData(
                new List<ServiceCategory>
                {
                    new ServiceCategory { Id = new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e"), Name = "Dọn dẹp", Description = "Bao gồm lau nhà, quét nhà, hút bụi, và nhiều dịch vụ khác", Image = "image" },
                    new ServiceCategory { Id = new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f"), Name = "Mua sắm", Description = "Bao gồm đi chợ, siêu thị, nhà sách, và nhiều dịch vụ khác", Image = "image" },
                    new ServiceCategory { Id = new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a"), Name = "Sửa chữa", Description = "Bao gồm sửa máy lạnh, tủ lạnh, và nhiều dịch vụ khác", Image = "image" },
                }
            );
        }
    }

    internal class ServiceTypeConfiguration : EntityTypeConfigurationBaseClass<ServiceType>
    {
        protected override void OnConfigure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.HasData(
                new List<ServiceType>
                {
                    new ServiceType { Id = Guid.NewGuid(), Name = "Lau nhà", BasePrice = 50000, Description = "Lau nhà sạch", ServiceCategoryId = new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Quét nhà", BasePrice = 55000, Description = "Quét nhà sạch", ServiceCategoryId = new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Hút bụi", BasePrice = 40000, Description = "Hút bụi sạch", ServiceCategoryId = new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Lau cửa kính", BasePrice = 30000, Description = "Lau cửa kính sạch", ServiceCategoryId = new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Giặt thảm", BasePrice = 100000, Description = "Giặt thảm sạch", ServiceCategoryId = new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Giặt ga giường", BasePrice = 120000, Description = "Giặt ga giường", ServiceCategoryId = new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Vệ sinh máy lạnh", BasePrice = 150000, Description = "Vệ sinh máy lạnh", ServiceCategoryId = new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },

                    new ServiceType { Id = Guid.NewGuid(), Name = "Đi chợ hộ", BasePrice = 40000, Description = "Mua sắm hộ siêu nhanh", ServiceCategoryId = new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Đi siêu thị hộ", BasePrice = 50000, Description = "Mua sắm hộ siêu nhanh", ServiceCategoryId = new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Đi siêu thị sang trọng", BasePrice = 100000, Description = "Mua sắm hộ siêu nhanh", ServiceCategoryId = new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Đi mua quần áo", BasePrice = 60000, Description = "Mua sắm hộ siêu nhanh", ServiceCategoryId = new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Đi mua giày camping", BasePrice = 300000, Description = "Mua sắm hộ siêu nhanh", ServiceCategoryId = new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Đi mua vé concert", BasePrice = 4000000, Description = "Mua sắm hộ siêu nhanh", ServiceCategoryId = new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Đi mua vé xem phim", BasePrice = 20000, Description = "Mua sắm hộ siêu nhanh", ServiceCategoryId = new Guid("6f57d993-eb26-4b35-8c7d-7871a7fd624f") },

                    new ServiceType { Id = Guid.NewGuid(), Name = "Sửa máy giặt", BasePrice = 200000, Description = "Sửa máy giặt", ServiceCategoryId = new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Sửa máy lạnh", BasePrice = 200000, Description = "Sửa chữa để tôi lo", ServiceCategoryId = new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Sửa bàn ủi", BasePrice = 200000, Description = "Sửa chữa để tôi lo", ServiceCategoryId = new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Sửa tivi", BasePrice = 200000, Description = "Sửa chữa để tôi lo", ServiceCategoryId = new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Sửa ống nước", BasePrice = 200000, Description = "Sửa chữa để tôi lo", ServiceCategoryId = new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Sửa bình gas", BasePrice = 50000000, Description = "Hãy yên tâm không nổ đâu", ServiceCategoryId = new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                    new ServiceType { Id = Guid.NewGuid(), Name = "Sửa máy tính laptop", BasePrice = 200000, Description = "Hãy yên tâm không nổ đâu", ServiceCategoryId = new Guid("8a21b21e-dc31-49c8-8b5b-84b69204dc3a") },
                }
            );
        }
    }
}
