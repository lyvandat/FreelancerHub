using DeToiServerCore.Models.Accounts;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories.AddressRepo
{
    public class AddressRepo(DataContext context) : RepositoryBase<Address>(context), IAddressRepo
    {
        private DataContext _context = context;

        #nullable enable
        public async Task<Address?> GetByIdAsync(Guid? id)
        {
            if (id == null)
                return null;

            return await _context.Addresses.FindAsync(id);
        }

        #nullable disable
        public async Task<Address> GetByIdWithDetailAsync(Guid id)
        {
            var query = _context.Addresses.AsSplitQuery()
                .Include(ad => ad.FreelanceAccount)
                .Include(ad => ad.CustomerAccount);

            return await query.FirstOrDefaultAsync(ad => ad.Id.Equals(id));
        }

        public async Task<IEnumerable<Address>> GetAllByAccIdAsync(Guid id)
        {
            var query = _context.Addresses.AsSplitQuery().AsNoTracking()
                .Include(ad => ad.FreelanceAccount)
                .Include(ad => ad.CustomerAccount)
                .Where(ad => ad.FreelanceAccount.AccountId.Equals(id)
                    || ad.CustomerAccount.AccountId.Equals(id));

            return await query.ToListAsync();
        }
    }
}
