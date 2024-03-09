using DeToiServerCore.Models.Services;
using DeToiServerCore.QueryModels.ServiceTypeQueryModels;

namespace DeToiServerData.Repositories.ServiceTypeRepo
{
    public interface IServiceTypeRepo : IRepository<ServiceType>
    {
        public Task<IEnumerable<ServiceType>> GetAllWithCategory();
        public Task<ServiceType> GetByIdWithCategory(Guid id);
        public Task<IEnumerable<ServiceType>> GetAllServiceTypeInfoAsync(FilterServiceTypeQuery query);
        public Task<ServiceType> GetServiceTypeDetailWithRequirements(Guid id);
        public Task<ServiceType> AddOrderServiceType(Guid serviceTypeId, Guid orderId);
    }
}
