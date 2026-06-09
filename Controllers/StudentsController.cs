using Microsoft.AspNetCore.Mvc;
using Task10.Models;
using Task10.Services;

namespace Task10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly MockDatabase _db;

    public StudentsController(MockDatabase db)
    {
        _db = db;
    }

    // GET: api/students
    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok(_db.Students);
    }

    // GET: api/students/{id}
    [HttpGet("{id:int}")]
    public IActionResult GetStudent(int id)
    {
        var student = _db.Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound(new { message = "Student not found" });
        }
        return Ok(student);
    }

    // POST: api/students
    [HttpPost]
    public IActionResult CreateStudent([FromBody] StudentDto student)
    {
        student.Id = _db.Students.Count > 0 ? _db.Students.Max(s => s.Id) + 1 : 1;

        _db.Students.Add(student);

        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    // GET: api/courses
    [HttpGet("/api/courses")]
    public IActionResult GetCourses()
    {
        return Ok(_db.Courses);
    }

    // POST: api/students/{id}/courses
    [HttpPost("{id:int}/courses")]
    public IActionResult AssignCourse(int id, [FromBody] StudentCourseDto assignment)
    {
        var studentExists = _db.Students.Any(s => s.Id == id);
        var courseExists = _db.Courses.Any(c => c.Id == assignment.CourseId);

        if (!studentExists || !courseExists)
        {
            return BadRequest("Invalid Student ID or Course ID.");
        }

        assignment.StudentId = id;
        _db.StudentCourses.Add(assignment);

        return Ok(assignment);
    }
}