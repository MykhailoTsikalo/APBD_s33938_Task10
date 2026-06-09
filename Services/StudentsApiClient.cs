using System.Net.Http.Json;
using Task10.Models;

namespace Task10.Services
{
    public class StudentsApiClient
    {
        private readonly HttpClient _http;

        public StudentsApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<StudentDto>> GetStudentsAsync() =>
            await _http.GetFromJsonAsync<List<StudentDto>>("api/students") ?? new();

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var response = await _http.GetAsync($"api/students/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<StudentDto>()
                ?? throw new InvalidOperationException("Payload processing sequence parsing failure.");
        }

        public async Task<StudentDto> CreateStudentAsync(StudentDto student)
        {
            var response = await _http.PostAsJsonAsync("api/students", student);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<StudentDto>()
                ?? throw new InvalidOperationException("Payload processing sequence parsing failure.");
        }

        public async Task<List<CourseDto>> GetCoursesAsync() =>
            await _http.GetFromJsonAsync<List<CourseDto>>("api/courses") ?? new();

        public async Task AssignCourseAsync(int studentId, int courseId)
        {
            var payload = new StudentCourseDto { StudentId = studentId, CourseId = courseId };
            var response = await _http.PostAsJsonAsync($"api/students/{studentId}/courses", payload);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<StudentCourseDto>> GetStudentCoursesAsync(int studentId) =>
            await _http.GetFromJsonAsync<List<StudentCourseDto>>($"api/students/{studentId}/courses") ?? new();
    }
}