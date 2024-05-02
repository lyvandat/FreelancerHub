using DeToiServerCore.Models.Chat;
using DeToiServerCore.QueryModels.MessageQueryModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DeToiServerData.Repositories.MessageRepo
{
    public class MessageRepo(DataContext context) : RepositoryBase<Message>(context), IMessageRepo
    {
        private readonly DataContext _context = context;

        public async Task<IEnumerable<Message>> GetChatSessionAsync(GetChatSessionQuery session)
        {
            var query = _context.Messages
                .AsNoTracking().AsSplitQuery()
                .Where(m => (m.SenderId.Equals(session.FromId) && m.ReceiverId.Equals(session.ToId))
                    || (m.SenderId.Equals(session.ToId) && m.ReceiverId.Equals(session.FromId)))
                .OrderBy(m => m.Time)
                .Skip((session.Page - 1) * session.PageSize).Take(session.PageSize)
                .Include(m => m.Sender)
                .Include(m => m.Receiver);


            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetChatHistoryByIdAsync(Guid accountId)
        {
            var query = _context.Messages
                .AsNoTracking().AsSplitQuery()
                .Where(m => (m.SenderId.Equals(accountId) || m.ReceiverId.Equals(accountId)))
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .GroupBy(m => new { m.SenderId, m.ReceiverId })
                .Select(group => group.OrderByDescending(m => m.Time).FirstOrDefault());

            var rawData = await query.ToListAsync();
            var result = new List<Message>();
            foreach (var message in rawData)
            {
                if (result.Where(msg => IsMessageOfSameChat(msg, message) && IsNewerMessage(message, msg)).Any())
                { ///  && !IsNewerMessage(msg, message)
                    var dupMessage = result.FirstOrDefault(fmsg => IsMessageOfSameChat(fmsg, message));
                    if (dupMessage != null)
                    {
                        result.Remove(dupMessage);
                        result.Add(message);
                    }
                }
                else
                {
                    result.Add(message);
                }
            }

            return result.OrderByDescending(e => e.Time);
        }

        private static bool IsMessageOfSameChat(Message _this, Message other)
        {
            return _this.SenderId.Equals(other.ReceiverId) && _this.ReceiverId.Equals(other.SenderId);
        }

        private static bool IsNewerMessage(Message _this, Message other)
        {
            return !(_this.Time < other.Time);
        }
    }
}
