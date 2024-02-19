using DeToiServerCore.Models.Services;
using DeToiServerCore.QueryModels.ServiceTypeQueryModels;

namespace DeToiServerData.Repositories.ServiceTypeRepo
{
    public interface IServiceTypeRepo : IRepository<ServiceType>
    {
        public Task<IEnumerable<ServiceType>> GetAllWithCategory();
        public Task<ServiceType> GetByIdWithCategory(int id);
        public Task<IEnumerable<ServiceType>> GetAllServiceTypeInfoAsync(FilterServiceTypeQuery query);
    }
}
