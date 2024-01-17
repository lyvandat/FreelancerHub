namespace DeToiServer.Services.AccountService
{
    public interface IAccountService
    {
        Task<Account> GetAccountById(int id);
        Task<IEnumerable<Account>> GetAllAccount();
    }
}
