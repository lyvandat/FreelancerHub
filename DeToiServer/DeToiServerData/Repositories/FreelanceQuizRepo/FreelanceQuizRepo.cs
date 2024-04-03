using DeToiServerCore.Models;
using DeToiServerCore.Models.Quiz;
using DeToiServerData.Repositories.FreelancerQuizRepo;
using Microsoft.EntityFrameworkCore;

namespace DeToiServerData.Repositories.FreelanceQuizRepo
{
    public class FreelanceQuizRepo(DataContext context)
        : RepositoryBase<FreelanceQuiz>(context), IFreelanceQuizRepo
    {
        private readonly DataContext _context = context;

        public async Task<IEnumerable<FreelanceQuiz>> GetPreDefinedQuizzesAsync()
        {
            var query = _context.FreelanceQuizzes.AsSplitQuery().AsNoTracking();
            return await query
                .Include(fq => fq.QuizQuestions)
                    .ThenInclude(qq => qq.Question)
                        .ThenInclude(qz => qz.Answers)
                .ToListAsync();
        }

        public async Task<FreelanceQuiz> GetNewFreelancerQuizAsync(Guid freelancerId)
        {
            var query = _context.FreelanceQuizzes.AsSplitQuery().AsNoTracking();
            return await query
                .Include(fq => fq.QuizQuestions)
                    .ThenInclude(qq => qq.Question)
                        .ThenInclude(qz => qz.Answers)
                .Include(fq => fq.FreelanceQuizResults)
                .FirstOrDefaultAsync(fq =>
                    fq.FreelancerId.Equals(freelancerId)
                    && fq.FreelanceQuizResults.Count == 0);
        }

        public async Task<bool> IsFreelancerDoneQuizAsync(Guid freelancerId)
        {
            var query = await _context.FreelanceQuizzes.AsSplitQuery().AsNoTracking()
                .Include(fq => fq.FreelanceQuizResults)
                .Where(fq => fq.FreelancerId.Equals(freelancerId)
                    && fq.FreelanceQuizResults.Count > 0).ToListAsync();

            return query.Count != 0;
        }

        public async Task<FreelanceQuiz> AddNewFreelancerQuizAsync(Guid freelancerId)
        {
            var freelance = await _context.Freelancers
                .AsNoTracking().AsSplitQuery()
                .Include(fl => fl.FreelanceSkills)
                    .ThenInclude(fl_sk => fl_sk.Skill)
                .FirstOrDefaultAsync(fl => fl.Id == freelancerId);

            // Materialize the suitable skill categories
            var suitableSkillCategories = freelance.FreelanceSkills
                .Select(fl_sk => fl_sk.Skill.SkillCategory)
                .Distinct()
                .ToList();

            int numOfQuestions = 20;
            var questions = (await _context.FreelanceQuizQuestions.AsSplitQuery().AsNoTracking()
                .Where(quiz => suitableSkillCategories.Any(skill => quiz.OfSkills.Contains(skill)))
                .ToListAsync()).OrderBy(e => Guid.NewGuid()).Take(numOfQuestions).ToList();

            var result = new FreelanceQuiz()
            {
                FreelancerId = freelancerId,
                QuizQuestions = questions.Select(q => new QuizQuestion() { 
                    QuestionId = q.Id, Question = null!,
                    QuizId = Guid.Empty, Quiz = null!
                }).ToList(),
                TotalQuestion = questions.Count,
                TotalTime = questions.Count * 60,

                Freelancer = null!,
                FreelanceQuizResults = null!
            };

            var update = await _context.FreelanceQuizzes.AddAsync(result);
            return update.Entity;
        }

        public async Task<IEnumerable<FreelanceQuizResult>> GetAllQuizResultAsync()
        {
            var query = _context.FreelanceQuizResults.AsSplitQuery().AsNoTracking();
            return await query
                .Include(fq => fq.CorrectQuestions)
                    .ThenInclude(qq => qq.Question)
                        .ThenInclude(qz => qz.Answers)
                .ToListAsync();
        }

        public async Task<FreelanceQuizResult> GetLatestQuizResultAsync(Guid freelancerId)
        {
            var query = _context.FreelanceQuizResults.AsSplitQuery().AsNoTracking();
            return await query
                .Include(fq => fq.CorrectQuestions)
                    .ThenInclude(qq => qq.Question)
                        .ThenInclude(qz => qz.Answers)
                .Include(fq => fq.Quiz)
                    .ThenInclude(q => q.QuizQuestions)
                        .ThenInclude(quizq => quizq.Question)
                            .ThenInclude(qz => qz.Answers)
                .FirstOrDefaultAsync(qr => qr.Quiz.FreelancerId.Equals(freelancerId));
        }

        public async Task<FreelanceQuizResult> AddFreelanceQuizResultAsync(FreelanceQuizResult data)
        {
            var afterAdd = (await _context.FreelanceQuizResults.AddAsync(data)).Entity;

            return afterAdd;
        }
    }
}
