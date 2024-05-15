using DeToiServer.Dtos.AccountDtos;
using DeToiServerCore.Models.Accounts;
using System.Linq.Expressions;

namespace DeToiServer.Services.AccountService
{
    public interface IAccountService
    {
        Task<Account> GetById(Guid id);
        Task<IEnumerable<Account>> GetAll();
        Task<Account> GetByCondition(Expression<Func<Account, bool>> predicate);
        Task<Account> Add(Account acc);
        Task<Account> Update(Account acc);
        Task<GetAccountDto> GetAccountDetailsById(Guid accountId);
        Task BanAccount(Guid accountId);
        Task<IEnumerable<GetAccountDto>> GetAllAccountInfo(FilterAccountQuery searchAccount);
        Task<Account> GetByPhone(string countryCode, string phone);
    }
}
