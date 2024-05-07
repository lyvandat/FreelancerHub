using AutoMapper;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.PaymentDtos;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Payment;
using static DeToiServerCore.Common.Helper.Helper;

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

        public async Task<FreelancePaymentHistory> AddFreelancePaymentHistory(AddFreelancePaymentHistoryDto paymentHistory)
        {
            var toAddData = _mapper.Map<FreelancePaymentHistory>(paymentHistory);
            

            return await _uow.PaymentRepo.AddFreelancePaymentHistoryAsync(toAddData);
        }

        public async Task<GetFreelanceAccountShortDetailDto?> UpdateFreelancerBalance(UpdateFreelanceBalanceDto toUpdate, bool minus = false, bool addRecord = true)
        {
            var rawFreelancer = await _uow.FreelanceAccountRepo.GetByAccId(toUpdate.Id);
            var freelancer = _mapper.Map<GetFreelanceAccountShortDetailDto>(rawFreelancer);

            if (toUpdate.Value != 0)
            {
                double updatedValue = 0;
                if (toUpdate.WalletType.Equals(GlobalConstant.Payment.Wallet.Personal))
                {
                    if (minus)
                    {
                        updatedValue = freelancer.Balance - toUpdate.Value;
                    }
                    else
                    {
                        updatedValue = freelancer.Balance + toUpdate.Value;
                    }

                    if (updatedValue < 0)
                    {
                        return null;
                    }

                    rawFreelancer.Balance = AesEncryption.Encrypt(updatedValue.ToString(), rawFreelancer.EncriptingToken);
                }
                else if (toUpdate.WalletType.Equals(GlobalConstant.Payment.Wallet.System))
                {
                    updatedValue = freelancer.SystemBalance + toUpdate.Value;
                    rawFreelancer.SystemBalance = AesEncryption.Encrypt(updatedValue.ToString(), rawFreelancer.EncriptingToken);
                    rawFreelancer.Balance = AesEncryption.Encrypt((freelancer.Balance + toUpdate.Value).ToString(), rawFreelancer.EncriptingToken);
                }
                
                if (updatedValue > 0 && addRecord)
                {
                    await AddFreelancePaymentHistory(new AddFreelancePaymentHistoryDto()
                    {
                        FreelancerId = rawFreelancer.Id,
                        Method = toUpdate.Method,
                        PaymentType = minus ? PaymentType.Subtract : PaymentType.Add,
                        Value = AesEncryption.Encrypt(toUpdate.Value.ToString(), rawFreelancer.EncriptingToken),
                        Wallet = toUpdate.WalletType,
                    });
                }
            }

            return freelancer;
        }

        public async Task<IEnumerable<Fee>> GetAllFee()
        {
            return await _uow.PaymentRepo.GetAllFeeAsync();
        }

        public async Task<double> GetCommission()
        {
            var allFees = await _uow.PaymentRepo.GetAllFeeAsync();

            return allFees.First(e => e.Id.Equals(GlobalConstant.Fee.Id.PlatformFee)).Amount;
        }

        public async Task<double> GetMinServicePrice() 
        {
            var allFees = await _uow.PaymentRepo.GetAllFeeAsync();

            return allFees.First(e => e.Id.Equals(GlobalConstant.Fee.Id.MinServicePrice)).Amount;
        }
    }
}
