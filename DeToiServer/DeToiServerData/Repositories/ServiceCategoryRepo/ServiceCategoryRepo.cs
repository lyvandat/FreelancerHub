using DeToiServerCore.Models;
using DeToiServerData.Specifications.ServiceCategorySpecification;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories.ServiceCategoryRepo
{
    public class ServiceCategoryRepo(DataContext context) : RepositoryBase<ServiceCategory>(context), IServiceCategoryRepo
    {
        public async Task<IEnumerable<ServiceCategory>> GetServiceCategoryWithChild()
            => await ApplySpecification(new ServiceCategoryWithChildSpecification()).ToListAsync();

        public async Task<ServiceCategory> GetServiceCategoryByIdWithChild(int id)
            => await ApplySpecification(new ServiceCategoryByIdWithChildSpecification(sc => sc.Id == id)).FirstOrDefaultAsync();
    }
}
