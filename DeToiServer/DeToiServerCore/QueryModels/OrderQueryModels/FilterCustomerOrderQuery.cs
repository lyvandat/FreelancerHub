using DeToiServerCore.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.QueryModels.OrderQueryModels
{
    public class FilterCustomerOrderQuery
    {
        public string? SortingCol { get; set; } = string.Empty;
        public string? SortType { get; set; } = string.Empty;

        public IEnumerable<Guid>? OrderStatusId { get; set; } // = StatusConst.StatusIdCollections;

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
