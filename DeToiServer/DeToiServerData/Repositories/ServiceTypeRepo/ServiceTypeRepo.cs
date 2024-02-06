using DeToiServerCore.Models.Services;
using DeToiServerData.Specifications.ServiceTypeSpecification;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories.ServiceTypeRepo
{
    public class ServiceTypeRepo : RepositoryBase<ServiceType>, IServiceTypeRepo
    {
        private readonly DataContext _context;

        public ServiceTypeRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceType>> GetAllWithCategory()
            => await ApplySpecification(new ServiceTypeWithCategorySpecification()).ToListAsync();

        public async Task<ServiceType> GetByIdWithCategory(int id)
            => await ApplySpecification(new ServiceTypeByIdWithCategorySpecification(st => st.Id == id)).FirstOrDefaultAsync();
    }
}
