using DeToiServerCore.Models.Services;

namespace DeToiServerCore.Models.Accounts
{
    public class Skill : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public string SkillCategory { get; set; } = string.Empty;
        public ICollection<FreelanceSkill>? FreelanceSkills { get; set; }
        public ICollection<SkillServiceType>? ServiceTypeOfSkill { get; set; }
        public ICollection<OrderSkillRequired>? RequiredOrders { get; set; }
    }
}
