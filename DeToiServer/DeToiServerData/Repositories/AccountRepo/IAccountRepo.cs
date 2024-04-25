using DeToiServer.Dtos.AccountDtos;
using DeToiServerCore.Models.Accounts;
using System.Linq.Expressions;

namespace DeToiServerData.Repositories;

public interface IAccountRepo : IRepository<Account>
{
    Task<IEnumerable<Account>> GetAllAccountInfoAsync(FilterAccountQuery searchAccount);
    Task<IEnumerable<Account>> GetAllAccountByConditionAsync(Expression<Func<Account, bool>> predictate);
}
