using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServerCore.Models.Services;
using DeToiServerCore.QueryModels.ServiceTypeQueryModels;

namespace DeToiServer.Services.ServiceTypeService
{
    public interface IServiceTypeService
    {
        public Task<IEnumerable<GetServiceTypeDto>> GetAll(bool isActivated = true);
        public Task<GetServiceTypeDto> GetById(Guid id);
        public Task<ServiceType> Add(PostServiceTypeDto service);
        public Task Update(PutServiceTypeDto service);
        public Task Delete(Guid id);
        public Task<SearchServiceTypeAndCategoryDto> GetAllServiceInfo(FilterServiceTypeQuery query, bool isActivated = true);
        public Task<GetServiceTypeDetailDto> GetServiceTypeDetailWithRequirements(Guid id);
        public Task<ServiceType> AddWithRequirement(PostServiceTypeWithRequirementDto postServiceDto);
        public Task<ServiceType> GetServiceTypeDetailWithRequirementsTracking(Guid id);
    }
}
