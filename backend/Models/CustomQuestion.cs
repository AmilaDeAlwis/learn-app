namespace backend.Models
{
    public class CustomQuestion
    {
        public string Id { get; set; } // Unique identifier for the custom question document
        public string QuestionText { get; set; }
        public QuestionType Type { get; set; }
    }
}
