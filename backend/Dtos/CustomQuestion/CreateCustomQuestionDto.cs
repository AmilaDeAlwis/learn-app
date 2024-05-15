using backend.Enum;

namespace backend.Dtos.CustomQuestion
{
    public class CreateCustomQuestionDto
    {
        public string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }

        // Possible answers for multiple choice questions
        // This should only be set if the question type is MultipleChoice
        public List<CreateAnswerOptionDto> AnswerOptions { get; set; }

        // Reference to the Course ID
        public string CourseId { get; set; }
    }
}
