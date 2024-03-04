using DeToiServerCore.Models.Services;
using System.Linq.Expressions;

namespace DeToiServerData.Specifications.ServiceProvenSpecification
{
    public class ServiceProvenWithOrderAndService : Specification<ServiceProven>
    {
        public ServiceProvenWithOrderAndService()
        {
            AddInclude(sp => sp.Order);
            AddInclude(sp => sp.ServiceType);
        }
    }

    public class ServiceProvenByIdWithOrderAndService : Specification<ServiceProven>
    {
        public ServiceProvenByIdWithOrderAndService(Expression<Func<ServiceProven, bool>> criteria) : base(criteria)
        {
            AddInclude(sp => sp.Order);
            AddInclude(sp => sp.ServiceType);
        }
    }
}