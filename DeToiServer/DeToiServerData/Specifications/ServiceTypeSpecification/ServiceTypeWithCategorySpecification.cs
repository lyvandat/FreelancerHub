

using DeToiServerCore.Models.Services;

namespace DeToiServerData.Specifications.ServiceTypeSpecification
{
    public class ServiceTypeWithCategorySpecification : Specification<ServiceType>
    {
        public ServiceTypeWithCategorySpecification()
        {
            AddInclude(st => st.ServiceCategory);
        }
    }
}
