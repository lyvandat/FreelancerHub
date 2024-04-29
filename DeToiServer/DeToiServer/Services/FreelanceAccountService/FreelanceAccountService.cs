using AutoMapper;
using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.SkillDtos;
using DeToiServerCore.Models.Accounts;
using System.Linq.Expressions;

namespace DeToiServer.Services.FreelanceAccountService
{
    public class FreelanceAccountService : IFreelanceAccountService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FreelanceAccountService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FreelanceAccount>> GetAll()
        {
            return await _unitOfWork.FreelanceAccountRepo.GetAllAsync();
        }

        public async Task<FreelanceAccount> GetById(Guid id)
        {
            return await _unitOfWork.FreelanceAccountRepo.GetByIdAsync(id);
        }

        public async Task<FreelanceAccount> GetByCondition(Expression<Func<FreelanceAccount, bool>> predicate)
        {
            return await _unitOfWork.FreelanceAccountRepo.GetByConditionsAsync(predicate);
        }

        public async Task<FreelanceAccount> Add(FreelanceAccount acc)
        {
            var added = await _unitOfWork.FreelanceAccountRepo.CreateAsync(acc);

            return added;
        }

        public async Task<FreelanceAccount> Update(FreelanceAccount acc)
        {
            var updated = await _unitOfWork.FreelanceAccountRepo.UpdateAsync(acc);
            await _unitOfWork.SaveChangesAsync();

            return updated;
        }

        public async Task<FreelanceAccount> GetByAccId(Guid id)
        {
            return await _unitOfWork.FreelanceAccountRepo.GetByAccId(id);
        }

        public async Task<GetFreelancerWalletDto> GetByAccIdWithWallet(Guid id)
        {
            var accWithWallet = await _unitOfWork.FreelanceAccountRepo.GetByAccIdWithWallet(id);
            return _mapper.Map<GetFreelancerWalletDto>(accWithWallet);
        }

        public async Task<FreelanceAccount> GetByAccPhone(string phone)
        {
            return await _unitOfWork.FreelanceAccountRepo.GetByAccPhone(phone);
        }

        public async Task<GetFreelanceMatchingDto> GetDetailWithStatistic(Guid id)
        {
            var rawResult = await _unitOfWork.FreelanceAccountRepo.GetDetailByIdWithStatistic(id);

            var orders = rawResult.Orders;
            if (orders != null && orders.Any())
            {
                rawResult.Rating = orders.Average(o => o.Rating);
                rawResult.TotalReviewCount = orders.Where(o => o.Comment != null).ToList().Count;
                rawResult.OrderCount = orders.Count;
                rawResult.PositiveReviewCount = orders.Where(o => o.Rating > 4.0).ToList().Count;
            }

            var favoriteBy = rawResult.FavoriteBy;
            if (favoriteBy != null)
            {
                rawResult.LoveCount = favoriteBy.Count;
            }

            var getFreelancerDto = _mapper.Map<GetFreelanceMatchingDto>(rawResult);
            getFreelancerDto.AccountId = rawResult.Id;
            return getFreelancerDto;
        }

        public async Task<IEnumerable<GetFreelanceMatchingDto>> GetAllFreelanceDetail()
        {
            var result = await _unitOfWork.FreelanceAccountRepo.GetAllDetail();
            return _mapper.Map<List<GetFreelanceMatchingDto>>(result);
        }



        public async Task<IEnumerable<FreelanceServiceType>> AddServiceTypesFreelancer(Guid freelancerId, IEnumerable<Guid> serviceTypes)
        {
            var addedServiceType = await _unitOfWork.FreelanceAccountRepo.ChooseFreelancerServiceTypesAsync(freelancerId, serviceTypes);
            return addedServiceType;
        }

        public async Task<IEnumerable<FreelanceServiceType>> RemoveServiceTypesFreelancer(Guid freelancerId, IEnumerable<Guid> serviceTypes)
        {
            var removededServiceType = await _unitOfWork.FreelanceAccountRepo.RemoveFreelancerServiceTypesAsync(freelancerId, serviceTypes);
            return removededServiceType;
        }

        public async Task<bool> RefundAuctionBalance(IEnumerable<Guid> accountIds, IDictionary<Guid, double> auctionPrice)
        {
            return await _unitOfWork.FreelanceAccountRepo.RefundAuctionBalance(accountIds, auctionPrice);
        }
    }
}
