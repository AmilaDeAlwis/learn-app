using Newtonsoft.Json;
using backend.Core.Dtos.AnswerOption;
using backend.Core.Enum;

namespace backend.Core.Dtos.CustomQuestion
{
    public class GetCustomQuestionDto
    {
        [JsonProperty("id")]
        public string Id { get; set; } // Unique identifier for the custom question document
        public string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }

        // Possible answers for multiple choice questions
        public List<GetAnswerOptionDto> AnswerOptions { get; set; }

        // Reference to the Course ID
        public string CourseId { get; set; }
    }
}
