using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.Utilities.Helpers;

namespace StudentManagement.Services;

public sealed class StudentService : IStudentService
{
    List<Student> _students = [];
    IQueryable<Student> _query => _students.AsQueryable();
    static int count = 0;

    private void AgainstInvalidEmail(string email)
    {
        var isValidEmail = ValidationHelper.IsValidEmail(email.Trim());
        if (!isValidEmail)
            throw new Exception("Given email is invalid.");
    }

    private void AgainstInvalidGPA(double gpa)
    {
        var isValidGPA = ValidationHelper.IsValidGPA(gpa);
        if (!isValidGPA)
            throw new Exception("GPA is not valid. It must be in between 1.0 and 4.0 inclusive.");
    }

    private void AgainstAlreadyRegisteredEmail(string email)
    {
        var existsByEmail = _query.Any(s => s.Email == email.Trim());
        if (existsByEmail)
            throw new Exception("Student of given email is already registered.");
    }
    
    public void AddStudent(string name, int age, string email, string department, double gpa)
    {
        // Validation Checks
        AgainstInvalidEmail(email);
        AgainstInvalidGPA(gpa);
        AgainstAlreadyRegisteredEmail(email);

        // Adding student record
        Student student = new(++count, name.Trim(), age, email.Trim(), department.Trim(), gpa, true, DateTime.Now);
        _students.Add(student);
    }

    public void UpdateStudent(int id, string name, int age, string email, string department, double gpa, bool isActive)
    {
        var student = _query.FirstOrDefault(s => s.Id == id) ??
                      throw new Exception("Student of given id not found.");
        
        // Validation Checks
        AgainstInvalidEmail(email);
        AgainstInvalidGPA(gpa);
        AgainstAlreadyRegisteredEmail(email);

        // Updating the student
        Student newStudent = new(id, name.Trim(), age, email.Trim(), department.Trim(), gpa, isActive, student.CreatedAt);
        _students.Remove(student);
        _students.Add(newStudent);
    }

    public void DeleteStudent(int id)
    {
        var student = _query.FirstOrDefault(s => s.Id == id) ??
                      throw new Exception("Student of given id not found.");

        _students.Remove(student);
    }

    public List<Student> GetAllStudents()
    {
        return _students;
    }

    public List<Student> SearchStudents(string name)
    {
        return _query
            .Where(s => s.Name.ToLower() == name.Trim().ToLower())
            .ToList();
    }

    public List<Student> FilterStudents(int? minAge, int? maxAge, double? minGPA, double? maxGPA, string? department)
    {
        var query = _query;

        if (minAge.HasValue)
            query = query.Where(s => s.Age >= minAge);

        if (maxAge.HasValue)
            query = query.Where(s => s.Age <= maxAge);

        if (minGPA.HasValue)
            query = query.Where(s => (int) s.GPA * 100 >= (int) minGPA * 100);
        
        if (maxGPA.HasValue)
            query = query.Where(s => (int) s.GPA * 100 <= (int) maxGPA * 100);

        if (department is not null)
            query = query.Where(s => s.Department.ToLower() == department.Trim().ToLower());

        return query.ToList();
    }

    public List<Student> GetTopStudents(int count = 1)
    {
        if (count < 1)
            throw new Exception("You can only select at least 1 student");
        
        return _query
            .OrderByDescending(s => s.GPA)
            .Take(count)
            .ToList();
    }

    public double CalculateAverageGPA()
    {
        return _students.Count > 0 ? _query
            .Average(s => s.GPA) : 0.0;
    }
}
