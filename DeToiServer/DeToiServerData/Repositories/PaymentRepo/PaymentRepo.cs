using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Payment;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories.PaymentRepo
{
    public class PaymentRepo(DataContext context) : IPaymentRepo
    {
        private readonly DataContext _context = context;

        public async Task<IEnumerable<FreelancePaymentHistory>> GetAllFreelancePaymentAsync()
        {
            var query = _context.FreelancePaymentHistories
                .AsNoTracking().AsSplitQuery()
                .Include(p => p.FreelanceAccount);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<FreelancePaymentHistory>> GetFreelancePaymentHistoriesAsync(Guid freelanceId)
        {
            var query = _context.FreelancePaymentHistories
                .AsNoTracking().AsSplitQuery()
                .Include(p => p.FreelanceAccount)
                .Where(p => p.FreelanceAccountId.Equals(freelanceId)
                    || p.FreelanceAccount.AccountId.Equals(freelanceId));

            return await query.ToListAsync();
        }

        public async Task<FreelancePaymentHistory> AddFreelancePaymentHistoryAsync(FreelancePaymentHistory paymentHistory)
        {
            var result = await _context.FreelancePaymentHistories.AddAsync(paymentHistory);

            return result.Entity;
        }
    }
}
