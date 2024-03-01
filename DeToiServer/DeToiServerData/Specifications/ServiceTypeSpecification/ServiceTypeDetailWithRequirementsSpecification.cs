using DeToiServerCore.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerData.Specifications.ServiceTypeSpecification
{
    public class ServiceTypeDetailWithRequirementsSpecification : Specification<ServiceType>
    {
        public ServiceTypeDetailWithRequirementsSpecification(Expression<Func<ServiceType, bool>> criteria)
            : base(criteria)
        {
            AddInclude(st => st.Requirements);
            AddInclude(st => st.AdditionalRequirements);
        }
    }
}
