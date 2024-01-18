using AutoMapper;
using System.Linq.Expressions;

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

        public async Task<Account> GetById(int id)
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
    }
}
