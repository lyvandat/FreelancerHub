using DeToiServer.Dtos.SkillDtos;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.QueryModels.FreelanceSkillQueryModels;

namespace DeToiServer.Services.FreelanceSkillService
{
    public interface IFreelanceSkillService
    {
        Task<IEnumerable<SkillDto>> GetAllSkills();
        Task<IEnumerable<FreelanceSkill>> AddSkillsFreelancer(Guid freelancerId, IEnumerable<Guid> skills);
        Task<IEnumerable<SkillDto>> GetAllSkillInCategory(Guid categoryId, int? length);
        Task<IEnumerable<SkillDto>> SearchFreelancerSkills(FreelanceSkillQuery search);
    }
}
