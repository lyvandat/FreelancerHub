using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Infos;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories;

public class HomeInfoRepo(DataContext context) : RepositoryBase<HomeInfo>(context), IHomeInfoRepo
{
}
