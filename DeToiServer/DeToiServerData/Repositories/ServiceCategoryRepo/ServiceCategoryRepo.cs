using DeToiServerCore.Models;
using DeToiServerData.Specifications.ServiceCategorySpecification;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories.ServiceCategoryRepo
{
    public class ServiceCategoryRepo(DataContext context) : RepositoryBase<ServiceCategory>(context), IServiceCategoryRepo
    {
        private readonly DataContext _context = context;

        public async Task<IEnumerable<ServiceCategory>> GetServiceCategoryWithChild()
            => await ApplySpecification(new ServiceCategoryWithChildSpecification()).ToListAsync();

        public async Task<ServiceCategory> GetServiceCategoryByIdWithChild(Guid id)
            => await ApplySpecification(new ServiceCategoryByIdWithChildSpecification(sc => sc.Id == id)).FirstOrDefaultAsync();

        public async Task<IEnumerable<ServiceCategory>> GetServiceCategoriesWithLimit(int limit, bool isActivated)
        {
            var query = _context.ServiceCategories.AsQueryable();

            if (isActivated)
            {
                query = query.Where(sc => sc.IsActivated);
            }

            return await query.Take(limit).ToListAsync();
        }
    }
}
