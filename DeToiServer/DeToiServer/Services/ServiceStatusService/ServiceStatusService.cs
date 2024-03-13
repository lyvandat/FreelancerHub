using AutoMapper;
using DeToiServer.Dtos.ServiceStatusDtos;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Services.ServiceStatusService
{
    public class ServiceStatusService : IServiceStatusService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public ServiceStatusService(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetServiceStatusDto>> GetAll()
        {
            var rawServiceStatuses = await _uow.ServiceStatusRepo.GetAllAsync();

            return rawServiceStatuses.Select(_mapper.Map<GetServiceStatusDto>);
        }
    }
}
