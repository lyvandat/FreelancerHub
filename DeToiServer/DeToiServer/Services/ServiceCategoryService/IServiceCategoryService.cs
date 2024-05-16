using DeToiServer.Dtos.ServiceCategoryDtos;

namespace DeToiServer.Services.ServiceCategoryService
{
    public interface IServiceCategoryService
    {
        Task<IEnumerable<GetServiceCategoryDto>> GetServiceCategories(bool isActivated = true);
        Task<GetServiceCategoryWithChildDto> GetServiceCategoryById(Guid id);
        Task<ServiceCategory> CreateServiceCategory(PostServiceCategoryDto postServiceCategoryDto);
        Task UpdateServiceCategory(PutServiceCategoryDto putServiceCategoryDto);
        Task DeleteServiceCategory(Guid id);
        Task<IEnumerable<GetServiceCategoryDto>> GetServiceCategoriesLimit(int limit, bool isActivated = true);
        Task<GetServiceCategoryDto> GetServiceCategoryByIdNoChild(Guid id);
    }
}
