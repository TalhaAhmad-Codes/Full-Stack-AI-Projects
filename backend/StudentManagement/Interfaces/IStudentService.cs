using StudentManagement.Models;

namespace StudentManagement.Interfaces;

public interface IStudentService
{
    void AddStudent(string name, int age, string email, string department, double gpa);
    void UpdateStudent(int id, string name, int aAge, string email, string department, double gpa, bool isActive);
    void DeleteStudent(int id);
    List<Student> GetAllStudents();
    List<Student> SearchStudents(string name);
    List<Student> FilterStudents(int? minAge, int? maxAge, double? minGPA, double? maxGPA, string? department);
    List<Student> GetTopStudents(int count = 1);
    double CalculateAverageGPA();
}
