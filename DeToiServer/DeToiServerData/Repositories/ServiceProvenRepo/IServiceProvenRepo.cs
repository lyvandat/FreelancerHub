using DeToiServerCore.Models.Services;
using DeToiServerData.Specifications.ServiceProvenSpecification;

namespace DeToiServerData.Repositories;

public interface IServiceProvenRepo : IRepository<ServiceProven>
{
    Task<IEnumerable<ServiceProven>> GetAllWithInfo();
    Task<ServiceProven> GetByIdWithInfo(Guid id);
}