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
                    new ServiceType { Id = new Guid("3b8a2d6a-b0e7-46af-a688-397cea642603"), Name = "Phòng trọ", BasePrice = 30000, Description = "Dọn dẹp Phòng trọ", Image="https://detoivn.sirv.com/services/dondep/phongtro.png", ServiceCategoryId = new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    new ServiceType { Id = new Guid("49a42267-d9dc-4e11-87a5-36525d4254d9"), Name = "Biệt thự", BasePrice = 55000, Description = "Dọn dẹp Biệt thự", Image="https://detoivn.sirv.com/services/dondep/bietthu.png", ServiceCategoryId = new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    new ServiceType { Id = new Guid("ef2632f0-47bd-4bbe-a46f-628a28f03d8b"), Name = "Nhà / Nhà phố", BasePrice = 50000, Description = "Dọn dẹp Nhà / Nhà phố", Image="https://detoivn.sirv.com/services/dondep/n%C3%A2-nhapho.png", ServiceCategoryId = new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },
                    new ServiceType { Id = new Guid("dbb78597-043d-47c1-8810-93d392fd09ba"), Name = "Căn hộ chung cư", BasePrice = 40000, Description = "Dọn dẹp Căn hộ chung cư", Image="https://detoivn.sirv.com/services/dondep/chungcu.jpg", ServiceCategoryId = new Guid("d17ad87c-9f80-4f0e-bfd4-53138d900a6e") },

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
