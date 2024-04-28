using DeToiServerCore.Models.Payment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerData.Repositories.PaymentRepo
{
    public interface IPaymentRepo
    {
        Task<IEnumerable<FreelancePaymentHistory>> GetAllFreelancePaymentAsync();
        Task<IEnumerable<FreelancePaymentHistory>> GetFreelancePaymentHistoriesAsync(Guid freelanceId);
        Task<FreelancePaymentHistory> AddFreelancePaymentHistoryAsync(FreelancePaymentHistory paymentHistory);
        Task<IEnumerable<Fee>> GetAllFeeAsync();
    }
}
