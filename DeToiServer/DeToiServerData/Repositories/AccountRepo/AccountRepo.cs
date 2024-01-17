using DeToiServerCore.Models;

namespace DeToiServerData.Repositories;

public class AccountRepo(DataContext context) : RepositoryBase<Account>(context), IAccountRepo
{

}
