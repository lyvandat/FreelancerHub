using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Services.ServiceTypeService
{
    public interface IServiceTypeService
    {
        public Task<IEnumerable<GetServiceTypeDto>> GetAll();
        public Task<GetServiceTypeDto> GetById(int id);
        public Task<ServiceType> Add(PostServiceTypeDto service);
        public Task Update(PutServiceTypeDto service);
        public Task Delete(int id);
    }
}
