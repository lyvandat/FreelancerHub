using AutoMapper;
using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServer.Services.ServiceTypeService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models.Services;
using DeToiServerCore.QueryModels.ServiceTypeQueryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/service-type")]
    public class ServiceTypeController : Controller
    {
        private readonly IServiceTypeService _service;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _uow;

        public ServiceTypeController(
            IServiceTypeService service,
            IMapper mapper,
            UnitOfWork uow)
        {
            _service = service;
            _mapper = mapper;
            _uow = uow;
        }

        [HttpGet] // , Authorize
        public async Task<ActionResult<IEnumerable<GetServiceTypeDto>>> GetServices()
        {
            string role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? string.Empty;

            return Ok(await _service.GetAll(true)); // !role.Equals(GlobalConstant.Admin)
        }

        [HttpGet("detail")]
        public async Task<ActionResult<GetServiceTypeDetailDto>> GetServiceById(Guid id)
        {
            var serviceType = await _service.GetServiceTypeDetailWithRequirements(id);

            if (serviceType is null)
            {
                return BadRequest(new
                {
                    Message = "Không thể tìm thấy dịch vụ!"
                });
            }

            return Ok(serviceType);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceType>> CreateService(PostServiceTypeWithRequirementDto serviceTypeDto)
        {
            if (!GlobalConstant.AddressOption.All.Contains(serviceTypeDto.AddressRequireOption))
            {
                return BadRequest(new
                {
                    Message = "Loại địa chỉ cho dịch vụ không đúng định dạng"
                });
            }

            // TODO: Check CategoryId
            //if (!GlobalConstant.AddressOption.All.Contains(serviceTypeDto.AddressRequireOption))
            //{
            //    return BadRequest(new
            //    {
            //        Message = "Loại địa chỉ cho dịch vụ không đúng định dạng"
            //    });
            //}

            var serviceType = await _service.AddWithRequirement(serviceTypeDto);
            await _uow.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiceById), new { id = serviceType.Id }, new { 
                Message = "Thêm Dịch vụ mới thành công",
                serviceType
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(PutServiceTypeWithRequirementDto putServiceTypeDto)
        {
            var serviceToUpdate = await _service.GetServiceTypeDetailWithRequirementsTracking(putServiceTypeDto.Id);

            if (serviceToUpdate == null)
            {
                return BadRequest(new
                {
                    Message = $"Không tìm thấy Service với id:{putServiceTypeDto.Id}"
                });
            }

            // TODO: Check CategoryId
            //if (!(serviceTypeDto.AddressRequireOption))
            //{
            //    return BadRequest(new
            //    {
            //        Message = "Loại địa chỉ cho dịch vụ không đúng định dạng"
            //    });
            //}

            _mapper.Map(source: putServiceTypeDto, destination: serviceToUpdate);

            await _uow.SaveChangesAsync();
            return Ok(new
            { 
                Message = "Cập nhật dịch vụ thành công"
            });
        }

        [HttpDelete] // , AuthorizeRoles(GlobalConstant.Admin)
        public async Task<IActionResult> DeleteService(Guid id)
        {
            string role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? string.Empty;
            // var serviceToDelete = await _service.GetServiceTypeDetailWithRequirementsTracking(id);
            // serviceToDelete.IsActivated = false;

            await _service.Delete(id);
            await _uow.SaveChangesAsync();
            
            return Ok(new
            {
                Message = "Xóa dịch vụ thành công"
            });
        }

        [HttpGet("search")] // , Authorize
        public async Task<ActionResult<SearchServiceTypeAndCategoryDto>> SearchService(
            [FromQuery] FilterServiceTypeQuery query
        )
        {
            string role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? string.Empty;
            var result = await _service.GetAllServiceInfo(query, !role.Equals(GlobalConstant.Admin));

            return Ok(result);
        }
    }
}
