using AutoMapper;
using DeToiServer.Dtos.ServiceProvenDtos;
using DeToiServerCore.Models.Services;
using Newtonsoft.Json;

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

        public async Task<ServiceProven> Add(PostServiceProvenDto serviceProven, bool before = false)
        {
            var proven = _mapper.Map<ServiceProven>(serviceProven);
            var jointPath = JsonConvert.SerializeObject(serviceProven.MediaPath);

            if (before)
            {
                proven.ImageBefore = jointPath;
            }
            else
            {
                proven.ImageAfter = jointPath;
            }

            return await _uow.ServiceProvenRepo.CreateAsync(proven);
        }

        public async Task<IEnumerable<GetServiceProvenDto>> GetAll()
        {
            var serviceProven = await _uow.ServiceProvenRepo.GetAllWithInfo();

            return serviceProven.Select(_mapper.Map<GetServiceProvenDto>);
        }

        public async Task<GetServiceProvenDto?> GetById(Guid id)
        {
            var serviceProven = await _uow.ServiceProvenRepo.GetByIdWithInfo(id);

            if (serviceProven == null)
            {
                return null;
            }

            var getSpDto = _mapper.Map<GetServiceProvenDto>(serviceProven);
            getSpDto.MediaPathBefore = JsonConvert.DeserializeObject<ICollection<string>>(serviceProven.ImageBefore);
            getSpDto.MediaPathAfter = JsonConvert.DeserializeObject<ICollection<string>>(serviceProven.ImageAfter);

            return getSpDto;
        }

        public async Task<ServiceProven?> GetByOrderId(Guid id)
        {
            return await _uow.ServiceProvenRepo.GetByConditionsAsync(sp => sp.OrderId == id);
        }
    }
}