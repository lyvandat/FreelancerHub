using DeToiServerCore.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models.Services
{
    public class OrderSkillRequired
    {
        public required Guid OrderId { get; set; }
        public required Order Order { get; set; }
        public required Guid SkillId { get; set; }
        public required Skill Skill { get; set; }
    }
}
