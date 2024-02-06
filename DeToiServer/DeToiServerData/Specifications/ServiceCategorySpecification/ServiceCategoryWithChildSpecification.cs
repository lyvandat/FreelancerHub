using DeToiServerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerData.Specifications.ServiceCategorySpecification
{
    public class ServiceCategoryWithChildSpecification : Specification<ServiceCategory>
    {
        public ServiceCategoryWithChildSpecification()
        {
            AddInclude(sc => sc.ServiceTypes);
        }
    }
}
