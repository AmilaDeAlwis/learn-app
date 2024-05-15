﻿using backend.Enum;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class StudentInfo
    {
        public string Id { get; set; } // Unique identifier for the student info document
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        // Optional properties with toggles
        public bool IsPhoneVisible { get; set; }
        public string Phone { get; set; }
        public bool IsNationalityVisible { get; set; }
        public Nationality Nationality { get; set; }
        public bool IsRecidencyVisible { get; set; }
        public Recidency Recidency { get; set; }
        public bool IsIdNumberVisible { get; set; }
        public string IdNumber { get; set; }
        public bool IsDateOfBirthVisible { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsGenderVisible { get; set; }
        public Gender Gender { get; set; }
        
        // Reference to the Course ID
        public string CourseId { get; set; }
    }
}
