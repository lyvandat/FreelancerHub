
using DeToiServerPayment.Models;

namespace DeToiServerPayment.Data
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;

        public OrderRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _context.Orders.Add(order);
        }

        public bool ExternalOrderExists(Guid externalOrderId)
        {
            return _context.Orders.Any(o => o.ExternalId == externalOrderId);
        }

        public async Task<Order?> GetOrderById(Guid orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public bool OrderExists(Guid orderId)
        {
            return _context.Orders.Any(o => o.Id == orderId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
