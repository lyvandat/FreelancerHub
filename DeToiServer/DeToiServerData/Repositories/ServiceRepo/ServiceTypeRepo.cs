using DeToiServerCore.Models.Services;
using DeToiServerData.Repositories.ServiceTypeRepo;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories.ServiceRepo
{
    public class ServiceTypeRepo : RepositoryBase<ServiceType>, IServiceTypeRepo
    {
        private readonly DataContext _context;

        public ServiceTypeRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceType>> GetAllWithCategory()
        {
            return await _context.ServiceTypes.Include(st => st.ServiceCategory).ToListAsync();
        }

        public async Task<ServiceType> GetByIdWithCategory(int id)
        {
            return await _context.ServiceTypes.Where(sc => sc.Id == id).Include(st => st.ServiceCategory).FirstOrDefaultAsync();
        }
    }
}
