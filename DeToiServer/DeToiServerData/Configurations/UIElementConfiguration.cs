using DeToiServerCore.Models.Services;
using DeToiServerCore.Models.SevicesUIElement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerData.Configurations
{
    internal class UIElementInputMethodTypeConfiguration : EntityTypeConfigurationBase<UIElementInputMethodType>
    {
        protected override void OnConfigure(EntityTypeBuilder<UIElementInputMethodType> builder)
        {
            builder.HasMany(mt => mt.InputMethods)
                .WithOne(input => input.Method)
                .HasForeignKey(input => input.MethodId)
                .IsRequired();
        }
    }

    internal class UIElementInputOptionConfiguration : EntityTypeConfigurationBase<UIElementInputOption>
    {
        protected override void OnConfigure(EntityTypeBuilder<UIElementInputOption> builder)
        {
            builder.HasOne(option => option.InputMethodType)
                .WithMany(mt => mt.Options)
                .HasForeignKey(option => option.InputMethodTypeId)
                .IsRequired();
        }
    }

    internal class UIElementOptionInfoConfiguration : EntityTypeConfigurationBase<UIElementOptionInfo>
    {
        protected override void OnConfigure(EntityTypeBuilder<UIElementOptionInfo> builder)
        {
            builder.HasOne(oInfo => oInfo.InputOption)
                .WithMany(opt => opt.Info)
                .HasForeignKey(oInfo => oInfo.OptionId)
                .IsRequired();
        }
    }

    internal class UIElementOptionInfoValidationConfiguration : EntityTypeConfigurationBase<UIElementOptionInfoValidation>
    {
        protected override void OnConfigure(EntityTypeBuilder<UIElementOptionInfoValidation> builder)
        {
            builder.HasOne(infoVal => infoVal.OptionInfo)
                .WithMany(info => info.Validations)
                .HasForeignKey(infoVal => infoVal.InfoId)
                .IsRequired();
        }
    }

    internal class UIElementServiceRequirementInputMethodConfiguration : EntityTypeConfigurationBase<UIElementServiceRequirementInputMethod>
    {
        protected override void OnConfigure(EntityTypeBuilder<UIElementServiceRequirementInputMethod> builder)
        {
            builder.HasMany(input => input.ServiceRequirements)
                .WithOne(req => req.InputMethod)
                .HasForeignKey(req => req.InputMethodId);

            //builder.HasOne(input => input.Method)
            //    .WithMany(mt => mt.InputMethods)
            //    .HasForeignKey(input => input.MethodId)
            //    .IsRequired(true);

            builder.HasMany(input => input.Validation)
                .WithOne(val => val.InputMethod)
                .HasForeignKey(val => val.InputMethodId)
                .IsRequired();
        }
    }

    internal class UIElementValidationTypeConfiguration : EntityTypeConfigurationBase<UIElementValidationType>
    {
        protected override void OnConfigure(EntityTypeBuilder<UIElementValidationType> builder)
        {
        }
    }

    internal class UIElementServiceRequirementConfiguration : EntityTypeConfigurationBase<UIElementServiceRequirement>
    {
        protected override void OnConfigure(EntityTypeBuilder<UIElementServiceRequirement> builder)
        {
            builder.HasOne(req => req.ServiceType)
                .WithMany(s => s.Requirements)
                .HasForeignKey(req => req.ServiceTypeId)
                .IsRequired();

            builder.Property(sr => sr.Priority).HasDefaultValue(0);
        }
    }

    internal class UIElementAdditionServiceRequirementConfiguration : EntityTypeConfigurationBase<UIElementAdditionServiceRequirement>
    {
        protected override void OnConfigure(EntityTypeBuilder<UIElementAdditionServiceRequirement> builder)
        {
            builder.HasOne(aReq => aReq.ServiceType)
                .WithMany(s => s.AdditionalRequirements)
                .HasForeignKey(aReq => aReq.ServiceTypeId)
                .IsRequired();

            builder.Property(sar => sar.Priority).HasDefaultValue(0);
        }
    }
}
