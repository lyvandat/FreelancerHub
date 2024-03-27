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
            var category = await _context.ServiceCategories.AsNoTracking().AsSplitQuery()
                .FirstOrDefaultAsync(cate => cate.Id.Equals(categoryId));

            var query = _context.Skills.AsNoTracking().AsSplitQuery()
                .Where(sk => sk.SkillCategory.Equals(category.ServiceClassName));

            if (length != null)
            {
                var lengthNew = length ?? 25;
                return await query.Take(lengthNew).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Skill>> SeachFreelanceSkillsAsync(FreelanceSkillQuery search)
        {
            var categoryName = search.CategoryId != null ?
                (await _context.ServiceCategories.FindAsync(search.CategoryId ?? Guid.Empty)).ServiceClassName
                : string.Empty;

            var query = _context.Skills.AsNoTracking().AsSplitQuery()
                .Where(s => s.Name.Contains(search.Key) && s.SkillCategory.Contains(categoryName));

            return await query.ToListAsync();
        }
    }
}
