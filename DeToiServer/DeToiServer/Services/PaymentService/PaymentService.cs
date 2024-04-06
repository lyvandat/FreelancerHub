using AutoMapper;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.PaymentDtos;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Payment;
using Microsoft.EntityFrameworkCore;

namespace DeToiServer.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public PaymentService(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetFreelancePaymentHistoryDto>> GetAllFreelancePayment()
        {
            var result = await _uow.PaymentRepo.GetAllFreelancePaymentAsync();

            return _mapper.Map<IEnumerable<GetFreelancePaymentHistoryDto>>(result);
        }

        public async Task<IEnumerable<GetFreelancePaymentHistoryDto>> GetFreelancePaymentHistories(Guid freelanceId)
        {
            var result = await _uow.PaymentRepo.GetFreelancePaymentHistoriesAsync(freelanceId);

            return _mapper.Map<IEnumerable<GetFreelancePaymentHistoryDto>>(result);
        }

        private async Task<FreelancePaymentHistory> AddFreelancePaymentHistory(AddFreelancePaymentHistoryDto paymentHistory)
        {
            var toAddData = _mapper.Map<FreelancePaymentHistory>(paymentHistory);

            return await _uow.PaymentRepo.AddFreelancePaymentHistoryAsync(toAddData);
        }

        public async Task<GetFreelanceAccountShortDetailDto> UpdateFreelancerBalance(UpdateFreelanceBalanceDto toUpdate)
        {
            var rawFreelancer = await _uow.FreelanceAccountRepo.GetByAccId(toUpdate.Id);
            var freelancer = _mapper.Map<GetFreelanceAccountShortDetailDto>(rawFreelancer);

            if (toUpdate.Value != 0)
            {
                double updatedValue = 0;
                if (toUpdate.WalletType.Equals(GlobalConstant.Payment.Wallet.Personal))
                {
                    updatedValue = freelancer.Balance + toUpdate.Value;
                    rawFreelancer.Balance = Helper.AesEncryption.Encrypt(rawFreelancer.Id.ToString(), updatedValue.ToString());
                }
                else if (toUpdate.WalletType.Equals(GlobalConstant.Payment.Wallet.System))
                {
                    updatedValue = freelancer.SystemBalance + toUpdate.Value;
                    rawFreelancer.SystemBalance = Helper.AesEncryption.Encrypt(rawFreelancer.Id.ToString(), updatedValue.ToString());
                }
                
                if (updatedValue != 0)
                {
                    await AddFreelancePaymentHistory(new AddFreelancePaymentHistoryDto()
                    {
                        FreelanceAccountId = rawFreelancer.Id,
                        Method = toUpdate.Method,
                        Value = toUpdate.Value,
                        Wallet = toUpdate.WalletType,
                    });
                }
            }

            return freelancer;
        }

    }
}
