using DeToiServer.Models;

namespace DeToiServer.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetUserByPhone(string phoneNumber);
    }
}
