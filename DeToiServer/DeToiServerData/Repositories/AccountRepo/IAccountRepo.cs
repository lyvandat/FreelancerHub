using DeToiServer.Dtos.AccountDtos;
using DeToiServerCore.Models.Accounts;

namespace DeToiServerData.Repositories;

public interface IAccountRepo : IRepository<Account>
{
    Task<IEnumerable<Account>> GetAllAccountInfoAsync(FilterAccountDto searchAccount);
}
