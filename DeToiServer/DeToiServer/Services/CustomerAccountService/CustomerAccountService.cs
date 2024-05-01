using AutoMapper;
using DeToiServer.Dtos.AccountDtos;
using DeToiServerCore.Models.Accounts;
using System.Linq.Expressions;

namespace DeToiServer.Services.CustomerAccountService
{
    public class CustomerAccountService : ICustomerAccountService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerAccountService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerAccount>> GetAll()
        {
            return await _unitOfWork.CustomerAccountRepo.GetAllAsync();
        }

        public async Task<CustomerAccount> GetById(Guid id)
        {
            return await _unitOfWork.CustomerAccountRepo.GetByIdAsync(id);
        }

        public async Task<CustomerAccount> GetByIdWithAccount(Guid id)
        {
            return await _unitOfWork.CustomerAccountRepo.GetByIdWithAccount(id);
        }

        public async Task<CustomerAccount> GetByCondition(Expression<Func<CustomerAccount, bool>> predicate)
        {
            return await _unitOfWork.CustomerAccountRepo.GetByConditionsAsync(predicate);
        }

        public async Task<CustomerAccount> Add(CustomerAccount acc)
        {
            var added = await _unitOfWork.CustomerAccountRepo.CreateAsync(acc);
            await _unitOfWork.SaveChangesAsync();

            return added;
        }

        public async Task<CustomerAccount> Update(CustomerAccount acc)
        {
            var updated = await _unitOfWork.CustomerAccountRepo.UpdateAsync(acc);
            await _unitOfWork.SaveChangesAsync();

            return updated;
        }

        public async Task<CustomerAccount> GetByAccId(Guid accId)
            => await _unitOfWork.CustomerAccountRepo.GetByConditionsAsync(customer => customer.AccountId == accId || customer.Id == accId);
    }
}
