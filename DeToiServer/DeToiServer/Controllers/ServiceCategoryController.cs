using DeToiServer.Dtos.ServiceCategoryDtos;
using DeToiServer.Services.ServiceCategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetServiceCategoryDto>>> GetServiceCategories()
        {
            return Ok(await _serviceCategory.GetServiceCategories());
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

        [HttpDelete]
        public async Task<IActionResult> DeleteServiceCategory(Guid id)
        {
            await _serviceCategory.DeleteServiceCategory(id);
            await _uow.SaveChangesAsync();
            return NoContent();
        }
    }
}
