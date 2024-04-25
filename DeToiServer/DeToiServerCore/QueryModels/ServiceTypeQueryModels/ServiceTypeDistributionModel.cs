using DeToiServerCore.Models;

namespace DeToiServerCore.QueryModels.ServiceTypeQueryModels
{
    public class ServiceTypeDistributionModel : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public double Percentage { get; set; }
    }
}
