using DeToiServerCore.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models.Accounts
{
    public class SkillServiceType
    {
        public required Guid SkillId { get; set; }
        public required Skill Skill { get; set; }
        public required Guid ServiceTypeId { get; set; }
        public required ServiceType ServiceType { get; set; }
    }
}
