using DeToiServer.Dtos.ServiceProvenDtos;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Services.ServiceProvenService
{
    public interface IServiceProvenService
    {
        public Task<IEnumerable<GetServiceProvenDto>> GetAll();
        public Task<GetServiceProvenDto> GetById(Guid id);
        public Task<ServiceProven> Add(PostServiceProvenDto serviceProven);
    }
}