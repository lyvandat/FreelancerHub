using AutoMapper;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.AddressService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.CustomAttribute;
using DeToiServerCore.Models.Accounts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [Route("api/v1/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAccountService _accService;
        private readonly IFreelanceAccountService _freelanceAccService;
        private readonly ICustomerAccountService _customerService;
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _uow;

        public AddressController(
            IAccountService accService,
            IFreelanceAccountService freelanceAccountService,
            ICustomerAccountService customerAccountService,
            IAddressService addressService,
            IMapper mapper,
            UnitOfWork uow)
        {
            _accService = accService;
            _freelanceAccService = freelanceAccountService;
            _customerService = customerAccountService;
            _addressService = addressService;
            _mapper = mapper;
            _uow = uow;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetAll()
        {
            return Ok(await _addressService.GetAll());
        }

        [HttpGet(""), AuthorizeRoles(GlobalConstant.Customer, GlobalConstant.Freelancer)]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetByAccountId()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var account = await _accService.GetById(accountId);

            if (account is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản."
                });
            }

            var result = await _addressService.GetAllByAccId(accountId);

            return Ok(result);
        }

        [HttpPost(""), AuthorizeRoles(GlobalConstant.Customer, GlobalConstant.Freelancer)]
        public async Task<ActionResult<AddressDto>> PostAddressByAccountId(PostAddressDto postAddress)
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            string role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? "Default";
            var account = await _accService.GetById(accountId);

            if (account is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản."
                });
            }
            var addressToAdd = _mapper.Map<Address>(postAddress);
            switch (role)
            {
                case GlobalConstant.Customer:
                    var customer = await _customerService.GetByAccId(accountId);
                    addressToAdd.CustomerAccountId = customer.Id;
                    await _addressService.CreateAddress(addressToAdd);
                    break;

                case GlobalConstant.Freelancer:
                    var freelancer = await _freelanceAccService.GetByAccId(accountId);
                    addressToAdd.FreelanceAccountId = freelancer.Id;
                    await _addressService.CreateAddress(addressToAdd);
                    break;

                default:
                    break;
            }

            if (!await _uow.SaveChangesAsync())
            {
                return StatusCode(500, new
                {
                    Message = "Có lỗi xảy ra khi thêm địa chỉ"
                });
            }

            return Ok(new
            {
                Message = "Thêm địa chỉ thành công"
            });
        }

        [HttpPut("detail"), AuthorizeRoles(GlobalConstant.Customer, GlobalConstant.Freelancer)]
        public async Task<ActionResult<AddressDto>> PutAddressById(PutAddressDto putAddress)
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var account = await _accService.GetById(accountId);

            if (account is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản."
                });
            }

            var address = await _addressService.GetDetailById(putAddress.Id);
            if (address == null)
            {
                return BadRequest(new
                {
                    Message = $"Không tìm thấy địa chỉ có Id = {putAddress.Id}"
                });
            }

            var check1 = address.FreelanceAccount?.AccountId.Equals(accountId);
            var check2 = address.CustomerAccount?.AccountId.Equals(accountId);

            if (!(check1 ?? true)
                || !(check2 ?? true))
            {
                return BadRequest(new
                {
                    Message = $"Địa chỉ có Id = \'{putAddress.Id}\' không thuộc thẩm quyền."
                });
            }

            _mapper.Map(source: putAddress, destination: address);

            if (!await _uow.SaveChangesAsync())
            {
                return StatusCode(500, new
                {
                    Message = "Có lỗi xảy ra khi cập nhật địa chỉ"
                });
            }

            return Ok(new
            {
                Message = "Cập nhật địa chỉ thành công"
            });
        }
    }
}
