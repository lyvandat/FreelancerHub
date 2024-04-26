using DeToiServer.Dtos.AccountDtos;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.QueryModels.AccountQueryModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DeToiServerData.Repositories;

public class AccountRepo : RepositoryBase<Account>, IAccountRepo
{
    private readonly DataContext _context;

    public AccountRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Account>> GetAllAccountInfoAsync(FilterAccountQuery searchAccount)
    {
        var accountQueryable = _context.Accounts.AsQueryable();

        if (!string.IsNullOrEmpty(searchAccount.Name))
        {
            accountQueryable = accountQueryable.Where(acc => acc.FullName.Contains(searchAccount.Name));
        }

        if (!string.IsNullOrEmpty(searchAccount.Role))
        {
            accountQueryable = accountQueryable.Where(acc => acc.Role == searchAccount.Role);
        }

        var sortExpression = GetSortExpression(searchAccount);

        if (searchAccount.SortType == "desc")
        {
            accountQueryable = accountQueryable.OrderByDescending(sortExpression);
        }
        else
        {
            accountQueryable = accountQueryable.OrderBy(sortExpression);
        }

        return await accountQueryable.ToListAsync();
    }

    private Expression<Func<Account, object>> GetSortExpression(FilterAccountQuery searchAccount)
        => searchAccount.SortingCol?.ToLower() switch
        {
            "name" => acc => acc.FullName,
            "email" => acc => acc.Email,
            _ => acc => acc.Id,
        };

    public async Task<IEnumerable<Account>> GetAllAccountByConditionAsync(Expression<Func<Account, bool>> predictate)
    {
        var query = _context.Accounts.AsSplitQuery().AsNoTracking()
            .Where(predictate);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Account>> QueryAccountByCreationTimeAndRoleAsync(AccountCreationDateAndRolesQuery queryData)
    {
        var checkMonth = queryData.Month != null;
        var checkYear = queryData.Year != null;
        var roleCount = queryData.Roles.Count != 0;

        var query = _context.Accounts.AsSplitQuery().AsNoTracking()
            .Where(acc => !checkMonth || acc.CreatedAt.Month != queryData.Month
                || !checkYear || acc.CreatedAt.Year != queryData.Year
                || !roleCount || queryData.Roles.Contains(acc.Role));

        return await query.ToListAsync();
    }
}
