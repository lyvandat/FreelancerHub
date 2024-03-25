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
                .FirstOrDefaultAsync(fq => fq.FreelancerId.Equals(freelancerId));
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
