using Newtonsoft.Json;

namespace backend.Core.Dtos.Course
{
    public class GetCourseDto
    {
        // Course model encapsulation
        [JsonProperty("id")]
        public string Id { get; set; } // Unique identifier
        public string Title { get; set; }
        public string Description { get; set; }
        // List of StudentInfo IDs to show which students are enrolled
        public List<string> StudentInfoIds { get; set; }
        // List of CustomQuestion IDs to show what custom questions are included
        public List<string> CustomQuestionIds { get; set; }
    }
}
