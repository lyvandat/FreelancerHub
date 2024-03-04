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

        public async Task<IEnumerable<GetServiceProvenDto>> GetAll()
        {
            var serviceProven = await _uow.ServiceProvenRepo.GetAllWithInfo();

            return serviceProven.Select(_mapper.Map<GetServiceProvenDto>);
        }

        public async Task<GetServiceProvenDto> GetById(Guid id)
            => _mapper.Map<GetServiceProvenDto>(await _uow.ServiceProvenRepo.GetByIdWithInfo(id));
    }
}