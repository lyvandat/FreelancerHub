using DeToiServer.Dtos.AddressDtos;
using DeToiServerCore.Models.Accounts;

namespace DeToiServer.Services.AddressService
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDto>> GetAll();
        Task<IEnumerable<AddressDto>> GetAllByAccId(Guid id);
        Task<Address> GetDetailById(Guid id);
        Task<Address> CreateAddress(Address toAdd);
    }
}
