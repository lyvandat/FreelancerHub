using DeToiServer.Dtos.SkillDtos;

namespace DeToiServer.Dtos.FreelanceDtos
{
    public class PostFreelanceServiceTypeDto
    {
        
    }

    public class ChooseFreelancerServiceTypesDto
    {
        public Guid FreelancerId { get; set; }
        public required IEnumerable<Guid> ServiceTypes { get; set; }
    }
}
