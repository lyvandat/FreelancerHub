using DeToiServerCore.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerData.Repositories.AccountCustomerRepo
{
    public class CustomerAccountRepo : RepositoryBase<CustomerAccount>, ICustomerAccountRepo
    {
        private readonly DataContext _context;

        public CustomerAccountRepo(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
