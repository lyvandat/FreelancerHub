namespace DeToiServer.Dtos.UIElementDtos
{
    public class PostUIElementValidationTypeDto
    {
        public required string Name { get; set; }
        public required string Message { get; set; }
        public dynamic? Value { get; set; }
    }

    public class PostUIElementOptionInfoValidationDto
    {
        public required string Name { get; set; }
        public dynamic? Value { get; set; }
        public required string Message { get; set; }
    }
    public class PostUIElementOptionInfoDto
    {
        public required string Type { get; set; }
        public required string Label { get; set; }
        public string Mask { get; set; } = "default";
        public dynamic DefaultValue { get; set; } = null!;
        public IEnumerable<string>? Buttons { get; set; }
        public IEnumerable<PostUIElementOptionInfoValidationDto> Validation { get; set; } = null!;
    }

    public class PostUIElementInputOptionDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<PostUIElementOptionInfoDto>? Info { get; set; }// Must be empty -> Optional
    }

    public class PostUIElementInputMethodTypeDto
    {
        public required string Name { get; set; }
        public IEnumerable<PostUIElementInputOptionDto>? Options { get; set; } // Must be empty -> Optional
    }

    public class PostUIElementServiceRequirementInputMethodDto
    {
        public required string DataType { get; set; }
        public required PostUIElementInputMethodTypeDto Method { get; set; }
        public required IEnumerable<PostUIElementValidationTypeDto> Validation { get; set; }
    }

    public class PostUIElementServiceRequirementDto
    {
        public required PostUIElementServiceRequirementInputMethodDto InputMethod { get; set; }
        public required string Label { get; set; }
        public int Priority { get; set; }
        public string? LabelIcon { get; set; }
        public string Placeholder { get; set; } = String.Empty;
    }

    public class PostUIElementAdditionServiceRequirementDto
    {
        public required string Icon { get; set; }
        public required string Label { get; set; }
        public int Priority { get; set; }
        public bool AutoSelect { get; set; }
    }
}
