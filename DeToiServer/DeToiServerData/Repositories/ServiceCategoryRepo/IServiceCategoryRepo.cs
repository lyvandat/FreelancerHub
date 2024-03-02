using DeToiServerCore.Models;

namespace DeToiServerData.Repositories.ServiceCategoryRepo
{
    public interface IServiceCategoryRepo : IRepository<ServiceCategory>
    {
        Task<IEnumerable<ServiceCategory>> GetServiceCategoryWithChild();
        Task<ServiceCategory> GetServiceCategoryByIdWithChild(Guid id);
        Task<IEnumerable<ServiceCategory>> GetServiceCategoriesWithLimit(int limit);
    }
}
