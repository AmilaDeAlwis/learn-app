using Newtonsoft.Json;

namespace backend.Core.Dtos.AnswerOption
{
    public class GetAnswerOptionDto
    {
        [JsonProperty("id")]
        public string Id { get; set; } // Unique identifier for the answer option document
        public string OptionText { get; set; }
    }
}
