using DeToiServer.Dtos.AccountDtos;
using DeToiServerCore.Models.Accounts;

namespace DeToiServerData.Repositories;

public class AccountRepo : RepositoryBase<Account>, IAccountRepo
{
    private readonly DataContext _context;

    public AccountRepo(DataContext context)
    {
        _context = context;
    }

    Task<IEnumerable<Account>> GetAllAccountInfoAsync(FilterAccountDto searchAccount)
    {
        await _context.Accounts
            .Where(acc => acc.FullName == searchAccount.Name)
            .Where(acc => acc.Role == searchAccount.Role)
            .OrderBy(acc => acc.)
    }
}
