using DeToiServer.Dtos.SkillDtos;

namespace DeToiServer.Services.FreelanceSkillService
{
    public interface IFreelanceSkillService
    {
        Task<IEnumerable<SkillDto>> GetAllSkills();
    }
}
