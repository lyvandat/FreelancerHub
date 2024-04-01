using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Quiz;
using DeToiServerCore.QueryModels.FreelanceSkillQueryModels;
using DeToiServerData.Repositories.FreelancerQuizRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

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

        public async Task<IEnumerable<Skill>> GetFreelancerSkillInCategoryAsync(Guid categoryId, int? length)
        {
            var query = _context.Skills.AsNoTracking().AsSplitQuery()
                .Include(sk => sk.ServiceTypeOfSkill)
                .Where(sk => sk.ServiceTypeOfSkill.Any(st_sk => st_sk.ServiceTypeId.Equals(categoryId)));

            if (length != null)
            {
                var lengthNew = length ?? 25;
                return await query.Take(lengthNew).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Skill>> SeachFreelanceSkillsAsync(FreelanceSkillQuery search)
        {
            var query = _context.Skills.AsNoTracking().AsSplitQuery()
                .Include(sk => sk.ServiceTypeOfSkill)
                .Where(sk => sk.ServiceTypeOfSkill.Any(st_sk => st_sk.ServiceTypeId.Equals(search.CategoryId ?? Guid.Empty))
                    && sk.Name.Contains(search.Key));

            return await query.ToListAsync();
        }
    }
}
