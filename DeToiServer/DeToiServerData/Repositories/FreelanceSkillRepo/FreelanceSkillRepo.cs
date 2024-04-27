using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Quiz;
using DeToiServerCore.Models.Services;
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

        public async Task<IEnumerable<FreelanceSkill>> ChooseFreelancerSkillsAsync(Guid freelancerId, IEnumerable<Guid> skills)
        {
            var addedSkills = await _context.FreelanceSkills.AsNoTracking().AsSplitQuery()
                .Where(fst => fst.FreelancerId.Equals(freelancerId)).Select(fsk => fsk.SkillId)
                .ToListAsync();

            var toAddSkills = skills.Where(skId => !addedSkills.Contains(skId)).Select(skId => new FreelanceSkill
            {
                FreelancerId = freelancerId,
                Freelancer = null!,
                SkillId = skId,
                Skill = null!,
            }).ToList();

            await _context.FreelanceSkills.AddRangeAsync(toAddSkills);

            return toAddSkills;
        }

        public async Task<IEnumerable<Skill>> GetFreelancerSkillInCategoryAsync(Guid categoryId, int? length)
        {
            var query = _context.Skills.AsNoTracking().AsSplitQuery()
                .Include(sk => sk.ServiceTypeOfSkill)
                    .ThenInclude(st_sk => st_sk.ServiceType)
                .Where(sk => sk.ServiceTypeOfSkill.Any(st_sk =>
                    st_sk.ServiceType.ServiceCategoryId.Equals(categoryId) ||
                    st_sk.ServiceTypeId.Equals(categoryId)));

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
                    .ThenInclude(st_sk => st_sk.ServiceType)
                .Where(sk => sk.ServiceTypeOfSkill.Any(st_sk =>
                        st_sk.ServiceType.ServiceCategoryId.Equals(search.CategoryId ?? Guid.Empty) ||
                        st_sk.ServiceTypeId.Equals(search.CategoryId ?? Guid.Empty))
                    && sk.Name.Contains(search.Key));

            return await query.ToListAsync();
        }
    }
}
