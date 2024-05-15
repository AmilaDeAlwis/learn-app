﻿using System.ComponentModel.DataAnnotations;

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

        // Include a list of StudentInfo IDs for referencing
        public List<string> StudentInfoIds { get; set; }
        // Include a list of CustomQuestion IDs for referencing
        public List<string> CustomQuestionIds { get; set; }
    }
}
