using DeToiServerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerData.Specifications.ServiceCategorySpecification
{
    public class ServiceCategoryByIdWithChildSpecification : Specification<ServiceCategory>
    {
        public ServiceCategoryByIdWithChildSpecification(Expression<Func<ServiceCategory, bool>> criteria) : base(criteria)
        {
            AddInclude(sc => sc.ServiceTypes);
        }
    }
}
