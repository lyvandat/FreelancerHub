using DeToiServer.Dtos.SkillDtos;
using DeToiServerCore.QueryModels.FreelanceSkillQueryModels;

namespace DeToiServer.Services.FreelanceSkillService
{
    public interface IFreelanceSkillService
    {
        Task<IEnumerable<SkillDto>> GetAllSkills();
        Task<bool> AddSkillsFreelancer(ChooseFreelancerSkillsDto skills);
        Task<IEnumerable<SkillDto>> GetAllSkillInCategory(Guid categoryId, int? length);
        Task<IEnumerable<SkillDto>> SearchFreelancerSkills(FreelanceSkillQuery search);
    }
}
