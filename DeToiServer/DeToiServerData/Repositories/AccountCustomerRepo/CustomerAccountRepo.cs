using DeToiServerCore.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public new async Task<CustomerAccount> GetByConditionsAsync(Expression<Func<CustomerAccount, bool>> predicate)
        {
            return await _context.Customers
                .Include(c => c.Account)
                .Include(c => c.Addresses)
                .FirstOrDefaultAsync(predicate);
        }
    }
}
