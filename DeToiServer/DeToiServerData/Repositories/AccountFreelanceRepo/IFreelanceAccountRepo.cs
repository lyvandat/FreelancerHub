using DeToiServerCore.Models.Accounts;
using System.Linq.Expressions;

namespace DeToiServerData.Repositories.AccountFreelanceRepo;

public interface IFreelanceAccountRepo : IRepository<FreelanceAccount>
{
    Task<FreelanceAccount> GetByAccId(Guid id);
    Task<FreelanceAccount> GetByAccIdWithWallet(Guid id);
    Task<FreelanceAccount> GetByAccPhone(string phone);
    Task<FreelanceAccount> GetDetailByIdWithStatistic(Guid id);
    Task<IEnumerable<FreelanceAccount>> GetAllDetail();
    Task<IEnumerable<FreelanceServiceType>> ChooseFreelancerServiceTypesAsync(Guid freelancerId, IEnumerable<Guid> serviceTypes);
    Task<IEnumerable<FreelanceServiceType>> RemoveFreelancerServiceTypesAsync(Guid freelancerId, IEnumerable<Guid> serviceTypes);
    Task<IEnumerable<FreelanceAccount>> GetManyByConditionsAsync(Expression<Func<FreelanceAccount, bool>> predicate);
    Task<bool> RefundAuctionBalance(IEnumerable<Guid> accIds, IDictionary<Guid, double> aunctionPrice);
}
