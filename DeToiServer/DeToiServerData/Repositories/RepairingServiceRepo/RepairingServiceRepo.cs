using DeToiServerCore.Models.Services;
using DeToiServerData.Repositories.RepairingServiceRepo;

namespace DeToiServerData.Repositories.ShoppingServiceRepo
{
    public class RepairingServiceRepo : RepositoryBase<RepairingService>, IRepairingServiceRepo
    {
        private readonly DataContext _context;

        public RepairingServiceRepo(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
