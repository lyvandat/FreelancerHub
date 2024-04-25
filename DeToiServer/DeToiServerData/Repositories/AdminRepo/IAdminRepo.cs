using DeToiServerCore.QueryModels.ServiceTypeQueryModels;

namespace DeToiServerData.Repositories.AdminRepo
{
    public interface IAdminRepo
    {
        Task<IEnumerable<ServiceTypeDistributionModel>> GetServiceTypePercentage();
    }
}
