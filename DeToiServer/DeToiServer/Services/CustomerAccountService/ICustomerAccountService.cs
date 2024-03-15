using DeToiServerCore.Models.Accounts;
using System.Linq.Expressions;

namespace DeToiServer.Services.CustomerAccountService
{
    public interface ICustomerAccountService
    {
        Task<CustomerAccount> GetById(Guid id);
        Task<CustomerAccount> GetByAccId(Guid accId);
        Task<IEnumerable<CustomerAccount>> GetAll();
        Task<CustomerAccount> GetByCondition(Expression<Func<CustomerAccount, bool>> predicate);
        Task<CustomerAccount> Add(CustomerAccount acc);
        Task<CustomerAccount> Update(CustomerAccount acc);
    }
}
