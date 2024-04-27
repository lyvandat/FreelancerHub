using DeToiServerCore.Models.Services;

namespace DeToiServerCore.Models.SevicesUIElement
{
    //public class RequirementDataDto
    //{
    //    public required string DataType { get; set; }
    //    public required string Name { get; set; }
    //    public string? Value { get; set; }
    //}

    // ===============================================

    public class UIElementValidationType : ModelBase
    {
        public required string Name { get; set; }
        public string? Value { get; set; } // This field need review - update later
        public required string Message { get; set; }
        public required Guid InputMethodId { get; set; }
        public required UIElementServiceRequirementInputMethod InputMethod { get; set; }
    }

    public class UIElementOptionInfoValidation : ModelBase
    {
        public required string Name { get; set; }
        public string? Value { get; set; }
        public required string Message { get; set; }
        public required Guid InfoId { get; set; }
        public required UIElementOptionInfo OptionInfo { get; set; }
    }
    public class UIElementOptionInfo : ModelBase
    {
        public required string Type { get; set; }
        public required string Label { get; set; }
        public string Mask { get; set; } = "default";
        public string DefaultValue { get; set; } = "default";
        public string Buttons { get; set; } = "default";
        public ICollection<UIElementOptionInfoValidation> Validations { get; set; } = null!;
        public Guid OptionId { get; set; }
        public UIElementInputOption InputOption { get; set; } = null!;
    }

    public class UIElementInputOption : ModelBase
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required Guid InputMethodTypeId { get; set; }
        public required UIElementInputMethodType InputMethodType { get; set; }
        public ICollection<UIElementOptionInfo> Info { get; set; } = null!;
    }

    public class UIElementInputMethodType : ModelBase
    {
        public required string Name { get; set; }
        public ICollection<UIElementInputOption>? Options { get; set; } = null;
        // ====
        public ICollection<UIElementServiceRequirementInputMethod>? InputMethods { get; set; }
    }

    public class UIElementServiceRequirementInputMethod : ModelBase
    {
        public required string DataType { get; set; } // 'number' | 'text' 

        public required Guid MethodId { get; set; }
        public required UIElementInputMethodType Method { get; set; }

        public required ICollection<UIElementValidationType> Validation { get; set; }

        public ICollection<UIElementServiceRequirement>? ServiceRequirements { get; set; }
    }

    public class UIElementServiceRequirement : ModelBase
    {
        public required Guid InputMethodId { get; set; }
        public required UIElementServiceRequirementInputMethod InputMethod { get; set; }
        public required string Key { get; set; }
        public required string Label { get; set; }
        public string? LabelIcon { get; set; }
        public string Placeholder { get; set; } = String.Empty;
        public int Priority { get; set; } = 0;

        public required Guid ServiceTypeId { get; set; }
        public required ServiceType ServiceType { get; set; }
    }

    public class UIElementAdditionServiceRequirement : ModelBase
    {
        public required string Key { get; set; }
        public required string Icon { get; set; }
        public required string Label { get; set; }
        public bool AutoSelect { get; set; }
        public int Priority { get; set; } = 0;

        public required Guid ServiceTypeId { get; set; }
        public required ServiceType ServiceType { get; set; }
    }
}
