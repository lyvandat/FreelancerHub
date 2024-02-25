using DeToiServerCore.Models.Infos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeToiServerData.Configurations
{
    internal class HomeInfoConfiguration : EntityTypeConfigurationBaseClass<HomeInfo>
    {
        protected override void OnConfigure(EntityTypeBuilder<HomeInfo> builder)
        {
            builder.HasData(
                new List<HomeInfo>
                {
                    new HomeInfo() { Id = Guid.NewGuid(), Image = "image", Name = "Phòng trọ", Size = "10x20" },
                    new HomeInfo() { Id = Guid.NewGuid(), Image = "image", Name = "Nhà / Nhà phố", Size = "30x30" },
                    new HomeInfo() { Id = Guid.NewGuid(), Image = "image", Name = "Căn hộ chung cư", Size = "40x40" },
                    new HomeInfo() { Id = Guid.NewGuid(), Image = "image", Name = "Biệt thự", Size = "200x200" },
                }
            );
        }
    }

    internal class ShoppingInfoConfiguration : EntityTypeConfigurationBaseClass<ShoppingInfo>
    {
        protected override void OnConfigure(EntityTypeBuilder<ShoppingInfo> builder)
        {
            builder.HasData(
                new List<ShoppingInfo>
                {
                    new ShoppingInfo() { Id = Guid.NewGuid(), Name = "Đi chợ truyền thống", Image = "image" },
                    new ShoppingInfo() { Id = Guid.NewGuid(), Name = "Đi siêu thị", Image = "image" },
                    new ShoppingInfo() { Id = Guid.NewGuid(), Name = "Đi siêu thị sang trọng", Image = "image" },
                    new ShoppingInfo() { Id = Guid.NewGuid(), Name = "Đi mua quần áo", Image = "image" },
                    new ShoppingInfo() { Id = Guid.NewGuid(), Name = "Đi mua giày camping", Image = "image" },
                    new ShoppingInfo() { Id = Guid.NewGuid(), Name = "Đi mua vé xem phim", Image = "image" },
                }
            );
        }
    }
}