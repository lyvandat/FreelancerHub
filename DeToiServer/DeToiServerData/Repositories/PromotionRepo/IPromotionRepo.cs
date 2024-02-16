using DeToiServerCore.Models;

namespace DeToiServerData.Repositories.PromotionRepo
{
    public interface IPromotionRepo : IRepository<Promotion>
    {
        Task<bool> RedeemPromotionAsync(int promotionId, int customerId, int quantity);
    }
}
