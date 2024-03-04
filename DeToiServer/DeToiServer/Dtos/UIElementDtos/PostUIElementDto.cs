namespace DeToiServer.Dtos.UIElementDtos
{
    public class PostUIElementValidationTypeDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Message { get; set; }
        public dynamic? Value { get; set; }
    }
}
