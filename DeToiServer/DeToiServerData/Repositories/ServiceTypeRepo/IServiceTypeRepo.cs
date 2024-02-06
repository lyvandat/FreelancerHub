using DeToiServerCore.Models.Services;

namespace DeToiServerData.Repositories.ServiceTypeRepo
{
    public interface IServiceTypeRepo : IRepository<ServiceType>
    {
        public Task<IEnumerable<ServiceType>> GetAllWithCategory();
        public Task<ServiceType> GetByIdWithCategory(int id);
    }
}
