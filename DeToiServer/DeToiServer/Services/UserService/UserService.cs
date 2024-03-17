using DeToiServer.Models;

namespace DeToiServer.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _uow;

        public UserService(UnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<User> GetUserByPhone(string phoneNumber)
            => await _uow.UserRepo.GetByConditionsAsync(u => u.Phone == phoneNumber);
    }
}
