using DeToiServerData;
using System.Linq.Expressions;

namespace DeToiServer.Services.AccountService
{
    public interface IAccountService
    {
        Task<Account> GetById(int id);
        Task<IEnumerable<Account>> GetAll();
        Task<Account> GetByCondition(Expression<Func<Account, bool>> predicate);
        Task<Account> Add(Account acc);
        Task<Account> Update(Account acc);
    }
}
