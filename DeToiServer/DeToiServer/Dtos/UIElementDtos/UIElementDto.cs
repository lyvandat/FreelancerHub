using DeToiServerCore.Models.SevicesUIElement;

namespace DeToiServer.Dtos.UIElementDtos
{
    public class UIElementValidationTypeDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Message { get; set; }
        public dynamic? Value { get; set; }
    }

    public class UIElementOptionInfoValidationDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Value { get; set; }
        public required string Message { get; set; }
        public required Guid InfoId { get; set; }
    }
    public class UIElementOptionInfoDto
    {
        public required Guid Id { get; set; }
        public required string Type { get; set; }
        public required string Label { get; set; }
        public string Mask { get; set; } = "default";
        public string DefaultValue { get; set; } = "default";
        public IEnumerable<string> Buttons { get; set; } = null!;
        public ICollection<UIElementOptionInfoValidationDto> Validation { get; set; } = null!;
        public Guid OptionId { get; set; }
    }

    public class UIElementInputOptionDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<UIElementOptionInfoDto> Info { get; set; } = null!;
    }

    public class UIElementInputMethodTypeDto
    {
        //public required Guid Id { get; set; }
        public required string Name { get; set; }
        public ICollection<UIElementInputOptionDto>? Options { get; set; } = null;
    }

    public class UIElementServiceRequirementInputMethodMidwayDto
    {
        //public required Guid Id { get; set; }
        public required string DataType { get; set; }
        public required UIElementInputMethodTypeDto Method { get; set; }
    }

    public class UIElementServiceRequirementInputMethodDto
    {
        //public required Guid Id { get; set; }
        public required string DataType { get; set; } 
        public required UIElementInputMethodTypeDto Method { get; set; }
        public required ICollection<UIElementValidationTypeDto> Validation { get; set; }
    }

    public class UIElementServiceRequirementDto
    {
        public required Guid Id { get; set; }
        public required UIElementServiceRequirementInputMethodDto InputMethod { get; set; }
        public required string Key { get; set; }
        public required string Label { get; set; }
        public int Priority { get; set; }
        public string? LabelIcon { get; set; }
        public string Placeholder { get; set; } = String.Empty;
    }

    public class UIElementAdditionServiceRequirementDto
    {
        public required Guid Id { get; set; }
        public required string Key { get; set; }
        public required string Icon { get; set; }
        public required string Label { get; set; }
        public int Priority { get; set; }
        public bool AutoSelect { get; set; }
    }
}

