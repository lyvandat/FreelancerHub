using DeToiServerCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeToiServerData.Configurations
{
    internal abstract class EntityTypeConfigurationBase<TModel> : IEntityTypeConfiguration<TModel> 
        where TModel : ModelBase
    {
        public void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Id)
                .ValueGeneratedOnAdd();
            OnConfigure(builder);
        }

        protected abstract void OnConfigure(EntityTypeBuilder<TModel> builder);
    }

    internal abstract class EntityTypeConfigurationBaseClass<TModel> : IEntityTypeConfiguration<TModel>
        where TModel : class
    {
        public void Configure(EntityTypeBuilder<TModel> builder)
        {
            OnConfigure(builder);
        }

        protected abstract void OnConfigure(EntityTypeBuilder<TModel> builder);
    }
}
