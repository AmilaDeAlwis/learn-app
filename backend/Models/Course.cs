using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Course
    {
        public string Id { get; set; } // Unique identifier for the course document
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        // Navigation property for related StudentInfo entries
        public ICollection<StudentInfo> StudentInfos { get; set; }
        // Navigation property for related CustomQuestions entries
        public ICollection<CustomQuestion> CustomQuestions { get; set; }
    }
}
