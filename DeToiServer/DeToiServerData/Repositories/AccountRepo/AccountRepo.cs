using DeToiServerCore.Models.Accounts;

namespace DeToiServerData.Repositories;

public class AccountRepo(DataContext context) : RepositoryBase<Account>(context), IAccountRepo
{

}
