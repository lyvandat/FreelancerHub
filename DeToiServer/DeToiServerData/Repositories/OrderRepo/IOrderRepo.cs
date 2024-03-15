using DeToiServerCore.Models;

namespace DeToiServerData.Repositories.OrderRepo
{
    public interface IOrderRepo : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<Order> GetOrderDetailByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetCustomerOrders(Guid customerId);
    }
}
