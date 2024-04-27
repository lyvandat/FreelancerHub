using DeToiServerCore.Models.Accounts;
using System.Linq.Expressions;

namespace DeToiServerData.Repositories.AccountFreelanceRepo;

public interface IFreelanceAccountRepo : IRepository<FreelanceAccount>
{
    Task<FreelanceAccount> GetByAccId(Guid id);
    Task<FreelanceAccount> GetByAccPhone(string phone);
    Task<FreelanceAccount> GetDetailByIdWithStatistic(Guid id);
    Task<IEnumerable<FreelanceAccount>> GetAllDetail();
    Task ChooseFreelancerServiceTypesAsync(IEnumerable<FreelanceServiceType> serviceTypes);
    Task RemoveFreelancerServiceTypesAsync(IEnumerable<FreelanceServiceType> serviceTypes);
    Task<IEnumerable<FreelanceAccount>> GetManyByConditionsAsync(Expression<Func<FreelanceAccount, bool>> predicate);
}
