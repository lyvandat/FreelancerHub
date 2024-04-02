using DeToiServer.Dtos.ServiceProvenDtos;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Services.ServiceProvenService
{
    public interface IServiceProvenService
    {
        public Task<IEnumerable<GetServiceProvenDto>> GetAll();
        public Task<GetServiceProvenDto?> GetById(Guid id);
        public Task<ServiceProven?> GetByOrderId(Guid id);
        public Task<ServiceProven> Add(PostServiceProvenDto serviceProven, bool before = false);
    }
}