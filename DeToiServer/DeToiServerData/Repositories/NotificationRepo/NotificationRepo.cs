using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerData.Repositories.NotificationRepo
{
    public class NotificationRepo : RepositoryBase<Notification>, INotificationRepo
    {
        private readonly DataContext _context;
        public NotificationRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notification>> RemoveOldNotificationsAsync()
        {
            DateTime thresholdDate = DateTime.UtcNow.AddDays(-GlobalConstant.Notification.TimeSpan);
            var toDelete = await _context.Notifications.AsSplitQuery()
                .Include(noti => noti.NotificationAccounts)
                .Where(noti => noti.CreatedAt < thresholdDate)
                .ToListAsync();

            _context.RemoveRange(toDelete);
            return toDelete;
        }

        public async Task<IEnumerable<NotificationAccount>> GetAllNotificationByAccountIdAsync(Guid accountId)
        {
            var query = _context.NotificationAccounts
                .AsNoTracking().AsSplitQuery()
                .Include(na => na.Notification)
                .Where(na => na.AccountId.Equals(accountId));

            return await query.ToListAsync();
        }
    }
}
