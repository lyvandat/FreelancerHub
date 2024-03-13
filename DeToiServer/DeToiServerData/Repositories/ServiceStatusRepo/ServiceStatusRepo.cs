using DeToiServerCore.Models.Services;

namespace DeToiServerData.Repositories.ServiceStatusRepo
{
    public class ServiceStatusRepo : RepositoryBase<ServiceStatus>, IServiceStatusRepo
    {
        public ServiceStatusRepo(DataContext context) : base(context)
        {
            
        }
    }
}
