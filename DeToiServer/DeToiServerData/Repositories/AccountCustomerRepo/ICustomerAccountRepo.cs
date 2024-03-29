using DeToiServerCore.Models.Accounts;

namespace DeToiServerData.Repositories.AccountCustomerRepo
{
    public interface ICustomerAccountRepo : IRepository<CustomerAccount>
    {
        Task<CustomerAccount> GetByIdWithAccount(Guid id);
    }
}
