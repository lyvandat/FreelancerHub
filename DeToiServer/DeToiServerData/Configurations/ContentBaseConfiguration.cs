using DeToiServerCore.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeToiServerCore.Models.Services;

namespace DeToiServerData.Configurations
{
    internal abstract class ContentBaseConfiguration<TModel> : IEntityTypeConfiguration<TModel>
        where TModel : ContentBaseModel
    {
        public void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content)
                .HasColumnType("text");

            OnConfigure(builder);
        }

        protected abstract void OnConfigure(EntityTypeBuilder<TModel> builder);
    }

    internal class BlogPostConfiguration : ContentBaseConfiguration<BlogPost>
    {
        protected override void OnConfigure(EntityTypeBuilder<BlogPost> builder)
        {
        }
    }

    internal class TermOfServiceConfiguration : ContentBaseConfiguration<TermOfService>
    {
        protected override void OnConfigure(EntityTypeBuilder<TermOfService> builder)
        {
        }
    }

    internal class FrequentlyAskedQuestionConfiguration : ContentBaseConfiguration<FrequentlyAskedQuestion>
    {
        protected override void OnConfigure(EntityTypeBuilder<FrequentlyAskedQuestion> builder)
        {
        }
    }
}
