using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.ServiceInfoDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServerCore.Models.Infos;
using DeToiServerCore.Models.Services;
using DeToiServerCore.QueryModels.ServiceTypeQueryModels;

namespace DeToiServer.Services.ServiceInfoService
{
    public interface IHomeInfoService
    {
        public Task<IEnumerable<HomeInfo>> GetAll();
    }
}
