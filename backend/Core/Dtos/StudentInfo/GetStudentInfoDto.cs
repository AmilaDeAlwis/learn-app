using backend.Core.Enum;
using Newtonsoft.Json;

namespace backend.Core.Dtos.StudentInfo
{
    // StudentInfo model encapsulation
    public class GetStudentInfoDto
    {
        [JsonProperty("id")]
        public string Id { get; set; } // Unique identifier
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
