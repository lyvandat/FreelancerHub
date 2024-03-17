namespace DeToiServerCore.Models.Accounts
{
    public class FreelanceSkill
    {
        public required Guid FreelancerId { get; set; }
        public required FreelanceAccount Freelancer { get; set; }
        public required Guid SkillId { get; set; }
        public required Skill Skill { get; set; }
    }
}
