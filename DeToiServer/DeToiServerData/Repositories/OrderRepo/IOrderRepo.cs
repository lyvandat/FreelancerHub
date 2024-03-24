using DeToiServerCore.Models;
using DeToiServerCore.QueryModels.OrderQueryModels;

namespace DeToiServerData.Repositories.OrderRepo
{
    public interface IOrderRepo : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllOrderWithDetailAsync();
        Task<Order> GetOrderDetailByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetCustomerOrders(Guid customerId);
        Task<IEnumerable<Order>> GetFreelancerSuitableOrders(Guid freelancerId, FilterFreelancerOrderQuery filterQuery);
        Task<Order> GetLatestCustomerOrders(Guid customerId);
        Task<IEnumerable<Order>> GetFreelancerIncomingOrdersAsync(Guid freelancerId);
    }
}
