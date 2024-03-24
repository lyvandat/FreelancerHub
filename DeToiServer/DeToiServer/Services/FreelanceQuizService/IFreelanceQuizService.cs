using DeToiServer.Dtos.QuizDtos;
using DeToiServerCore.Models.FreelanceQuiz;

namespace DeToiServer.Services.FreelanceQuizService
{
    public interface IFreelanceQuizService
    {
        Task<IEnumerable<GetPreDefinedQuizDto>> GetAllPreDefinedQuiz();
        Task<IEnumerable<FreelanceQuizResultDto>> GetAllQuizResult();
        Task<FreelanceQuizResultDto> GetLatestQuizResult(Guid freelancerId);
        Task<GetPreDefinedQuizDto> GetRandomPreDefinedQuiz();
        Task<FreelanceQuizResult> PostFreelanceQuizResult(PostFreelanceQuizResultDto data);
    }
}
