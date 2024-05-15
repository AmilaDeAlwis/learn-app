using System.ComponentModel.DataAnnotations;

namespace backend.Core.Dtos.Course
{
    public class CreateCourseDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Title length can't be more than 100 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Description length can't be more than 500 characters.")]
        public string Description { get; set; }
    }
}
