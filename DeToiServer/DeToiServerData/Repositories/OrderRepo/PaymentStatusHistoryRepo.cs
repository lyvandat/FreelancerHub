using DeToiServerCore.Models;

namespace DeToiServerData.Repositories.OrderRepo
{
    public class PaymentStatusHistoryRepo : RepositoryBase<PaymentStatusHistory>, IPaymentStatusHistoryRepo
    {
        public PaymentStatusHistoryRepo(DataContext context) : base(context)
        {
            
        }
    }
}
