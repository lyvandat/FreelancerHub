using DeToiServerCore.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        return await query.Where(fl => fl.AccountId == id)
            .Include(fl => fl.Account)
            .Include(fl => fl.Address)
            .Include(fl => fl.Skills)
            .FirstOrDefaultAsync();
    }
}
