using System.ComponentModel.DataAnnotations;

namespace Task10.Models
{
    public class StudentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Index number field constraint required.")]
        public string IndexNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "First name property requires input assignment.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name registration requirement unmet.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email contact address is required.")]
        [EmailAddress(ErrorMessage = "Target string structural layout must match explicit email pattern formats.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Target academic track semester classification required.")]
        [Range(1, 8, ErrorMessage = "Semester designations strictly restricted within bounds 1 through 8.")]
        public int? Semester { get; set; }
    }
}