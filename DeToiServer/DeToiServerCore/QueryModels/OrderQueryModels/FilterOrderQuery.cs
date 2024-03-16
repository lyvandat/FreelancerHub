using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.QueryModels.OrderQueryModels
{
    public class FilterOrderQuery
    {
        public string? Ward { get; set; } = string.Empty;
        public string? District { get; set; } = string.Empty;
        public string? Province { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string? SortingCol { get; set; } = string.Empty;
        public string? SortType { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 8;
    }
}
