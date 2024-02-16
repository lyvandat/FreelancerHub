using DeToiServerCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories.PromotionRepo
{
    public class PromotionRepo : RepositoryBase<Promotion>, IPromotionRepo
    {
        private readonly DataContext _context;

        public PromotionRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> RedeemPromotionAsync(int promotionId, int customerId, int quantity)
        {
            string dateRecorded = DateTime.Now.ToString($"yyyy-MM-dd HH:mm:ss.fffffff");

            var result = await _context.Database
                .ExecuteSqlInterpolatedAsync($"EXEC USP_RedeemPromotion @CustomerId={customerId}, @PromotionId={promotionId}, @Quantity={quantity}, @DateRecorded={dateRecorded};");

            return true;
        }
    }
}
