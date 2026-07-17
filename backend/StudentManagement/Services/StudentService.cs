using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.Utilities.Helpers;

namespace StudentManagement.Services;

public sealed class StudentService : IStudentService
{
    List<Student> _students;
    IQueryable<Student> _query => _students.AsQueryable();
    static int count = 0;
    
    public void AddStudent(string name, int age, string email, string department, float gpa)
    {
        // Validation Checks
        var isValidEmail = ValidationHelper.IsValidEmail(email);
        if (!isValidEmail)
            throw new Exception("Given email is invalid.");

        var existsByEmail = _query.Any(s => s.Email == email);
        if (existsByEmail)
            throw new Exception("Student of given email is already registered.");

        var isValidGPA = ValidationHelper.IsValidGPA(gpa);
        if (!isValidGPA)
            throw new Exception("GPA is not valid. It must be in between 1.0 and 4.0 inclusive.");

        // Adding student record
        Student student = new(++count, name, age, email, department, gpa, true, DateTime.Now);
        _students.Add(student);
    }

    public bool UpdateStudent(int id, string name, int age, string email, string department, float gpa)
    {
        var student = _query.FirstOrDefault(s => s.Id == id);
        
    }

    public bool DeleteStudent(int id)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetAllStudents()
    {
        throw new NotImplementedException();
    }

    public List<Student> SearchStudents(string name)
    {
        throw new NotImplementedException();
    }

    public List<Student> FilterStudents(int? minAge, int? maxAge, string? department)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetTopStudents(int count = 1)
    {
        throw new NotImplementedException();
    }

    public float CalculateAverageGPA()
    {
        throw new NotImplementedException();
    }
}