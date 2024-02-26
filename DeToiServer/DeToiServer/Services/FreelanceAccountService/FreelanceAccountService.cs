using AutoMapper;
using DeToiServer.Dtos.AccountDtos;
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
            await _unitOfWork.SaveChangesAsync();

            return added;
        }

        public async Task<FreelanceAccount> Update(FreelanceAccount acc)
        {
            var updated = await _unitOfWork.FreelanceAccountRepo.UpdateAsync(acc);
            await _unitOfWork.SaveChangesAsync();

            return updated;
        }
    }
}
