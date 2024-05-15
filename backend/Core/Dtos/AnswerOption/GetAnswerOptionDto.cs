using Newtonsoft.Json;

namespace backend.Core.Dtos.AnswerOption
{
    // AnswerOption model encapsulation
    public class GetAnswerOptionDto
    {
        [JsonProperty("id")]
        public string Id { get; set; } // Unique identifier
        public string OptionText { get; set; }
    }
}
