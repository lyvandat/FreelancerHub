using DeToiServer.Dtos.QuizDtos;
using DeToiServerCore.Models.Quiz;

namespace DeToiServer.Services.FreelanceQuizService
{
    public interface IFreelanceQuizService
    {
        Task<IEnumerable<GetPreDefinedQuizDto>> GetAllPreDefinedQuiz();
        Task<IEnumerable<FreelanceQuizResultDto>> GetAllQuizResult();
        Task<FreelanceQuizResultDto> GetLatestQuizResult(Guid freelancerId);
        Task<GetPreDefinedQuizDto> GetRandomPreDefinedQuiz();
        Task<FreelanceQuizResult> PostFreelanceQuizResult(PostFreelanceQuizResultDto data);
        Task<GetPreDefinedQuizDto?> GetFreelancerUncompleteQuiz(Guid freelancerId);
        Task<bool> IsFreelancerDoneQuiz(Guid freelancerId);
    }
}
