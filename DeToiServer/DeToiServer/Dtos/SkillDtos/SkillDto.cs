namespace DeToiServer.Dtos.SkillDtos
{
    public class SkillDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SkillCategory { get; set; } = string.Empty;
    }
}
