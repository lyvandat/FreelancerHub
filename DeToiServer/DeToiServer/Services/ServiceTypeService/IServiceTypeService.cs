using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServerCore.Models.Services;
using DeToiServerCore.QueryModels.ServiceTypeQueryModels;

namespace DeToiServer.Services.ServiceTypeService
{
    public interface IServiceTypeService
    {
        public Task<IEnumerable<GetServiceTypeDto>> GetAll();
        public Task<GetServiceTypeDto> GetById(Guid id);
        public Task<ServiceType> Add(PostServiceTypeDto service);
        public Task Update(PutServiceTypeDto service);
        public Task Delete(Guid id);
        public Task<IEnumerable<GetServiceTypeDto>> GetAllServiceInfo(FilterServiceTypeQuery query);
    }
}
