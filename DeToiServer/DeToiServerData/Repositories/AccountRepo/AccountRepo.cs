using DeToiServerCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories;

public class AccountRepo(DataContext context) : RepositoryBase<Account>(context), IAccountRepo
{

}
