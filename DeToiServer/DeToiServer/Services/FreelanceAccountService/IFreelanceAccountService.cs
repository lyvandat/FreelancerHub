using DeToiServer.Dtos.FreelanceDtos;
using DeToiServerCore.Models.Accounts;
using System.Linq.Expressions;

namespace DeToiServer.Services.FreelanceAccountService
{
    public interface IFreelanceAccountService
    {
        Task<FreelanceAccount> GetById(Guid id);
        Task<IEnumerable<FreelanceAccount>> GetAll();
        Task<FreelanceAccount> GetByCondition(Expression<Func<FreelanceAccount, bool>> predicate);
        Task<FreelanceAccount> Add(FreelanceAccount acc);
        Task<FreelanceAccount> Update(FreelanceAccount acc);
        Task<FreelanceAccount> GetByAccId(Guid id);
        Task<GetFreelanceMatchingDto> GetDetailWithStatistic(Guid id);
    }
}
