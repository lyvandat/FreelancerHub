using DeToiServerCore.Models;
using DeToiServerData.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DeToiServerData.Repositories
{
    public abstract class RepositoryBase<TModel> : IRepository<TModel> where TModel : ModelBase
    {
        public IQueryable<TModel> Query => _context.Set<TModel>().AsQueryable();
        private readonly DataContext _context;

        public RepositoryBase(DataContext dbContext)
        {
            _context = dbContext;
        }

        public TModel GetById(int id)
        {
            return _context.Set<TModel>().Find(id);
        }
        public virtual async Task<TModel> GetByIdAsync(int id)
        {
            return await _context.Set<TModel>().FindAsync(id);
        }

        public TModel GetByConditions(Expression<Func<TModel, bool>> predicate)
        {
            return _context.Set<TModel>().Where(predicate).FirstOrDefault();
        }
        public async Task<TModel> GetByConditionsAsync(Expression<Func<TModel, bool>> predicate)
        {
            return await _context.Set<TModel>().FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<TModel> GetAll()
        {
            return _context.Set<TModel>().ToList();
        }
        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await _context.Set<TModel>().ToListAsync();
        }

        public TModel Create(TModel entity)
        {
            return _context.Add(entity).Entity;
        }
        public virtual async Task<TModel> CreateAsync(TModel entity)
        {
            var result = await _context.AddAsync(entity);
            return result.Entity;
        }

        public TModel Update(TModel entity)
        {
            return _context.Update(entity).Entity;
        }
        public virtual async Task<TModel> UpdateAsync(TModel entity)
        {
            return await Task.Run(() =>
            {
                return _context.Update(entity).Entity;
            });
        }

        public TModel Delete(int id)
        {
            var entity = GetById(id);
            return _context.Remove(entity).Entity;
        }
        public virtual async Task<TModel> DeleteAsync(int id)
        {
            return await Task.Run(() =>
            {
                var entity = GetById(id);
                return _context.Remove(entity).Entity;
            });
        }

        protected IQueryable<TModel> ApplySpecification(
            Specification<TModel> specification)
        {
            return SpecificationEvaluator.GetQuery(
                _context.Set<TModel>(),
                specification);
        }
    }
}
