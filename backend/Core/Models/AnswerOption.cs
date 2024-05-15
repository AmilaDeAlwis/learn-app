using Newtonsoft.Json;

namespace backend.Core.Models
{
    public class AnswerOption
    {
        [JsonProperty("id")]
        public string Id { get; set; } // Unique identifier for the answer option document
        public string OptionText { get; set; }

        // Reference to the CustomQuestion ID
        public string CustomQuestionId { get; set; }

    }
}
