using AutoMapper;
using DeToiServer.Services.ServiceInfoService;
using DeToiServerCore.Models.Infos;

namespace DeToiServer.Services.ServiceTypeService
{
    public class HomeInfoService : IHomeInfoService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public HomeInfoService(UnitOfWork uow, IMapper mapper) 
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HomeInfo>> GetAll()
            => await _uow.HomeInfoRepo.GetAllAsync();
    }
}
