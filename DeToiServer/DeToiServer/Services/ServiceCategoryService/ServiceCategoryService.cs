using AutoMapper;
using DeToiServer.Dtos.ServiceCategoryDtos;

namespace DeToiServer.Services.ServiceCategoryService
{
    public class ServiceCategoryService : IServiceCategoryService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _uow;

        public ServiceCategoryService(UnitOfWork uow, IMapper mapper) 
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IEnumerable<GetServiceCategoryWithChildDto>> GetServiceCategories()
        {
            var rawServiceCategories = await _uow.ServiceCategoryRepo.GetServiceCategoryWithChild();

            return rawServiceCategories.Select(sc => _mapper.Map<GetServiceCategoryWithChildDto>(sc)).ToList();
        }

        public async Task<GetServiceCategoryWithChildDto> GetServiceCategoryById(Guid id)
        {
            var serviceCategory = await _uow.ServiceCategoryRepo.GetServiceCategoryByIdWithChild(id);

            return _mapper.Map<GetServiceCategoryWithChildDto>(serviceCategory);
        }

        public async Task<ServiceCategory> CreateServiceCategory(PostServiceCategoryDto postServiceCategoryDto)
        {
            var serviceCategory = _mapper.Map<ServiceCategory>(postServiceCategoryDto);
            return await _uow.ServiceCategoryRepo.CreateAsync(serviceCategory);
        }

        public async Task UpdateServiceCategory(PutServiceCategoryDto putServiceCategoryDto)
        {
            var serviceCategory = _mapper.Map<ServiceCategory>(putServiceCategoryDto);
            await _uow.ServiceCategoryRepo.UpdateAsync(serviceCategory);
        }

        public async Task DeleteServiceCategory(Guid id)
        {
            await _uow.ServiceCategoryRepo.DeleteAsync(id);
        }
    }
}
