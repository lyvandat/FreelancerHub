using DeToiServerCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeToiServerData.Configurations
{
    internal class ServiceOrderConfiguration : EntityTypeConfigurationBase<ServiceOrder>
    {
        protected override void OnConfigure(EntityTypeBuilder<ServiceOrder> builder)
        {
            builder.HasKey(e => e.Id).HasName("fk_ServiceOrder");
        }
    }

    internal class ServiceStatusConfiguration : EntityTypeConfigurationBase<ServiceStatus>
    {
        protected override void OnConfigure(EntityTypeBuilder<ServiceStatus> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }

    internal class ServiceTypeConfiguration : EntityTypeConfigurationBase<ServiceType>
    {
        protected override void OnConfigure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
