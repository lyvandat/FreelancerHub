using AutoMapper;

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

        public async Task<Account> GetAccountById(int id)
        {
            return await _unitOfWork.AccountRepo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAllAccount()
        {
            return await _unitOfWork.AccountRepo.GetAllAsync();
        }
    }
}
