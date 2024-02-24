using DeToiServerCore.Models;
using System.Linq.Expressions;

namespace DeToiServerData.Repositories
{
    public interface IRepository<TModel> where TModel : ModelBase
    {
        IQueryable<TModel> Query { get; }

        TModel GetById(Guid id);
        Task<TModel> GetByIdAsync(Guid id);

        TModel GetByConditions(Expression<Func<TModel, bool>> predicate);
        Task<TModel> GetByConditionsAsync(Expression<Func<TModel, bool>> predicate);

        IEnumerable<TModel> GetAll();
        Task<IEnumerable<TModel>> GetAllAsync();


        TModel Create(TModel entity);
        Task<TModel> CreateAsync(TModel entity);

        TModel Update(TModel entity);
        Task<TModel> UpdateAsync(TModel entity);

        TModel Delete(Guid id);
        Task<TModel> DeleteAsync(Guid id);
    }
}
