using DeToiServerCore.Models;
using DeToiServerCore.QueryModels.OrderQueryModels;

namespace DeToiServerData.Repositories.OrderRepo
{
    public interface IOrderRepo : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllOrderWithDetailAsync();
        Task<IEnumerable<Order>> GetOrderWithDetailAsync(FilterOrderQuery filterOrderQuery);
        Task<Order> GetOrderDetailByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetFreelancerSuitableOrders(Guid freelancerId, FilterFreelancerOrderQuery filterQuery);
        Task<Order> GetLatestCustomerOrders(Guid customerId);
        Task<IEnumerable<Order>> GetFreelancerIncomingOrdersAsync(Guid freelancerId);
        Task<IEnumerable<Order>> GetCustomerOrders(Guid customerId, FilterCustomerOrderQuery filterQuery);
    }
}
