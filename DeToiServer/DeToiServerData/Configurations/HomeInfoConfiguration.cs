using DeToiServerCore.Models.Infos;
using DeToiServerCore.Models.Services;
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
}
