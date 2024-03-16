using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models.Accounts
{
    public class Skill : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SkillCategory { get; set; } = string.Empty;
        public ICollection<FreelanceSkill>? FreelanceSkills { get; set; }
    }
}
