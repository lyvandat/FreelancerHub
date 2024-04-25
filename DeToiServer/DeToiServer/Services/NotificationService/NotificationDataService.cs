using AutoMapper;
using DeToiServer.Dtos.NotificationDtos;

namespace DeToiServer.Services.NotificationService
{
    public class NotificationDataService : INotificationDataService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public NotificationDataService(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetNotificationDto>> GetAllNotificationByAcountId(Guid accountId)
        {
            var notiRaw = await _uow.NotificationRepo.GetAllNotificationByAccountIdAsync(accountId);
            return _mapper.Map<IEnumerable<GetNotificationDto>>(notiRaw);
        }
    }
}
