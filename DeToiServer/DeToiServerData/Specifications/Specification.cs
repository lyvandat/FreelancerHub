using DeToiServerCore.Models;
using System.Linq.Expressions;

namespace DeToiServerData.Specifications
{
    public abstract class Specification<TEntity>
        where TEntity : class
    {
        protected Specification() { }

        protected Specification(Expression<Func<TEntity, bool>> criteria) {
            Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>> Criteria { get; }

        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; private set; } = [];

        public Expression<Func<TEntity, object>> OrderByExpression { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescendingExpression { get; private set; }

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
            => IncludeExpressions.Add(includeExpression);

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
            => OrderByExpression = orderByExpression;

        protected void AddOrderByAscending(Expression<Func<TEntity, object>> orderByAscendingExpression)
            => OrderByDescendingExpression = orderByAscendingExpression;
    }
}
