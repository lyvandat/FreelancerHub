using DeToiServerCore.Models.Quiz;

namespace DeToiServerData.Repositories.FreelancerQuizRepo
{
    public interface IFreelanceQuizRepo : IRepository<FreelanceQuiz>
    {
        Task<IEnumerable<FreelanceQuiz>> GetPreDefinedQuizzesAsync();
        Task<IEnumerable<FreelanceQuizResult>> GetAllQuizResultAsync();
        Task<FreelanceQuizResult> GetLatestQuizResultAsync(Guid freelancerId);
        Task<FreelanceQuizResult> AddFreelanceQuizResultAsync(FreelanceQuizResult data);
        Task<FreelanceQuiz> GetNewFreelancerQuizAsync(Guid freelancerId);
        Task<FreelanceQuiz> AddNewFreelancerQuizAsync(Guid freelancerId);
        Task<bool> IsFreelancerDoneQuizAsync(Guid freelancerId);
    }
}
