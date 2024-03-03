using DeToiServer.Dtos.ServiceProvenDtos;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Services.ServiceProvenService
{
    public interface IServiceProvenService
    {
        public Task<IEnumerable<ServiceProven>> GetAll();
        public Task<ServiceProven> GetById(Guid id);
        public Task<ServiceProven> Add(PostServiceProvenDto serviceProven);
    }
}
