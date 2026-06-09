using System.ComponentModel.DataAnnotations;

namespace Task10.Models
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Ects { get; set; }
    }
}
