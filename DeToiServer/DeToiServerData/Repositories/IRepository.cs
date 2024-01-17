using DeToiServerCore.Models;
using System.Linq.Expressions;

namespace DeToiServerData.Repositories
{
    public interface IRepository<TModel> where TModel : ModelBase
    {
        IQueryable<TModel> Query { get; }

        TModel GetById(int id);
        Task<TModel> GetByIdAsync(int id);

        TModel GetByConditions(Expression<Func<TModel, bool>> predicate);
        Task<TModel> GetByConditionsAsync(Expression<Func<TModel, bool>> predicate);

        IEnumerable<TModel> GetAll();
        Task<IEnumerable<TModel>> GetAllAsync();


        TModel Create(TModel entity);
        Task<TModel> CreateAsync(TModel entity);

        TModel Update(TModel entity);
        Task<TModel> UpdateAsync(TModel entity);

        TModel Delete(int id);
        Task<TModel> DeleteAsync(int id);
    }
}
