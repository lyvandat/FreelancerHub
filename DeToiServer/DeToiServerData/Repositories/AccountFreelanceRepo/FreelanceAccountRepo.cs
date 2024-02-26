using DeToiServerCore.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerData.Repositories.AccountFreelanceRepo
{
    public class FreelanceAccountRepo : RepositoryBase<FreelanceAccount>, IFreelanceAccountRepo
    {
        private readonly DataContext _context;

        public FreelanceAccountRepo(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
