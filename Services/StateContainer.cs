using Task10.Models;

namespace Task10.Services
{
    public class StateContainer
    {
        private readonly List<StudentDto> _observedStudents = new();

        public IReadOnlyList<StudentDto> ObservedStudents => _observedStudents;

        public event Action? OnChange;

        public void AddObserved(StudentDto student)
        {
            if (!_observedStudents.Any(s => s.Id == student.Id))
            {
                _observedStudents.Add(student);
                NotifyStateChanged();
            }
        }

        public void RemoveObserved(int id)
        {
            var student = _observedStudents.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _observedStudents.Remove(student);
                NotifyStateChanged();
            }
        }

        public bool IsObserved(int id) => _observedStudents.Any(s => s.Id == id);

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}