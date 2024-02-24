using DeToiServerCore.Models.Services;

namespace DeToiServerData.Repositories.CleaningServiceRepo
{
    public class CleaningServiceRepo : RepositoryBase<CleaningService>, ICleaningServiceRepo
    {
        private readonly DataContext _context;

        public CleaningServiceRepo(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
