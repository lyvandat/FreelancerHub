using AutoMapper;
using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.AdminDto;
using DeToiServer.Dtos.ChattingDtos;
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
using DeToiServerCore.Models.Chat;
using DeToiServerCore.Models.Notifications;
using DeToiServerCore.Models.Payment;
using DeToiServerCore.Models.Quiz;
using DeToiServerCore.Models.Reports;
using DeToiServerCore.Models.Services;
using DeToiServerCore.Models.SevicesUIElement;
using DeToiServerCore.QueryModels.ServiceTypeQueryModels;
using Newtonsoft.Json;
using static DeToiServerCore.Common.Helper.Helper;

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
            CreateMap<FreelanceServiceType, GetServiceTypeDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<GetServiceTypeDto>(src.ServiceType);
                });

            CreateMap<Order, GetFreelanceReviewDto>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer!.Id))
                .ForMember(dest => dest.Avt, opt => opt.MapFrom(src => src.Customer!.Account.Avatar ?? GlobalConstant.DefaultCommentAvt))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Customer!.Account.FullName ?? "Người dùng"))
                .ForMember(dest => dest.RatingPoint, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Comment ?? GlobalConstant.DefaultCommentContent))
                .ForMember(dest => dest.ReviewDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.FinishTime ?? GlobalConstant.Review.DefaultDateTime)));

            CreateMap<FreelanceAccount, GetFreelanceDto>()
                .ForMember(dest => dest.IdentityNumber, opt => opt.MapFrom(src => AesEncryption.Decrypt(src.IdentityNumber, src.EncriptingToken)))
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.FreelanceSkills))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => (src.Address ?? new List<Address>()).FirstOrDefault()))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.ActiveTime, opt => opt.MapFrom(src => src.Account.CreatedAt))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => Convert.ToDouble(Helper.AesEncryption.Decrypt(src.Balance, src.EncriptingToken))))
                .ForMember(dest => dest.SystemBalance, opt => opt.MapFrom(src => Convert.ToDouble(Helper.AesEncryption.Decrypt(src.SystemBalance, src.EncriptingToken))))
                .ForMember(dest => dest.FreelancerFeasibleServices, opt => opt.MapFrom(src => src.FreelancerFeasibleServices));

            CreateMap<FreelanceAccount, GetFreelanceMatchingDto>()
                .ForMember(dest => dest.IdentityNumber, opt => opt.MapFrom(src => AesEncryption.Decrypt(src.IdentityNumber, src.EncriptingToken)))
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.FreelanceSkills))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => (src.Address ?? new List<Address>()).FirstOrDefault()))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.ActiveTime, opt => opt.MapFrom(src => src.Account.CreatedAt))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => Convert.ToDouble(AesEncryption.Decrypt(src.Balance, src.EncriptingToken))))
                .ForMember(dest => dest.SystemBalance, opt => opt.MapFrom(src => Convert.ToDouble(Helper.AesEncryption.Decrypt(src.SystemBalance, src.EncriptingToken))))
                .ForMember(dest => dest.FreelancerFeasibleServices, opt => opt.MapFrom(src => src.FreelancerFeasibleServices ));

            CreateMap<GetFreelanceMatchingDto, GetFreelanceDto>();

            CreateMap<FreelanceAccount, GetFreelanceAccountShortDetailDto>()
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Account.Avatar ?? GlobalConstant.DefaultCommentAvt))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Account.FullName ?? "Người dùng"))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => Convert.ToDouble(AesEncryption.Decrypt(src.Balance, src.EncriptingToken))))
                .ForMember(dest => dest.SystemBalance, opt => opt.MapFrom(src => Convert.ToDouble(Helper.AesEncryption.Decrypt(src.SystemBalance, src.EncriptingToken))));

            CreateMap<BiddingOrder, GetFreelanceMatchingDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<GetFreelanceMatchingDto>(src.Freelancer);
                });

            CreateMap<FreelanceAccount, GetFreelancerWalletDto>()
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => Convert.ToDouble(Helper.AesEncryption.Decrypt(src.Balance, src.EncriptingToken))));
            CreateMap<FreelancePaymentHistory, GetFreelanceShortPaymentHistoryDto>()
                .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentType.ToString()))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => Convert.ToDouble(Helper.AesEncryption.Decrypt(src.Value, src.FreelanceAccount.EncriptingToken))));

            #endregion

            #region Payment
            CreateMap<FreelancePaymentHistory, GetFreelancePaymentHistoryDto>()
                .ForMember(dest => dest.Value, opt => opt
                    .MapFrom(src => Convert.ToDouble(AesEncryption.Decrypt(src.Value, src.FreelanceAccount.EncriptingToken))));

            CreateMap<AddFreelancePaymentHistoryDto, FreelancePaymentHistory>()
                //.ForMember(dest => dest.Value, opt => opt.Ignore())
                .ForMember(dest => dest.Description, opt => opt
                    .MapFrom(src => GlobalConstant.Payment.MethodTypeDictionary[src.Method.ToString()]));
            #endregion

            #region ServiceType and ServiceCategory
            CreateMap<GetServiceTypeDto, ServiceType>().ReverseMap();
            CreateMap<ServiceType, GetServiceTypeDetailDto>()
                .ForMember(dest => dest.Keys, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<string>>(src.Keys)));
            CreateMap<PostServiceTypeDto, ServiceType>().ReverseMap();
            CreateMap<PutServiceTypeDto, ServiceType>().ReverseMap();

            CreateMap<PostServiceTypeWithRequirementDto, ServiceType>()
                .ForMember(dest => dest.Keys, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Keys)));

            CreateMap<PutServiceTypeWithRequirementDto, ServiceType>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Keys, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Keys)));

            CreateMap<ServiceType, GetServiceTypeWithCategoryDto>();

            CreateMap<ServiceCategory, GetServiceCategoryDto>()
                .ForMember(dest => dest.Keys, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<string>>(src.Keys)))
                .ForMember(dest => dest.ServiceClassName, opt => opt.MapFrom(src => Helper.GetServiceClassName(src.ServiceClassName)))
                .ForMember(dest => dest.ServiceTypeCount, opt => opt.MapFrom(src => src.ServiceTypes != null ? src.ServiceTypes.Count() : 0));
            CreateMap<ServiceCategory, GetServiceCategoryWithChildDto>()
                .ForMember(dest => dest.Keys, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<string>>(src.Keys)))
                .ForMember(dest => dest.ServiceClassName, opt => opt.MapFrom(src => Helper.GetServiceClassName(src.ServiceClassName)))
                .ForMember(dest => dest.ServiceTypeCount, opt => opt.MapFrom(src => src.ServiceTypes != null ? src.ServiceTypes.Count() : 0));

            CreateMap<PostServiceCategoryDto, ServiceCategory>()
                .ForMember(dest => dest.Keys, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Keys ?? new List<string>() { })))
                .ForMember(dest => dest.ServiceClassName, opt => opt.MapFrom(src => ""));
            CreateMap<PutServiceCategoryDto, ServiceCategory>()
                .ForMember(dest => dest.Keys, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Keys ?? new List<string>() { })));

            CreateMap<GetServiceStatusDto, ServiceStatus>().ReverseMap();

            CreateMap<ServiceTypeStatus, GetServiceStatusDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<GetServiceStatusDto>(src.ServiceStatus);
                });

            CreateMap<ICollection<OrderServiceType>, ICollection<GetServiceStatusDto>>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<ICollection<GetServiceStatusDto>>(src.SelectMany(ost => ost.ServiceType.ServiceStatusList)
                        .OrderBy(stt => stt.ServiceStatus.Priority));
                });

            CreateMap<FreelanceServiceType, GetServiceTypeDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<GetServiceTypeDto>(src.ServiceType);
                });
            #endregion

            #region Order and Services for an order
            CreateMap<OrderAddress, AddressDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<AddressDto>(src.Address);
                });
            CreateMap<PostOrderAddressDto, OrderAddress>()
                .ConvertUsing((src, dest, context) => {
                    if (src.Id != null)
                    {
                        return new OrderAddress()
                        {
                            AddressId = src.Id ?? Guid.Empty,
                        };
                    }

                    return new OrderAddress()
                    {
                        Address = context.Mapper.Map<Address>(src), 
                    };
                });

            CreateMap<Order, OrderPlacedDto>();
            CreateMap<PaymentStatusHistory, PostPaymentStatusHistoryDto>().ReverseMap();
            CreateMap<PostOrderDto, Order>()
                .ForMember(dest => dest.OrderAddress, opt => opt.Ignore()) // MapFrom(src => src.Address)
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
                .ForMember(dest => dest.ServiceStatusList, opt => opt.MapFrom(src => src.OrderServiceTypes))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.OrderAddress));

            CreateMap<Order, GetCustomerOrderDto>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeOnly.FromDateTime(src.StartTime)))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.StartTime)))
                .ForMember(dest => dest.FinishTime, opt => opt.MapFrom(src => TimeOnly.FromDateTime(src.FinishTime ?? DateTime.MinValue)))
                .ForMember(dest => dest.FinishDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.FinishTime ?? DateTime.MinValue)))
                .ForMember(dest => dest.Freelance, opt => opt.MapFrom(src => src.Freelance != null ? src.Freelance.Account : null))
                .ForMember(dest => dest.ServiceStatus, opt => opt.MapFrom(src => src.ServiceStatusId)) //  != null ? src.ServiceStatus.Name : "Chờ xử lí"
                .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.OrderServices!.FirstOrDefault()))
                .ForMember(dest => dest.ServiceTypes, opt => opt.MapFrom(src => src.OrderServiceTypes))
                .ForMember(dest => dest.ServiceStatusList, opt => opt.MapFrom(src => src.OrderServiceTypes))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.OrderAddress));

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
                    return new()
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
            CreateMap<UIElementValidationType, UIElementValidationTypeDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => Helper.StringToNum(src.Value)));
            CreateMap<UIElementInputOption, UIElementInputOptionDto>().ReverseMap();
            CreateMap<UIElementOptionInfo, UIElementOptionInfoDto>()
                .ForMember(dest => dest.Buttons, opt => opt.MapFrom(src => !src.Buttons.Equals("default") ? JsonConvert.DeserializeObject<IEnumerable<string>>(src.Buttons) : new List<string>() { }))
                .ForMember(dest => dest.DefaultValue, opt => opt.MapFrom(src => Helper.StringToNum(src.DefaultValue)));

            CreateMap<UIElementOptionInfoValidation, UIElementOptionInfoValidationDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => Helper.StringToNum(src.Value)));

            CreateMap<UIElementInputMethodType, UIElementInputMethodTypeDto>().ReverseMap();
            CreateMap<UIElementServiceRequirement, UIElementServiceRequirementDto>().ReverseMap();
            CreateMap<UIElementAdditionServiceRequirement, UIElementAdditionServiceRequirementDto>().ReverseMap();

            CreateMap<PostUIElementServiceRequirementInputMethodDto, UIElementServiceRequirementInputMethod>();
            CreateMap<PostUIElementValidationTypeDto, UIElementValidationType>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => !string.IsNullOrEmpty($"{src.Value}") ? $"{src.Value}" : null ));
            CreateMap<PostUIElementInputOptionDto, UIElementInputOption>()
                .ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.Info ?? new List<PostUIElementOptionInfoDto>() { }));

            CreateMap<PostUIElementOptionInfoDto, UIElementOptionInfo>()
                .ForMember(dest => dest.Buttons, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Buttons ?? new List<string>() { })))
                .ForMember(dest => dest.DefaultValue, opt => opt.MapFrom(src => !string.IsNullOrEmpty($"{src.DefaultValue}") ? $"{src.DefaultValue}" : "1" ));

            CreateMap<PostUIElementOptionInfoValidationDto, UIElementOptionInfoValidation>();
            CreateMap<PostUIElementInputMethodTypeDto, UIElementInputMethodType>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options ));
            CreateMap<PostUIElementServiceRequirementDto, UIElementServiceRequirement>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => Helper.RequirementLabelToKey(src.Label) ));
            CreateMap<PostUIElementAdditionServiceRequirementDto, UIElementAdditionServiceRequirement>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => Helper.RequirementLabelToKey(src.Label)));
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
                .ForMember(dest => dest.PushSound, opt => opt.MapFrom(src => src.Sound))
                .ForMember(dest => dest.PushSubTitle, opt => opt.MapFrom(src => src.SubTitle))
                .ForMember(dest => dest.PushBadgeCount, opt => opt.MapFrom(src => src.Badge))
                .ForMember(dest => dest.PushData, opt => opt.MapFrom(src => src.Data));

            CreateMap<PushNotificationDto, Notification>()
                .ForMember(dest => dest.PushTo, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.ExpoPushTokens)))
                .ForMember(dest => dest.PushTitle, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.PushBody, opt => opt.MapFrom(src => src.Body))
                .ForMember(dest => dest.PushSound, opt => opt.MapFrom(src => src.Sound))
                .ForMember(dest => dest.PushSubTitle, opt => opt.MapFrom(src => src.SubTitle))
                .ForMember(dest => dest.PushBadgeCount, opt => opt.MapFrom(src => src.Badge))
                .ForMember(dest => dest.PushData, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Data)));

            CreateMap<Notification, PushNotificationDto>()
                .ForMember(dest => dest.ExpoPushTokens, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<IEnumerable<string>>(src.PushTo)))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.PushTitle))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.PushBody))
                .ForMember(dest => dest.Sound, opt => opt.MapFrom(src => src.PushSound))
                .ForMember(dest => dest.SubTitle, opt => opt.MapFrom(src => src.PushSubTitle))
                .ForMember(dest => dest.Badge, opt => opt.MapFrom(src => src.PushBadgeCount))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<PushNotificationDataDto>(src.PushData)));

            CreateMap<Notification, GetNotificationDto>()
                .ConvertUsing((src, dest, context) => {
                    var result = new GetNotificationDto()
                    {
                        Date = Helper.ToTimeNumber(src.CreatedAt),
                        Request = new NotificationRequestDto()
                        {
                            Content = new NotificationContentDto()
                            {
                                Data = JsonConvert.DeserializeObject<PushNotificationDataDto>(src.PushData)!,
                                Title = src.PushTitle,
                                Body = src.PushBody,
                                Sound = src.PushSound,
                                Subtitle = src.PushSubTitle,
                                Badge = src.PushBadgeCount,
                            },
                            Identifier = null,
                            Trigger = null,
                        }
                    };

                    return result;
                });

            CreateMap<NotificationAccount, GetNotificationDto>()
                .ConvertUsing((src, dest, context) => {
                    return context.Mapper.Map<GetNotificationDto>(src.Notification);
                });

            #endregion

            #region Report
            CreateMap<PostReportDto, Report>()
                .ForMember(dest => dest.Images, opt => opt.Ignore());
            #endregion

            #region Admin
            CreateMap<ServiceTypeDistributionModel, ServicePercentageAdminDto>()
                .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Percentage, opt => opt.MapFrom(src => src.Percentage));
            #endregion

            #region Chatting
            CreateMap<Account, MessageSenderDto>()
                .ForMember(dest => dest.Type, opt => opt.Ignore());
            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.TimeReceived, opt => opt.MapFrom(src => src.Time));
            CreateMap<Message, MessagePreviewDto>()
                .ForMember(dest => dest.TimeReceived, opt => opt.MapFrom(src => src.Time));

            CreateMap<Message, GetMessagePreviewDto>()
                .ConvertUsing((src, dest, context) => {
                    var senderDetail = context.Mapper.Map<MessageSenderDto>(src.Sender);
                    return new GetMessagePreviewDto()
                    {
                        LatestMessage = context.Mapper.Map<MessagePreviewDto>(src),
                        Sender = senderDetail,
                    };
                });
            #endregion
        }
    }
}