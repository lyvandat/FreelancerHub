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

        public async Task<ServiceType> GetServiceTypeDetailWithRequirementsAsync(Guid id)
        {
            var query = _context.ServiceTypes.AsNoTracking().AsSplitQuery(); // perfomance
            var result = await query
                .Where(st => st.Id.Equals(id))
                .Include(st => st.Requirements)
                    .ThenInclude(req => req.InputMethod)
                        .ThenInclude(im => im.Validation)
                .Include(st => st.Requirements)
                    .ThenInclude(req => req.InputMethod)
                        .ThenInclude(im => im.Method)
                            .ThenInclude(med => med.Options)
                                .ThenInclude(opt => opt.Info)
                                    .ThenInclude(info => info.Validation)
                .Include(st => st.AdditionalRequirements)
                .FirstOrDefaultAsync();

            result.Requirements = result.Requirements.OrderBy(req => req.Priority).ToList();
            result.AdditionalRequirements = result.AdditionalRequirements.OrderBy(areq => areq.Priority).ToList();

            return result;
        }

        public async Task<ServiceType> GetServiceTypeDetailWithRequirementsTrackingAsync(Guid id)
        {
            var query = _context.ServiceTypes.AsSplitQuery(); // perfomance
            var result = await query
                .Where(st => st.Id.Equals(id))
                .Include(st => st.Requirements)
                    .ThenInclude(req => req.InputMethod)
                        .ThenInclude(im => im.Validation)
                .Include(st => st.Requirements)
                    .ThenInclude(req => req.InputMethod)
                        .ThenInclude(im => im.Method)
                            .ThenInclude(med => med.Options)
                                .ThenInclude(opt => opt.Info)
                                    .ThenInclude(info => info.Validation)
                .Include(st => st.AdditionalRequirements)
                .FirstOrDefaultAsync();

            result.Requirements = result.Requirements.OrderBy(req => req.Priority).ToList();
            result.AdditionalRequirements = result.AdditionalRequirements.OrderBy(areq => areq.Priority).ToList();

            return result;
        }

        public async Task<string> GetServiceCategoryNameByTypeId(Guid id)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(id);
            if (serviceType == null) return string.Empty;

            var serviceCategory = await _context.ServiceCategories.FindAsync(serviceType.ServiceCategoryId);
            
            if (serviceCategory == null) return string.Empty;
            return serviceCategory.ServiceClassName;
        }

        public async Task<IEnumerable<ServiceType>> GetAllServiceTypeWithCategoryAsync()
        {
            return await _context.ServiceTypes.AsSplitQuery().AsNoTracking()
                .Include(st => st.ServiceCategory)
                .ToListAsync();
        }
    }
}
