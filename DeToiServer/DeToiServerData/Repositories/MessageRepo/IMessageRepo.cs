using DeToiServerCore.Models.Chat;
using DeToiServerCore.QueryModels.MessageQueryModels;

namespace DeToiServerData.Repositories.MessageRepo
{
    public interface IMessageRepo : IRepository<Message>
    {
        Task<IEnumerable<Message>> GetChatSessionAsync(GetChatSessionQuery session);
        Task<IEnumerable<Message>> GetChatHistoryByIdAsync(Guid accountId);
    }
}
