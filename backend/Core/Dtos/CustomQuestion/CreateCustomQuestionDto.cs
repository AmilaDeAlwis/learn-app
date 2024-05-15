using backend.Core.Dtos.AnswerOption;
using backend.Core.Enum;

namespace backend.Core.Dtos.CustomQuestion
{
    // CustomQuestion model encapsulation
    public class CreateCustomQuestionDto
    {
        public string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }

        // Possible answers for multiple choice questions
        public List<CreateAnswerOptionDto> AnswerOptions { get; set; }

        // Reference to the Course ID
        public string CourseId { get; set; }
    }
}
