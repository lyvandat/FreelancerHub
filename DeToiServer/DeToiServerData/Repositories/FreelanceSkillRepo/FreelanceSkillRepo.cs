using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Quiz;
using DeToiServerData.Repositories.FreelancerQuizRepo;

namespace DeToiServerData.Repositories.FreelanceSkillRepo
{
    public class FreelanceSkillRepo(DataContext context)
        : RepositoryBase<Skill>(context), IFreelanceSkillRepo
    {
        private readonly DataContext _context = context;

        public async Task ChooseFreelancerSkillsAsync(IEnumerable<FreelanceSkill> skills)
        {
            await _context.FreelanceSkills.AddRangeAsync(skills);
        }
    }
}
