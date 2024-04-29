using DeToiServerCore.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerData.Repositories.AccountFreelanceRepo;

public class FreelanceAccountRepo : RepositoryBase<FreelanceAccount>, IFreelanceAccountRepo
{
    private readonly DataContext _context;

    public FreelanceAccountRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<FreelanceAccount> GetByAccId(Guid id)
    {
        var query = _context.Freelancers.AsSplitQuery(); // perfomance
        return await query.Where(fl => fl.AccountId.Equals(id) || fl.Id.Equals(id))
            .Include(fl => fl.Account)
            .Include(fl => fl.Address)
            .Include(fl => fl.FreelanceSkills)
                .ThenInclude(fls => fls.Skill)
            .Include(fl => fl.FreelancerFeasibleServices)
                .ThenInclude(ffs => ffs.ServiceType)
            .Include(fl => fl.ServiceProven)
                .ThenInclude(sp => sp.ServiceType)
            .Include(fl => fl.ServiceProven)
                .ThenInclude(sp => sp.Order)
            .FirstOrDefaultAsync();
    }

    public async Task<FreelanceAccount> GetByAccIdWithWallet(Guid id)
    {
        var query = _context.Freelancers.AsNoTracking(); // perfomance
        return await query.Where(fl => fl.AccountId.Equals(id) || fl.Id.Equals(id))
            .Include(fl => fl.Account)
            .Include(fl => fl.PaymentHistory)
            .FirstOrDefaultAsync();
    }

    public async Task<FreelanceAccount> GetByAccPhone(string phone)
    {
        return await _context.Freelancers
            .AsNoTracking()
            .Include(fl => fl.Account)
            .Where(fl => fl.Account.Phone.Contains(phone))
            .FirstOrDefaultAsync();
    }

    public new async Task<FreelanceAccount> GetByConditionsAsync(Expression<Func<FreelanceAccount, bool>> predicate)
    {
        return await _context.Freelancers
            .Include(c => c.Account)
            .Include(c => c.Address)
            .FirstOrDefaultAsync(predicate);
    }

    public async Task<FreelanceAccount> GetDetailByIdWithStatistic(Guid id)
    {
        var query = _context.Freelancers.AsSplitQuery().AsNoTracking(); // perfomance
        return await query.Where(fl => fl.AccountId.Equals(id) || fl.Id.Equals(id))
            .Include(fl => fl.Account)
            .Include(fl => fl.Address)
            .Include(fl => fl.FreelanceSkills)
                .ThenInclude(fls => fls.Skill)
            .Include(fl => fl.ServiceProven)
                .ThenInclude(sp => sp.ServiceType)
            .Include(fl => fl.Orders)
                .ThenInclude(o => o.Customer)
                        .ThenInclude(cus => cus.Account)
            .Include(fl => fl.FavoriteBy)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<FreelanceAccount>> GetAllDetail()
    {
        var query = _context.Freelancers.AsSplitQuery().AsNoTracking(); // perfomance
        return await query
            .Include(fl => fl.Account)
            .Include(fl => fl.Address)
            .Include(fl => fl.FreelanceSkills)
                .ThenInclude(fls => fls.Skill)
            .Include(fl => fl.ServiceProven)
                .ThenInclude(sp => sp.ServiceType)
            .Include(fl => fl.Orders)
                .ThenInclude(o => o.Customer)
                    .ThenInclude(cus => cus.Account)
            .Include(fl => fl.FavoriteBy)
            .ToListAsync();
    }

    public async Task<IEnumerable<FreelanceServiceType>> ChooseFreelancerServiceTypesAsync(Guid freelancerId, IEnumerable<Guid> serviceTypes)
    {
        var addedServices = await _context.FreelanceServiceTypes.AsNoTracking().AsSplitQuery()
            .Where(fst => fst.FreelancerId.Equals(freelancerId)).Select(fst => fst.ServiceTypeId)
            .ToListAsync();

        var toAddServices = serviceTypes.Where(svId => !addedServices.Contains(svId)).Select(svId => new FreelanceServiceType
        {
            FreelancerId = freelancerId,
            Freelancer = null!,
            ServiceTypeId = svId,
            ServiceType = null!,
        }).ToList();

        await _context.FreelanceServiceTypes.AddRangeAsync(toAddServices);

        return toAddServices;
    }

    public async Task<IEnumerable<FreelanceServiceType>> RemoveFreelancerServiceTypesAsync(Guid freelancerId, IEnumerable<Guid> serviceTypes)
    {
        var removedServices = await _context.FreelanceServiceTypes.AsNoTracking().AsSplitQuery()
            .Where(fst => fst.FreelancerId.Equals(freelancerId)).Select(fst => fst.ServiceTypeId)
            .ToListAsync();

        var toRemoveServices = serviceTypes.Where(svId => removedServices.Contains(svId)).Select(svId => new FreelanceServiceType
        {
            FreelancerId = freelancerId,
            Freelancer = null!,
            ServiceTypeId = svId,
            ServiceType = null!,
        }).ToList();

        if (toRemoveServices.Count != 0)
        {
            await Task.Run(() =>
            {
                _context.FreelanceServiceTypes.RemoveRange(toRemoveServices);
            });
        }

        return toRemoveServices;
    }

    public async Task<IEnumerable<FreelanceAccount>> GetManyByConditionsAsync(Expression<Func<FreelanceAccount, bool>> predicate)
    {
        return await _context.Freelancers
            .Include(c => c.Account)
            .Include(c => c.Address)
            .Where(predicate)
            .ToListAsync();
    }
}
