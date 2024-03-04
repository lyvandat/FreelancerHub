using DeToiServerCore.Models.Services;
using DeToiServerData.Specifications.ServiceProvenSpecification;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories;

public class ServiceProvenRepo(DataContext context) : RepositoryBase<ServiceProven>(context), IServiceProvenRepo
{
    public async Task<IEnumerable<ServiceProven>> GetAllWithInfo()
        => await ApplySpecification(new ServiceProvenWithOrderAndService()).ToListAsync();

    public async Task<ServiceProven> GetByIdWithInfo(Guid id)
        => await ApplySpecification(new ServiceProvenByIdWithOrderAndService(st => st.Id == id)).FirstOrDefaultAsync();
}