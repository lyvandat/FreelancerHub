using DeToiServerPayment.Models;

namespace DeToiServerPayment.Data
{
    public interface IOrderRepo
    {
        Task<bool> SaveChangesAsync();

        bool OrderExists(Guid orderId);
        bool ExternalOrderExists(Guid externalOrderId);
        void AddOrder(Order order);
        Task<Order?> GetOrderById(Guid orderId);
    }
}
