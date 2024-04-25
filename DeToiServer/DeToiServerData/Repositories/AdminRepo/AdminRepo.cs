using DeToiServerCore.QueryModels.ServiceTypeQueryModels;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories.AdminRepo
{
    public class AdminRepo(DataContext context) : IAdminRepo
    {
        private readonly DataContext _context = context;

        public async Task<IEnumerable<ServiceTypeDistributionModel>> GetServiceTypePercentage()
        {
            var query = _context.OrderServiceTypes.AsSplitQuery().AsNoTracking()
                .Include(ost => ost.ServiceType)
                .GroupBy(ost => new { ost.ServiceTypeId, ost.ServiceType.Name })
                .Select(group => new ServiceTypeDistributionModel() {
                    Id = group.Key.ServiceTypeId,
                    Name = group.Key.Name,
                    Percentage = (double)group.Count() / _context.OrderServiceTypes.Count() * 100
                });

            var res = await query.ToListAsync();

            return res;
        }
    }
}
