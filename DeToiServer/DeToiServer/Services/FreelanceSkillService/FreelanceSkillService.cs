using AutoMapper;
using DeToiServer.Dtos.SkillDtos;

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
    }
}
