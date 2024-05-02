using DeToiServer.Dtos.ChattingDtos;
using DeToiServerCore.Models.Chat;

namespace DeToiServer.Services.ChattingService
{
    public interface IChattingService
    {
        Task<IEnumerable<MessageDto>> GetCurrentChatSession(Guid fromId, Guid toId, int pageNum = 1, int? numOfMessage = null);
        Task<MessageDto> PostSendMessageByAccountId(Guid fromId, PostSendMessageDto sendDto);
        Task<IEnumerable<GetMessagePreviewDto>> GetMessageHistoryByAccountId(Guid accountId);
    }
}
