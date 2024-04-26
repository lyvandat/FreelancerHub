using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.QueryModels.AccountQueryModels
{
    public class AccountCreationDateAndRolesQuery
    {
        public int? Month { get; set; }
        public int? Year { get; set; }
        public List<string> Roles { get; set; } = null!;
    }
}
