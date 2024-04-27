using DeToiServerCore.Models.Accounts;
using DeToiServerCore.QueryModels.FreelanceSkillQueryModels;
using System.Linq.Expressions;

namespace DeToiServerData.Repositories.FreelanceSkillRepo
{
    public interface IFreelanceSkillRepo : IRepository<Skill>
    {
        Task<IEnumerable<FreelanceSkill>> ChooseFreelancerSkillsAsync(Guid freelancerId, IEnumerable<Guid> skills);
        Task<IEnumerable<Skill>> GetFreelancerSkillInCategoryAsync(Guid categoryId, int? length);
        Task<IEnumerable<Skill>> SeachFreelanceSkillsAsync(FreelanceSkillQuery search);
    }
}
