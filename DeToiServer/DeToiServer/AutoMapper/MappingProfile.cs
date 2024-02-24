using AutoMapper;
using DeToiServer.Dtos;
using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.CleaningServiceDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.RepairingServiceDtos;
using DeToiServer.Dtos.LocationDtos;
using DeToiServer.Dtos.ServiceCategoryDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServer.Dtos.ShoppingServiceDtos;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;

namespace DeToiServer.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Account
            CreateMap<GetAccountDto, Account>().ReverseMap();
            CreateMap<PutAccountDto, Account>().ReverseMap();

            #endregion

            #region ServiceType and ServiceCategory
            CreateMap<PostServiceTypeDto, ServiceType>().ReverseMap();
            CreateMap<GetServiceTypeDto, ServiceType>().ReverseMap();
            CreateMap<PutServiceTypeDto, ServiceType>().ReverseMap();
            CreateMap<GetServiceCategoryDto, ServiceCategory>().ReverseMap();
            CreateMap<GetServiceCategoryWithChildDto, ServiceCategory>().ReverseMap();
            CreateMap<PostServiceCategoryDto, ServiceCategory>().ReverseMap();
            CreateMap<PutServiceCategoryDto, ServiceCategory>().ReverseMap();
            #endregion

            #region services for an order
            CreateMap<PostOrderDto, Order>().ReverseMap();
            CreateMap<PostCleaningServiceDto, CleaningService>().ReverseMap();
            CreateMap<PostRepairingServiceDto, RepairingService>().ReverseMap();
            CreateMap<PostShoppingServiceDto, ShoppingService>().ReverseMap();
            #endregion

            #region GeoCoding
            CreateMap<AddressResultDto, RevGeoCodeResultDto> ().ReverseMap();
            #endregion
        }
    }
}
