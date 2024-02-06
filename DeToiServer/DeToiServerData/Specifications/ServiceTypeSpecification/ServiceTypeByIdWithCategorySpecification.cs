using DeToiServerCore.Models.Services;
using System.Linq.Expressions;

namespace DeToiServerData.Specifications.ServiceTypeSpecification
{
    public class ServiceTypeByIdWithCategorySpecification : Specification<ServiceType>
    {
        public ServiceTypeByIdWithCategorySpecification(Expression<Func<ServiceType, bool>> criteria) : base(criteria)
        {
            AddInclude(st => st.ServiceCategory);
        }
    }
}
