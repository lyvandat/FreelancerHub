using AutoMapper;
using DeToiServer.Dtos.SkillDtos;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.QueryModels.FreelanceSkillQueryModels;

namespace DeToiServer.Services.FreelanceSkillService
{
    public class FreelanceSkillService : IFreelanceSkillService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public FreelanceSkillService(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillDto>> GetAllSkills()
        {
            return _mapper.Map<IEnumerable<SkillDto>>(await _uow.FreelanceSkillRepo.GetAllAsync());
        }

        public async Task<IEnumerable<SkillDto>> GetAllSkillInCategory(Guid categoryId, int? length)
        {
            var skills = await _uow.FreelanceSkillRepo.GetFreelancerSkillInCategoryAsync(categoryId, length);
            return _mapper.Map<IEnumerable<SkillDto>>(skills);
        }

        public async Task<IEnumerable<SkillDto>> SearchFreelancerSkills(FreelanceSkillQuery search)
        {
            var skills = await _uow.FreelanceSkillRepo.SeachFreelanceSkillsAsync(search);

            return _mapper.Map<IEnumerable<SkillDto>>(skills);
        }

        public async Task<bool> AddSkillsFreelancer(ChooseFreelancerSkillsDto skills)
        {
            var toAdd = skills.Skills.Select(s => new FreelanceSkill()
            {
                FreelancerId = skills.FreelancerId, 
                Freelancer = null!,
                SkillId = s.Id,
                Skill = null!,
            }).ToList();

            await _uow.FreelanceSkillRepo.ChooseFreelancerSkillsAsync(toAdd);
            return await _uow.SaveChangesAsync();
        }
    }
}
