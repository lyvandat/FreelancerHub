using DeToiServer.Dtos.ServiceCategoryDtos;
using DeToiServer.Services.ServiceCategoryService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/service-category")]
    public class ServiceCategoryController : Controller
    {
        private readonly IServiceCategoryService _serviceCategory;
        private readonly UnitOfWork _uow;

        public ServiceCategoryController(UnitOfWork uow, IServiceCategoryService serviceCategory)
        {
            _serviceCategory = serviceCategory;
            _uow = uow;
        }

        [HttpGet] // , Authorize
        public async Task<ActionResult<IEnumerable<GetServiceCategoryDto>>> GetAllServiceCategories()
        {
            string role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? string.Empty;
            return Ok(await _serviceCategory.GetServiceCategories(false)); // !role.Equals(GlobalConstant.Admin)
        }

        [HttpGet("preview")] // , Authorize
        public async Task<ActionResult<IEnumerable<GetServiceCategoryDto>>> GetServiceCategories()
        {
            string role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? string.Empty;
            return Ok(await _serviceCategory.GetServiceCategoriesLimit(5, false)); // !role.Equals(GlobalConstant.Admin)
        }

        [HttpGet("detail")]
        public async Task<ActionResult<GetServiceCategoryWithChildDto>> GetServiceCategoryDetail(Guid id)
        {
            var serviceCategory = await _serviceCategory.GetServiceCategoryById(id);

            if (serviceCategory is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy loại dịch vụ!"
                });
            }

            return Ok(serviceCategory);
        }

        [HttpPost]
        public async Task<ActionResult<GetServiceCategoryWithChildDto>> PostServiceCategory(PostServiceCategoryDto serviceCategoryDto)
        {
            var serviceCategory = await _serviceCategory.CreateServiceCategory(serviceCategoryDto);
            await _uow.SaveChangesAsync();
            return CreatedAtAction(nameof(GetServiceCategoryDetail), new { id = serviceCategory.Id }, serviceCategory);
        }

        [HttpPut]
        public async Task<IActionResult> PutServiceCategory(PutServiceCategoryDto serviceCategoryDto)
        {
            await _serviceCategory.UpdateServiceCategory(serviceCategoryDto);
            await _uow.SaveChangesAsync();
            return Ok(new { Message = "Cập nhật loại dịch vụ thành công" });
        }

        [HttpDelete] // , AuthorizeRoles(GlobalConstant.Admin)
        public async Task<IActionResult> DeleteServiceCategory(Guid id)
        {
            string role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? string.Empty;
            // var categoryToDelete = await _uow.ServiceCategoryRepo.GetByIdAsync(id);
            // categoryToDelete.IsActivated = !categoryToDelete.IsActivated;
            
            await _serviceCategory.DeleteServiceCategory(id);
            await _uow.SaveChangesAsync();

            return Ok(new
            {
                Message = "Xóa danh mục thành công"
            });
        }
    }
}
