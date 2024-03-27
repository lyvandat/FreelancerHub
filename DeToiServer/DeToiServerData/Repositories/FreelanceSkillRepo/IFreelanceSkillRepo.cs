using DeToiServerCore.Models.Accounts;

namespace DeToiServerData.Repositories.FreelanceSkillRepo
{
    public interface IFreelanceSkillRepo : IRepository<Skill>
    {
        Task ChooseFreelancerSkillsAsync(IEnumerable<FreelanceSkill> skills);
    }
}
