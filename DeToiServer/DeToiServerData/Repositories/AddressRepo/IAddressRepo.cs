using DeToiServerCore.Models.Accounts;

namespace DeToiServerData.Repositories.AddressRepo
{
    public interface IAddressRepo : IRepository<Address>
    {
        #nullable enable
        Task<Address?> GetByIdAsync(Guid? id);
    }
}
