using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Quiz;

namespace DeToiServer.Dtos.QuizDtos
{
    public class GetPreDefinedQuizDto
    {
        public Guid Id { get; set; }
        public int TotalTime { get; set; }
        public int TotalQuestion { get; set; }
        public Guid FreelancerId { get; set; }
        public required ICollection<FreelanceQuizQuestionDto> QuizQuestions { get; set; }
    }

    public class FreelanceQuizAnswerDto // Trả lời
    {
        public Guid Id { get; set; }
        public string Answer { get; set; } = string.Empty;
        public bool IsCorrect { get; set; } = true;
    }

    public class FreelanceQuizQuestionDto // Câu hỏi
    {
        public Guid Id { get; set; }
        public required string Type { get; set; } = String.Empty;
        public required ICollection<string> OfSkills { get; set; }
        public required string Question { get; set; } = string.Empty;
        public required ICollection<FreelanceQuizAnswerDto> Answers { get; set; }
    }

    public class FreelanceQuizResultDto // Kết quả kiểm tra
    {
        public Guid Id { get; set; }
        public DateTime CompletedAt { get; set; }
        public int TotalCorrect { get; set; }
        public required ICollection<FreelanceQuizQuestionDto> CorrectQuestions { get; set; }
        public required GetPreDefinedQuizDto Quiz { get; set; }
    }

    public class PostCorrectQuizQuestionDto
    {
        public required Guid QuestionId { get; set; }
    }

    public class PostFreelanceQuizResultDto // Kết quả kiểm tra
    {
        public Guid QuizId { get; set; }
        public Guid FreelancerId { get; set; }
        public DateTime CompletedAt { get; set; }
        public int TotalCorrect { get; set; }
        public required ICollection<PostCorrectQuizQuestionDto> CorrectQuestions { get; set; }
    }
}
