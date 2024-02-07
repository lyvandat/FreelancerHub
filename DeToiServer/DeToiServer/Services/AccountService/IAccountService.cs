using DeToiServer.Dtos.AccountDtos;
using DeToiServerCore.Models.Accounts;
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
        Task<GetAccountDto> GetAccountDetailsById(int accountId);
        Task BanAccount(int accountId);
        Task<List<GetAccountDto>> GetAllAccountInfo(FilterAccountDto searchAccount);
    }
}
