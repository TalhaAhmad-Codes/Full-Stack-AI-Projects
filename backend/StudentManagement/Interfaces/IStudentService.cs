using StudentManagement.Models;

namespace StudentManagement.Interfaces;

public interface IStudentService
{
    void AddStudent(string name, int age, string email, string department, float gpa);
    bool UpdateStudent(int id, string name, int aAge, string email, string department, float gpa);
    bool DeleteStudent(int id);
    List<Student> GetAllStudents();
    List<Student> SearchStudents(string name);
    List<Student> FilterStudents(int? minAge, int? maxAge, string? department);
    List<Student> GetTopStudents(int count = 1);
    float CalculateAverageGPA();
}
