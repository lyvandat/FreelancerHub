namespace DeToiServer.Dtos.SkillDtos
{
    public class ChoosenSkillDto
    {
        public Guid Id { get; set; }
    }

    public class ChooseFreelancerSkillsDto
    {
        public Guid FreelancerId { get; set; }
        public required IEnumerable<ChoosenSkillDto> Skills { get; set; }
    }
}
