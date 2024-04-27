using DeToiServerCore.Models.Accounts;
using DeToiServerCore.QueryModels.ServiceTypeQueryModels;

namespace DeToiServerData.Repositories.AdminRepo
{
    public interface IAdminRepo : IRepository<AdminAccount>
    {
        Task<IEnumerable<ServiceTypeDistributionModel>> GetServiceTypePercentage();
        Task<AdminAccount> GetAdminByAccIdAsync(Guid accId);
    }
}
