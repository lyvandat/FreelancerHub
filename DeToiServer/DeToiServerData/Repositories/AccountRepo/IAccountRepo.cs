using DeToiServer.Dtos.AccountDtos;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.QueryModels.AccountQueryModels;
using System.Linq.Expressions;

namespace DeToiServerData.Repositories;

public interface IAccountRepo : IRepository<Account>
{
    Task<IEnumerable<Account>> GetAllAccountInfoAsync(FilterAccountQuery searchAccount);
    Task<IEnumerable<Account>> GetAllAccountByConditionAsync(Expression<Func<Account, bool>> predictate);
    Task<IEnumerable<Account>> QueryAccountByCreationTimeAndRoleAsync(AccountCreationDateAndRolesQuery queryData);
    Task<bool> ValidateAccountSessionAsync(Guid id, Guid sessionId);
}
