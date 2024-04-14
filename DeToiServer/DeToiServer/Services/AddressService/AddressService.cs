using AutoMapper;
using DeToiServer.Dtos.AddressDtos;
using DeToiServerCore.Models.Accounts;
using Newtonsoft.Json.Linq;

namespace DeToiServer.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddressService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AddressDto>> GetAll()
        {
            var raw = _unitOfWork.AddressRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<AddressDto>>(await raw);
        }

        public async Task<IEnumerable<AddressDto>> GetAllByAccId(Guid id)
        {
            var raw = _unitOfWork.AddressRepo.GetAllByAccIdAsync(id);
            return _mapper.Map<IEnumerable<AddressDto>>(await raw);
        }

        public async Task<Address> GetDetailById(Guid id)
        {
            return await _unitOfWork.AddressRepo.GetByIdWithDetailAsync(id);
        }

        public async Task<Address> CreateAddress(Address toAdd)
        {
            return await _unitOfWork.AddressRepo.CreateAsync(toAdd);
        }
    }
}
