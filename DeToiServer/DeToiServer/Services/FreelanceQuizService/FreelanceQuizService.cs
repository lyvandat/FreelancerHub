using AutoMapper;
using DeToiServer.Dtos.QuizDtos;
using DeToiServerCore.Models.Quiz;

namespace DeToiServer.Services.FreelanceQuizService
{
    public class FreelanceQuizService : IFreelanceQuizService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public FreelanceQuizService(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetPreDefinedQuizDto>>  GetAllPreDefinedQuiz()
        {
            return _mapper.Map<IEnumerable<GetPreDefinedQuizDto>>(await _uow.FreelanceQuizRepo.GetPreDefinedQuizzesAsync());
        }

        public async Task<IEnumerable<FreelanceQuizResultDto>> GetAllQuizResult()
        {
            return _mapper.Map<IEnumerable<FreelanceQuizResultDto>>(await _uow.FreelanceQuizRepo.GetAllQuizResultAsync());
        }

        public async Task<FreelanceQuizResultDto> GetLatestQuizResult(Guid freelancerId)
        {
            var rawData = await _uow.FreelanceQuizRepo.GetLatestQuizResultAsync(freelancerId);
            return _mapper.Map<FreelanceQuizResultDto>(rawData);
        }

        public async Task<GetPreDefinedQuizDto> GetRandomPreDefinedQuiz()
        {
            var quizzes = _mapper.Map<IEnumerable<GetPreDefinedQuizDto>>(await _uow.FreelanceQuizRepo.GetPreDefinedQuizzesAsync());

            return quizzes.First(); // quizzes.ElementAt(random.Next(quizzes.Count()));
        }

        public async Task<GetPreDefinedQuizDto?> GetFreelancerUncompleteQuiz(Guid freelancerId)
        {
            var quiz = await _uow.FreelanceQuizRepo.GetNewFreelancerQuizAsync(freelancerId);
            if (quiz == null)
            {
                _ = await _uow.FreelanceQuizRepo.AddNewFreelancerQuizAsync(freelancerId);
                if (!await _uow.SaveChangesAsync()) return null;
            }

            var addedQuiz = await _uow.FreelanceQuizRepo.GetNewFreelancerQuizAsync(freelancerId);
            
            return _mapper.Map<GetPreDefinedQuizDto>(addedQuiz);
        }

        public async Task<FreelanceQuizResult> PostFreelanceQuizResult(PostFreelanceQuizResultDto data)
        {
            var toAdd = _mapper.Map<FreelanceQuizResult>(data);
            toAdd.TotalCorrect = toAdd.CorrectQuestions.Count;
            var afterAdd = await _uow.FreelanceQuizRepo.AddFreelanceQuizResultAsync(toAdd);

            return afterAdd;
        }

        public async Task<bool> IsFreelancerDoneQuiz(Guid freelancerId)
            => await _uow.FreelanceQuizRepo.IsFreelancerDoneQuizAsync(freelancerId);
    }
}
