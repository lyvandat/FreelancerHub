using DeToiServerCore.Models.Services;

namespace DeToiServerData.Repositories;

public class ServiceProvenRepo(DataContext context) : RepositoryBase<ServiceProven>(context), IServiceProvenRepo
{
}
