using System.Text.Json.Serialization;

namespace DeToiServerCore.QueryModels.FreelanceSkillQueryModels
{
    public class FreelanceSkillQuery
    {
        public string? Key { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
