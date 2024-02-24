using DeToiServer.Dtos.ServiceCategoryDtos;

namespace DeToiServer.Services.ServiceCategoryService
{
    public interface IServiceCategoryService
    {
        Task<IEnumerable<GetServiceCategoryWithChildDto>> GetServiceCategories();
        Task<GetServiceCategoryWithChildDto> GetServiceCategoryById(Guid id);
        Task<ServiceCategory> CreateServiceCategory(PostServiceCategoryDto postServiceCategoryDto);
        Task UpdateServiceCategory(PutServiceCategoryDto putServiceCategoryDto);
        Task DeleteServiceCategory(Guid id);
    }
}
