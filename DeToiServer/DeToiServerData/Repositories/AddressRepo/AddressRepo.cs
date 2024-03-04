using DeToiServerCore.Models.Accounts;

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
    }
}
