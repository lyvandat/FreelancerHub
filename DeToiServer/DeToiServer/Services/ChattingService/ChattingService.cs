using AutoMapper;
using DeToiServer.Dtos.ChattingDtos;
using DeToiServer.RealTime;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Chat;

namespace DeToiServer.Services.ChattingService
{
    public class ChattingService : IChattingService
    {
        private readonly RealtimeConsumer _consumer;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChattingService(
            RealtimeConsumer consumer,
            UnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _consumer = consumer;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageDto>> GetCurrentChatSession(Guid fromId, Guid toId, int pageNum = 1, int? numOfMessage = null)
        {
            var loadCount = numOfMessage ?? GlobalConstant.ChatConst.LoadCount;

            var data = await _unitOfWork.MessageRepo.GetChatSessionAsync(new () {
                FromId = fromId,
                ToId = toId,
                Page = pageNum,
                PageSize = loadCount
            });

            var result = new List<MessageDto>();
            foreach (var item in data)
            {
                var mapped = _mapper.Map<MessageDto>(item);
                if (item.Sender.Role.Equals(GlobalConstant.Freelancer))
                {
                    mapped.Sender.Type = GlobalConstant.ChatConst.Freelancer;
                } else if (item.Sender.Role.Equals(GlobalConstant.Admin))
                {
                    mapped.Sender.Type = GlobalConstant.ChatConst.Admin;
                }
                result.Add(mapped);
            }

            return result;
        }

        public async Task<MessageDto> PostSendMessageByAccountId(Guid fromId, PostSendMessageDto sendDto)
        {
            var msgToSend = new Message()
            {
                IsSystem = sendDto.IsSystem,
                Image = sendDto.Image,
                Content = sendDto.Content,
                SenderId = fromId,
                ReceiverId = sendDto.SendTo
            };

            var sentMsg = await _unitOfWork.MessageRepo.CreateAsync(msgToSend);

            var mapped = _mapper.Map<MessageDto>(sentMsg);
            var currentAcc = await _unitOfWork.AccountRepo.GetByIdAsync(fromId);
            mapped.Sender = _mapper.Map<MessageSenderDto>(currentAcc);
            if (currentAcc.Role.Equals(GlobalConstant.Freelancer))
                mapped.Sender.Type = GlobalConstant.ChatConst.Freelancer;

            return mapped;
        }

        public async Task<IEnumerable<GetMessagePreviewDto>> GetMessageHistoryByAccountId(Guid accountId)
        {
            var data = await _unitOfWork.MessageRepo.GetChatHistoryByIdAsync(accountId);
            var result = new List<GetMessagePreviewDto>();
            foreach (var item in data)
            {
                var mapped = _mapper.Map<GetMessagePreviewDto>(item);
                if (!item.Sender.Id.Equals(accountId))
                {
                    mapped.ConversationId = item.SenderId;
                    if (item.Sender.Role.Equals(GlobalConstant.Freelancer))
                        mapped.Sender.Type = GlobalConstant.ChatConst.Freelancer;
                    else if (item.Sender.Role.Equals(GlobalConstant.Admin))
                        mapped.Sender.Type = GlobalConstant.ChatConst.Admin;
                }
                else
                {
                    mapped.ConversationId = item.ReceiverId;
                    mapped.Sender = _mapper.Map<MessageSenderDto>(item.Receiver);
                    if (item.Receiver.Role.Equals(GlobalConstant.Freelancer))
                        mapped.Sender.Type = GlobalConstant.ChatConst.Freelancer;
                    else if (item.Receiver.Role.Equals(GlobalConstant.Admin))
                        mapped.Sender.Type = GlobalConstant.ChatConst.Admin;
                }
                result.Add(mapped);
            }

            return result;
        }
    }
}
