namespace backend.Dtos.Course
{
    public class GetCourseDto
    {
        public string Id { get; set; } // Unique identifier for the course document
        public string Title { get; set; }
        public string Description { get; set; }
        // List of StudentInfo IDs to show which students are enrolled
        public List<string> StudentInfoIds { get; set; }
        // List of CustomQuestion IDs to show what custom questions are included
        public List<string> CustomQuestionIds { get; set; }
    }
}
