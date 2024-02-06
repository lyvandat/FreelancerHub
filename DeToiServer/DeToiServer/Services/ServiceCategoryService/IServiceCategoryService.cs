using DeToiServer.Dtos.ServiceCategoryDtos;

namespace DeToiServer.Services.ServiceCategoryService
{
    public interface IServiceCategoryService
    {
        Task<IEnumerable<GetServiceCategoryWithChildDto>> GetServiceCategories();
        Task<GetServiceCategoryWithChildDto> GetServiceCategoryById(int id);
        Task<ServiceCategory> CreateServiceCategory(PostServiceCategoryDto postServiceCategoryDto);
        Task UpdateServiceCategory(PutServiceCategoryDto putServiceCategoryDto);
        Task DeleteServiceCategory(int id);
    }
}
