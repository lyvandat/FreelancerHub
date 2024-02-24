using DeToiServerCore.Models.Services;
using DeToiServerCore.QueryModels.ServiceTypeQueryModels;
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

        public async Task<ServiceType> GetByIdWithCategory(Guid id)
            => await ApplySpecification(new ServiceTypeByIdWithCategorySpecification(st => st.Id == id)).FirstOrDefaultAsync();

        public async Task<IEnumerable<ServiceType>> GetAllServiceTypeInfoAsync(FilterServiceTypeQuery query)
        {
            var serviceQueryable = _context.ServiceTypes.AsQueryable();

            if (!string.IsNullOrEmpty(query.Name))
            {
                serviceQueryable = serviceQueryable.Where((serviceType) => serviceType.Name.Contains(query.Name));
            }

            return await serviceQueryable.ToListAsync();
        }
    }
}
