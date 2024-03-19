using DeToiServer.Models;

namespace DeToiServerData.Repositories.UserRepo
{
    public class UserRepo : RepositoryBase<User>, IUserRepo
    {
        public UserRepo(DataContext context) : base(context)
        {
        }
    }
}
