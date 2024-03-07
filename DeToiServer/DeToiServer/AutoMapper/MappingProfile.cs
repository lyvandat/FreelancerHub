using AutoMapper;
using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.CleaningServiceDtos;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.LocationDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.ServiceCategoryDtos;
using DeToiServer.Dtos.ServiceProvenDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServer.Dtos.SkillDtos;
using DeToiServer.Dtos.UIElementDtos;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;
using DeToiServerCore.Models.SevicesUIElement;

namespace DeToiServer.AutoMapper
{
    #region Location Mapper Resolver
    public class WardResolver : IValueResolver<LocationAddressResultDto, RevGeoCodeResultDto, string>
    {
        public string Resolve(LocationAddressResultDto source, RevGeoCodeResultDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Quarter))
                return source.Quarter;
            if (!string.IsNullOrEmpty(source.Town))
                return source.Town;
            if (!string.IsNullOrEmpty(source.Village))
                return source.Village;

            return string.Empty; // or throw an exception, depending on your logic
        }
    }

    public class DistrictResolver : IValueResolver<LocationAddressResultDto, RevGeoCodeResultDto, string>
    {
        public string Resolve(LocationAddressResultDto source, RevGeoCodeResultDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Suburb))
                return source.Suburb;
            if (!string.IsNullOrEmpty(source.County))
                return source.County;
            if (!string.IsNullOrEmpty(source.City_district))
                return source.City_district;

            return string.Empty; // or throw an exception, depending on your logic
        }
    }

    public class ProvinceResolver : IValueResolver<LocationAddressResultDto, RevGeoCodeResultDto, string>
    {
        public string Resolve(LocationAddressResultDto source, RevGeoCodeResultDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.City))
                return source.City;
            if (!string.IsNullOrEmpty(source.State))
                return source.State;

            return string.Empty; // or throw an exception, depending on your logic
        }
    }
    #endregion

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Account
            CreateMap<GetAccountDto, Account>().ReverseMap();
            CreateMap<PutAccountDto, Account>().ReverseMap();

            #endregion

            #region Address
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, PostOrderAddressDto>().ReverseMap();
            #endregion

            #region Skill
            CreateMap<Skill, SkillDto>().ReverseMap();
            #endregion

            #region Freelance
            CreateMap<FreelanceAccount, GetFreelanceDto>()
                .ForMember(dest => dest.Address, opt => opt.Ignore());
            #endregion

            #region ServiceType and ServiceCategory
            CreateMap<GetServiceTypeDto, ServiceType>().ReverseMap();
            CreateMap<GetServiceTypeDetailDto, ServiceType>().ReverseMap();
            CreateMap<PostServiceTypeDto, ServiceType>().ReverseMap();
            CreateMap<PutServiceTypeDto, ServiceType>().ReverseMap();
            CreateMap<GetServiceCategoryDto, ServiceCategory>().ReverseMap();
            CreateMap<GetServiceCategoryWithChildDto, ServiceCategory>().ReverseMap();
            CreateMap<PostServiceCategoryDto, ServiceCategory>().ReverseMap();
            CreateMap<PutServiceCategoryDto, ServiceCategory>().ReverseMap();
            #endregion

            #region services for an order
            CreateMap<PostOrderDto, Order>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartDate.ToDateTime(src.StartTime)));
            
            //CreateMap<PostOrderDto, Order>().ReverseMap();
            CreateMap<PostCleaningServiceDto, CleaningService>().ReverseMap();
            CreateMap<PostServiceProvenDto, ServiceProven>().ReverseMap();
            CreateMap<ServiceProven, GetServiceProvenDto>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.Order != null ? src.Order.StartTime : default(DateTime)))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.Order != null ? src.Order.FinishTime : default(DateTime)))
                .ForMember(dest => dest.EstimatedPrice, opt => opt.MapFrom(src => src.Order != null ? src.Order.EstimatedPrice : 0))
                .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.ServiceType != null ? src.ServiceType.Description : "Dịch vụ DeToi"));
            #endregion

            #region GeoCoding
            CreateMap<LocationAddressResultDto, RevGeoCodeResultDto>()
                .ForMember(dest => dest.Ward, opt => opt.MapFrom<WardResolver>())
                .ForMember(dest => dest.District, opt => opt.MapFrom<DistrictResolver>())
                .ForMember(dest => dest.Province, opt => opt.MapFrom<ProvinceResolver>());

            CreateMap<GeoCodeResponseDto, GeoCodeResultDto>();

            #endregion

            #region UI Element requirement and additional requirement

            #region Map UIElementValidationType
            CreateMap<UIElementValidationType, UIElementValidationTypeDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => Helper.StringToNum(src.Value)));

            #endregion
            CreateMap<UIElementServiceRequirementInputMethod, UIElementServiceRequirementInputMethodDto>().ReverseMap();

            CreateMap<UIElementInputOption, UIElementInputOptionDto>().ReverseMap();
            CreateMap<UIElementInputMethodType, UIElementInputMethodTypeDto>().ReverseMap();
            CreateMap<UIElementServiceRequirement, UIElementServiceRequirementDto>().ReverseMap();
            CreateMap<UIElementAdditionServiceRequirement, UIElementAdditionServiceRequirementDto>().ReverseMap();
            #endregion
        }
    }
}