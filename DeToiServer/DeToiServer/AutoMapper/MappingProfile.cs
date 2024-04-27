using AutoMapper;
using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.AdminDto;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.LocationDtos;
using DeToiServer.Dtos.NotificationDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.PaymentDtos;
using DeToiServer.Dtos.QuizDtos;
using DeToiServer.Dtos.ReportDtos;
using DeToiServer.Dtos.ServiceCategoryDtos;
using DeToiServer.Dtos.ServiceDtos;
using DeToiServer.Dtos.ServiceProvenDtos;
using DeToiServer.Dtos.ServiceStatusDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServer.Dtos.SkillDtos;
using DeToiServer.Dtos.UIElementDtos;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Notifications;
using DeToiServerCore.Models.Payment;
using DeToiServerCore.Models.Quiz;
using DeToiServerCore.Models.Reports;
using DeToiServerCore.Models.Services;
using DeToiServerCore.Models.SevicesUIElement;
using DeToiServerCore.QueryModels.ServiceTypeQueryModels;
using Newtonsoft.Json;

namespace DeToiServer.AutoMapper
{
    #region Location Mapper Resolver
    //public class AddressComponentResolver : IValueResolver<LocationAddressResultDto, RevGeoCodeResultDto, string>
    //{
    //    public string Resolve(LocationAddressResultDto source, RevGeoCodeResultDto destination, string destMember, ResolutionContext context)
    //    {
    //        if (!string.IsNullOrEmpty(source.Quarter))
    //            return source.Quarter;
    //        if (!string.IsNullOrEmpty(source.Town))
    //            return source.Town;
    //        if (!string.IsNullOrEmpty(source.Village))
    //            return source.Village;

    //        return string.Empty; // or throw an exception, depending on your logic
    //    }
    //}
    #endregion

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Account
            CreateMap<GetAccountDto, Account>().ReverseMap();
            CreateMap<PutAccountDto, Account>().ReverseMap();
            CreateMap<GetFreelanceAccountDto, Account>().ReverseMap();
            CreateMap<GetFreelanceAccountInOrderDto, Account>().ReverseMap();
            #endregion

            #region Address
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, PostOrderAddressDto>().ReverseMap();
            CreateMap<PostAddressDto, Address>();
            #endregion

            #region Skill
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<FreelanceSkill, Skill>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<Skill>(src.Skill);
                });

            CreateMap<FreelanceSkill, SkillDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<SkillDto>(src.Skill);
                });
            #endregion

            #region Freelance
            CreateMap<Order, GetFreelanceReviewDto>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer!.Id))
                .ForMember(dest => dest.Avt, opt => opt.MapFrom(src => src.Customer!.Account.Avatar ?? GlobalConstant.DefaultCommentAvt))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Customer!.Account.FullName ?? "Người dùng"))
                .ForMember(dest => dest.RatingPoint, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Comment ?? GlobalConstant.DefaultCommentContent))
                .ForMember(dest => dest.ReviewDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.FinishTime ?? GlobalConstant.Review.DefaultDateTime)));

            CreateMap<FreelanceAccount, GetFreelanceDto>()
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.FreelanceSkills))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => (src.Address ?? new List<Address>()).FirstOrDefault()))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => Convert.ToDouble(Helper.AesEncryption.Decrypt(src.Id.ToString(), src.Balance))))
                .ForMember(dest => dest.ActiveTime, opt => opt.MapFrom(src => src.Account.CreatedAt))
                .ForMember(dest => dest.SystemBalance, opt => opt.Ignore());


            CreateMap<FreelanceAccount, GetFreelanceMatchingDto>()
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.FreelanceSkills))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => (src.Address ?? new List<Address>()).FirstOrDefault()))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => Convert.ToDouble(Helper.AesEncryption.Decrypt(src.Id.ToString(), src.Balance))))
                .ForMember(dest => dest.SystemBalance, opt => opt.Ignore());


            CreateMap<FreelanceAccount, GetFreelanceAccountShortDetailDto>()
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Account.Avatar ?? GlobalConstant.DefaultCommentAvt))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Account.FullName ?? "Người dùng"))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => Convert.ToDouble(Helper.AesEncryption.Decrypt(src.Id.ToString(), src.Balance))))
                .ForMember(dest => dest.SystemBalance, opt => opt.Ignore());

            CreateMap<BiddingOrder, GetFreelanceMatchingDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<GetFreelanceMatchingDto>(src.Freelancer);
                });

            #endregion

            #region Payment
            CreateMap<FreelancePaymentHistory, GetFreelancePaymentHistoryDto>()
                .ForMember(dest => dest.Value, opt => opt
                    .MapFrom(src => Convert.ToDouble(Helper.AesEncryption.Decrypt(src.FreelanceAccountId.ToString(), src.Value))));

            CreateMap<AddFreelancePaymentHistoryDto, FreelancePaymentHistory>()
                .ForMember(dest => dest.Value, opt => opt
                    .MapFrom(src => Helper.AesEncryption.Encrypt(src.FreelanceAccountId.ToString(), src.Value.ToString())));
            #endregion

            #region ServiceType and ServiceCategory
            CreateMap<GetServiceTypeDto, ServiceType>().ReverseMap();
            CreateMap<GetServiceTypeDetailDto, ServiceType>().ReverseMap();
            CreateMap<PostServiceTypeDto, ServiceType>().ReverseMap();
            CreateMap<PutServiceTypeDto, ServiceType>().ReverseMap();

            CreateMap<ServiceType, GetServiceTypeWithCategoryDto>();

            CreateMap<ServiceCategory, GetServiceCategoryDto>()
                .ForMember(dest => dest.ServiceClassName, opt => opt.MapFrom(src => Char.ToLowerInvariant(src.ServiceClassName[0]) + src.ServiceClassName.Substring(1)))
                .ForMember(dest => dest.ServiceTypeCount, opt => opt.MapFrom(src => src.ServiceTypes != null ? src.ServiceTypes.Count() : 0));
            CreateMap<ServiceCategory, GetServiceCategoryWithChildDto>()
                .ForMember(dest => dest.ServiceClassName, opt => opt.MapFrom(src => Char.ToLowerInvariant(src.ServiceClassName[0]) + src.ServiceClassName.Substring(1)))
                .ForMember(dest => dest.ServiceTypeCount, opt => opt.MapFrom(src => src.ServiceTypes != null ? src.ServiceTypes.Count() : 0));

            CreateMap<PostServiceCategoryDto, ServiceCategory>().ReverseMap();
            CreateMap<PutServiceCategoryDto, ServiceCategory>().ReverseMap();

            CreateMap<GetServiceStatusDto, ServiceStatus>().ReverseMap();

            CreateMap<ServiceTypeStatus, GetServiceStatusDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<GetServiceStatusDto>(src.ServiceStatus);
                });

            CreateMap<ICollection<OrderServiceType>, ICollection<GetServiceStatusDto>>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<ICollection<GetServiceStatusDto>>(src.SelectMany(ost => ost.ServiceType.ServiceStatusList));
                });
            #endregion

            #region Order and Services for an order
            CreateMap<Order, OrderPlacedDto>();
            CreateMap<PaymentStatusHistory, PostPaymentStatusHistoryDto>().ReverseMap();
            CreateMap<PostOrderDto, Order>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartDate.ToDateTime(src.StartTime)));
            CreateMap<Order, GetOrderDto>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeOnly.FromDateTime(src.StartTime)))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.StartTime)))
                .ForMember(dest => dest.FinishTime, opt => opt.MapFrom(src => TimeOnly.FromDateTime(src.FinishTime ?? DateTime.MinValue)))
                .ForMember(dest => dest.FinishDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.FinishTime ?? DateTime.MinValue)))
                .ForMember(dest => dest.Freelance, opt => opt.MapFrom(src => src.Freelance != null ? src.Freelance.Account : null))
                .ForMember(dest => dest.ServiceStatus, opt => opt.MapFrom(src => src.ServiceStatusId)) //  != null ? src.ServiceStatus.Name : "Chờ xử lí"
                .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.OrderServices!.FirstOrDefault()))
                .ForMember(dest => dest.ServiceTypes, opt => opt.MapFrom(src => src.OrderServiceTypes))
                .ForMember(dest => dest.ServiceStatusList, opt => opt.MapFrom(src => src.OrderServiceTypes));

            CreateMap<Order, GetCustomerOrderDto>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeOnly.FromDateTime(src.StartTime)))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.StartTime)))
                .ForMember(dest => dest.FinishTime, opt => opt.MapFrom(src => TimeOnly.FromDateTime(src.FinishTime ?? DateTime.MinValue)))
                .ForMember(dest => dest.FinishDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.FinishTime ?? DateTime.MinValue)))
                .ForMember(dest => dest.Freelance, opt => opt.MapFrom(src => src.Freelance != null ? src.Freelance.Account : null))
                .ForMember(dest => dest.ServiceStatus, opt => opt.MapFrom(src => src.ServiceStatusId)) //  != null ? src.ServiceStatus.Name : "Chờ xử lí"
                .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.OrderServices!.FirstOrDefault()))
                .ForMember(dest => dest.ServiceTypes, opt => opt.MapFrom(src => src.OrderServiceTypes))
                .ForMember(dest => dest.ServiceStatusList, opt => opt.MapFrom(src => src.OrderServiceTypes));

            CreateMap<OrderServiceType, GetServiceTypeDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<GetServiceTypeDto>(src.ServiceType);
                });

            CreateMap<OrderSkillRequired, SkillDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<SkillDto>(src.Skill);
                });

            //CreateMap<OrderServiceType, GetOrderServiceTypeDto>();

            CreateMap<PostServiceProvenDto, ServiceProven>().ReverseMap();
            CreateMap<ServiceProven, GetServiceProvenDto>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.Order != null ? src.Order.StartTime : default(DateTime)))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.Order != null ? src.Order.FinishTime : default(DateTime)))
                .ForMember(dest => dest.EstimatedPrice, opt => opt.MapFrom(src => src.Order != null ? src.Order.EstimatedPrice : 0))
                .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.ServiceType != null ? src.ServiceType.Description : "Dịch vụ DeToi"));
            #endregion

            #region GeoCoding
            CreateMap<LocationAddressResultDto, RevGeoCodeResultDto>()
                .ConvertUsing((src, dest, context) => {
                    return new ()
                    {
                        Country = "Việt Nam", // Default 
                        Province = Helper.GetLocationUnit(src.Formatted_address, 0) ?? GlobalConstant.GeoCodeDefault,
                        District = Helper.GetLocationUnit(src.Formatted_address, 1) ?? GlobalConstant.GeoCodeDefault,
                        Ward = Helper.GetLocationUnit(src.Formatted_address, 2) ?? GlobalConstant.GeoCodeDefault,
                        Road = Helper.GetLocationUnit(src.Formatted_address, 3),
                        House_number = Helper.GetLocationUnit(src.Formatted_address, 4),
                        Amenity = Helper.GetLocationUnit(src.Formatted_address, 5),
                        Display_name = src.Formatted_address,
                        Lat = src.Geometry.Location.Lat,
                        Lon = src.Geometry.Location.Lng,
                        PlaceId = src.Place_id,
                    };
                });

            CreateMap<RevGeoCodeResultDto, GeoCodeResultDto>().ReverseMap();

            CreateMap<LocationAddressResultDto, GeoCodeResultDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<GeoCodeResultDto>(context.Mapper.Map<RevGeoCodeResultDto>(src));
                });

            #endregion

            #region UI Element requirement and additional requirement

            #region Map UIElementValidationType
            CreateMap<UIElementValidationType, UIElementValidationTypeDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => Helper.StringToNum(src.Value)));

            #endregion
            CreateMap<UIElementServiceRequirementInputMethod, UIElementServiceRequirementInputMethodDto>().ReverseMap();

            CreateMap<UIElementInputOption, UIElementInputOptionDto>().ReverseMap();
            CreateMap<UIElementOptionInfo, UIElementOptionInfoDto>()
                .ForMember(dest => dest.Buttons, opt => opt.MapFrom(src => !src.Buttons.Equals("default") ? JsonConvert.DeserializeObject<IEnumerable<string>>(src.Buttons) : new List<string>() {} ));
            CreateMap<UIElementOptionInfoValidation, UIElementOptionInfoValidationDto>().ReverseMap();
            CreateMap<UIElementInputMethodType, UIElementInputMethodTypeDto>().ReverseMap();
            CreateMap<UIElementServiceRequirement, UIElementServiceRequirementDto>().ReverseMap();
            CreateMap<UIElementAdditionServiceRequirement, UIElementAdditionServiceRequirementDto>().ReverseMap();
            #endregion

            #region Service requirement and additional requirement
            CreateMap<PostServiceDto, ServiceDto>().ReverseMap();

            CreateMap<ServiceDto, Service>()
                .ForMember(dest => dest.Requirement, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Requirement)))
                .ForMember(dest => dest.AdditionalRequirement, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.AdditionalRequirement)));

            CreateMap<Service, ServiceDto>()
                .ForMember(dest => dest.Requirement, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<ICollection<RequirementDataDto>>(src.Requirement)))
                .ForMember(dest => dest.AdditionalRequirement, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<ICollection<RequirementDataDto>>(src.AdditionalRequirement)));

            CreateMap<OrderService, ServiceDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<ServiceDto>(src?.Service ?? new Service());
                });
            #endregion

            #region Freelance Quiz
            CreateMap<FreelanceQuizAnswer, FreelanceQuizAnswerDto>().ReverseMap();
            CreateMap<FreelanceQuizQuestion, FreelanceQuizQuestionDto>()
                .ForMember(dest => dest.OfSkills, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<ICollection<string>>(src.OfSkills)));

            CreateMap<FreelanceQuizQuestionDto, FreelanceQuizQuestion>()
                .ForMember(dest => dest.OfSkills, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.OfSkills))); 

            CreateMap<QuizQuestion, FreelanceQuizQuestionDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<FreelanceQuizQuestionDto>(src.Question);
                });
            CreateMap<FreelanceCorrectQuestion, FreelanceQuizQuestionDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<FreelanceQuizQuestionDto>(src.Question);
                });

            CreateMap<FreelanceQuiz, GetPreDefinedQuizDto>();
            CreateMap<FreelanceQuizResult, FreelanceQuizResultDto>();

            CreateMap<PostFreelanceQuizResultDto, FreelanceQuizResult>();
            CreateMap<PostCorrectQuizQuestionDto, FreelanceCorrectQuestion>();
            #endregion

            #region Bidding Order
            CreateMap<GetFreelancerAndPreviewPriceDto, BiddingOrder>().ReverseMap();
            #endregion

            #region Notification
            CreateMap<PushNotificationDto, PushTicketRequest>()
                .ForMember(dest => dest.PushTo, opt => opt.MapFrom(src => src.ExpoPushTokens))
                .ForMember(dest => dest.PushTitle, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.PushBody, opt => opt.MapFrom(src => src.Body))
                .ForMember(dest => dest.PushData, opt => opt.MapFrom(src => src.Data));

            CreateMap<PushNotificationDto, Notification>()
                .ForMember(dest => dest.PushTo, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.ExpoPushTokens)))
                .ForMember(dest => dest.PushTitle, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.PushBody, opt => opt.MapFrom(src => src.Body))
                .ForMember(dest => dest.PushData, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Data)));

            CreateMap<Notification, PushNotificationDto>()
                .ForMember(dest => dest.ExpoPushTokens, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<IEnumerable<string>>(src.PushTo)))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.PushTitle))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.PushBody))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<PushNotificationDataDto>(src.PushData)));

            CreateMap<Notification, GetNotificationDto>()
                .ForMember(dest => dest.ExpoPushTokens, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<IEnumerable<string>>(src.PushTo)))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.PushTitle))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.PushBody))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<PushNotificationDataDto>(src.PushData)));

            CreateMap<NotificationAccount, GetNotificationDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<GetNotificationDto>(src);
                });

            #endregion

            #region Report
            CreateMap<PostReportDto, Report>();
            #endregion

            #region Admin
            CreateMap<ServiceTypeDistributionModel, ServicePercentageAdminDto>()
                .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Percentage, opt => opt.MapFrom(src => src.Percentage));
            #endregion
        }
    }
}