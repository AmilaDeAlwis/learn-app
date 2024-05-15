using backend.Enum;

namespace backend.Dtos.CustomQuestion
{
    public class GetCustomQuestionDto
    {
        public string Id { get; set; } // Unique identifier for the custom question document
        public string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }

        // Possible answers for multiple choice questions
        public List<GetAnswerOptionDto> AnswerOptions { get; set; }

        // Reference to the Course ID
        public string CourseId { get; set; }
    }
}
