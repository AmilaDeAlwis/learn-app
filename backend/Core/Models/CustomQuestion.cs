using backend.Core.Enum;
using Newtonsoft.Json;
namespace backend.Core.Models
{
    public class CustomQuestion
    {
        [JsonProperty("id")]
        public string Id { get; set; } // Unique identifier for the custom question document
        public string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }

        // Possible answers for multiple choice questions
        public List<AnswerOption> AnswerOptions { get; set; }
        // Reference to the Course ID
        public string CourseId { get; set; }
    }
}
