using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.PaymentDtos;
using DeToiServerCore.Models.Payment;

namespace DeToiServer.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<IEnumerable<GetFreelancePaymentHistoryDto>> GetAllFreelancePayment();
        Task<IEnumerable<GetFreelancePaymentHistoryDto>> GetFreelancePaymentHistories(Guid freelanceId);
        Task<GetFreelanceAccountShortDetailDto?> UpdateFreelancerBalance(UpdateFreelanceBalanceDto toUpdate, bool minus = false);

    }
}
