namespace DeToiServer.Dtos.UIElementDtos
{
    public class UIElementValidationTypeDto
    {
        //public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Value { get; set; }
        public required string Message { get; set; }
    }

    public class UIElementInputOptionDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }

    public class UIElementInputMethodTypeDto
    {
        //public required Guid Id { get; set; }
        public required string Name { get; set; }
        public ICollection<UIElementInputOptionDto>? Options { get; set; } = null;
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
        public required string Label { get; set; }
        public string? LabelIcon { get; set; }
        public string Placeholder { get; set; } = String.Empty;
    }

    public class UIElementAdditionServiceRequirementDto
    {
        public required Guid Id { get; set; }
        public required string Icon { get; set; }
        public required string Label { get; set; }
        public bool AutoSelect { get; set; }
    }
}

