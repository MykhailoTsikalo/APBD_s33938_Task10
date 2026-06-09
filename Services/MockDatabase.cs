using Task10.Models;

namespace Task10.Services;

public class MockDatabase
{
    public List<StudentDto> Students { get; set; } = new()
    {
        new StudentDto { Id = 1, FirstName = "John", LastName = "Doe" },
        new StudentDto { Id = 2, FirstName = "Jane", LastName = "Smith" }
    };

    public List<CourseDto> Courses { get; set; } = new()
    {
        new CourseDto { Id = 1, Name = "Mathematics" },
        new CourseDto { Id = 2, Name = "Computer Science" },
        new CourseDto { Id = 3, Name = "Physics" }
    };

    public List<StudentCourseDto> StudentCourses { get; set; } = new();
}