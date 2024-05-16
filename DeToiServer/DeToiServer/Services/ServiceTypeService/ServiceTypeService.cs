using AutoMapper;
using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.ServiceCategoryDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServer.Dtos.UIElementDtos;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models.Services;
using DeToiServerCore.Models.SevicesUIElement;
using DeToiServerCore.QueryModels.ServiceTypeQueryModels;
using DeToiServerData;
using Newtonsoft.Json;

namespace DeToiServer.Services.ServiceTypeService
{
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public ServiceTypeService(UnitOfWork uow, IMapper mapper) 
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetServiceTypeDto>> GetAll(bool isActivated = true)
        {
            var serviceTypeRaw = await _uow.ServiceTypeRepo.GetAllWithCategory();

            if (isActivated)
            {
                serviceTypeRaw = serviceTypeRaw.Where(st => st.IsActivated);
            }

            return serviceTypeRaw
                .Select(st => _mapper.Map<GetServiceTypeDto>(st))
                .OrderBy(st => st.Name);
        }

        public async Task<GetServiceTypeDto> GetById(Guid id)
            => _mapper.Map<GetServiceTypeDto>(await _uow.ServiceTypeRepo.GetByIdWithCategory(id));

        public async Task<ServiceType> Add(PostServiceTypeDto postServiceDto)
        {
            var service = _mapper.Map<ServiceType>(postServiceDto);
            await _uow.ServiceTypeRepo.CreateAsync(service);
            return service;
        }

        public async Task Update(PutServiceTypeDto putServiceTypeDto)
        {
            var serviceType = _mapper.Map<ServiceType>(putServiceTypeDto);
            await _uow.ServiceTypeRepo.UpdateAsync(serviceType);
        }

        public async Task Delete(Guid id)
        {
            await _uow.ServiceTypeRepo.DeleteAsync(id);
        }

        public async Task<SearchServiceTypeAndCategoryDto> GetAllServiceInfo(FilterServiceTypeQuery query, bool isActivated = true)
        {
            var rawResult = await _uow.ServiceTypeRepo.GetAllServiceTypeWithCategoryAsync();
            var rawCategories = await _uow.ServiceCategoryRepo.GetAllAsync();

            var resultQuery = rawResult.AsQueryable();

            List<ServiceType> services = [];
            List<ServiceCategory> categories = [];
            if (!string.IsNullOrEmpty(query.Name))
            {
                foreach (var st in rawResult)
                {
                    List<string> keyList = JsonConvert.DeserializeObject<List<string>>(st.Keys) ?? [];

                    if (keyList.Any(item => item.CompareKey(query.Name))
                        || st.Name.Contains(query.Name))
                    {
                        services.Add(st);
                    }
                }

                foreach (var cate in rawCategories)
                {
                    List<string> categoryKeyList = JsonConvert.DeserializeObject<List<string>>(cate.Keys) ?? [];

                    if (categoryKeyList.Any(item => item.CompareKey(query.Name))
                        || cate.Name.Contains(query.Name))
                    {
                        categories.Add(cate);
                    }
                }

                //resultQuery.Where(st => st.Name.Contains(query.Name)
                //    || (JsonConvert.DeserializeObject<List<string>>(st.Keys) ?? new List<string>() {})
                //        .Any(item => item.CompareKey(query.Name)));
            }

            if (isActivated)
            {
                services = services.Where(s => s.IsActivated).ToList();
                categories = categories.Where(c => c.IsActivated).ToList();
            }

            return new SearchServiceTypeAndCategoryDto()
            {
                Services = services.Select(_mapper.Map<GetServiceTypeWithCategoryDto>),
                Categories = categories.Select(_mapper.Map<GetServiceCategoryDto>),
            }; 
        }

        public async Task<GetServiceTypeDetailDto> GetServiceTypeDetailWithRequirements(Guid id)
        {
            var rawDetail = await _uow.ServiceTypeRepo.GetServiceTypeDetailWithRequirementsAsync(id);

            return _mapper.Map<GetServiceTypeDetailDto>(rawDetail);
        }

        public async Task<ServiceType> AddWithRequirement(PostServiceTypeWithRequirementDto postServiceDto)
        {
            var service = _mapper.Map<ServiceType>(postServiceDto);

            service.ServiceStatusList = new List<ServiceTypeStatus>() { };
            var statusIdList = StatusConst.AddressOpt.None;
            if (service.AddressRequireOption.Equals(GlobalConstant.AddressOption.Destination))
            {
                statusIdList = StatusConst.AddressOpt.Destination;
            }
            else if (service.AddressRequireOption.Equals(GlobalConstant.AddressOption.Shipping))
            {
                statusIdList = StatusConst.AddressOpt.Shipping;
            }

            foreach (var sId in statusIdList)
            {
                service.ServiceStatusList.Add(new()
                {
                    ServiceStatus = null!,
                    ServiceType = null!,
                    ServiceStatusId = sId,
                    ServiceTypeId = service.Id,
                });
            }

            await _uow.ServiceTypeRepo.CreateAsync(service);
            return service;
        }

        public async Task<ServiceType> GetServiceTypeDetailWithRequirementsTracking(Guid id)
        {
            var rawDetail = await _uow.ServiceTypeRepo.GetServiceTypeDetailWithRequirementsTrackingAsync(id);

            return rawDetail;
        }

        public async Task<ServiceType> UpdateServiceTypeStatuses(Guid serviceId, string addressOption)
        {
            var rawDetail = await _uow.ServiceTypeRepo.UpdateServiceTypeStatusAsync(serviceId, addressOption);

            return rawDetail;
        }
    }
}
