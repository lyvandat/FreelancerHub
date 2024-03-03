using AutoMapper;
using DeToiServer.Dtos.ServiceProvenDtos;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Services.ServiceProvenService
{
    public class ServiceProvenService : IServiceProvenService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public ServiceProvenService(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ServiceProven> Add(PostServiceProvenDto serviceProven)
            => await _uow.ServiceProvenRepo.CreateAsync(_mapper.Map<ServiceProven>(serviceProven));

        public async Task<IEnumerable<ServiceProven>> GetAll()
            => await _uow.ServiceProvenRepo.GetAllAsync();

        public async Task<ServiceProven> GetById(Guid id)
            => await _uow.ServiceProvenRepo.GetByIdAsync(id);
    }
}
