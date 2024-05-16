using AutoMapper;
using DeToiServer.Dtos.AccountDtos;
using DeToiServerCore.Models.Accounts;
using System.Linq.Expressions;
using static DeToiServerCore.Common.Helper.Helper;

namespace DeToiServer.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _unitOfWork.AccountRepo.GetAllAsync();
        }

        public async Task<Account> GetById(Guid id)
        {
            return await _unitOfWork.AccountRepo.GetByIdAsync(id);
        }

        public async Task<Account> GetByCondition(Expression<Func<Account, bool>> predicate)
        {
            return await _unitOfWork.AccountRepo.GetByConditionsAsync(predicate);
        }

        public async Task<Account> Add(Account acc)
        {
            var added = await _unitOfWork.AccountRepo.CreateAsync(acc);
            await _unitOfWork.SaveChangesAsync();

            return added;
        }

        public async Task<Account> Update(Account acc)
        {
            var updated = await _unitOfWork.AccountRepo.UpdateAsync(acc);
            await _unitOfWork.SaveChangesAsync();

            return updated;
        }

        public async Task<GetAccountDto> GetAccountDetailsById(Guid accountId)
        {
            var account = await _unitOfWork.AccountRepo.GetByIdAsync(accountId);

            return _mapper.Map<GetAccountDto>(account);
        }

        public async Task BanAccount(Guid accountId)
        {
            var account = await _unitOfWork.AccountRepo.GetByIdAsync(accountId);
            account.IsActive = false;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetAccountDto>> GetAllAccountInfo(FilterAccountQuery searchAccount)
        {
            var rawAccounts = await _unitOfWork.AccountRepo.GetAllAccountInfoAsync(searchAccount);

            return rawAccounts.Select(_mapper.Map<GetAccountDto>);
        }

        public async Task<Account> GetByPhone(string countryCode, string phone)
        {
            var rawAccount = await _unitOfWork.AccountRepo.GetByPhoneAsync(countryCode, phone);

            return rawAccount;
        }

        public async Task<Account> GetByCombinedPhone(string combinedPhone)
        {
            var encryptedPhone = AesEncryption.Encrypt(combinedPhone);
            return await _unitOfWork.AccountRepo.GetByCombinedPhoneAsync(encryptedPhone);
        }
    }
}
