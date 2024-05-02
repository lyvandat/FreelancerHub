using DeToiServerCore.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.QueryModels.MessageQueryModels
{
    public class GetChatSessionQuery
    {
        public Guid FromId { get; set; }
        public Guid ToId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = GlobalConstant.ChatConst.LoadCount;
    }
}
