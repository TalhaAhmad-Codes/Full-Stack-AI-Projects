using StudentManagement.Models;

namespace StudentManagement.Utilities.Helpers;

public static class StudentExtensions
{
    public static void Display(this Student student)
    {
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine($"Id:         {student.Id}");
        Console.WriteLine($"Name:       {student.Name}");
        Console.WriteLine($"Department: {student.Department}");
        Console.WriteLine($"GPA:        {student.GPA}");
        Console.WriteLine($"Email:      {student.Email}");
        Console.WriteLine($"Active:     {student.IsActive}");
        Console.WriteLine($"Created At: {student.CreatedAt}");
    }

    public static void DisplayAll(this List<Student> students)
    {
        if (students.Count > 0)
        {
            foreach (var student in students)
            {
                student.Display();
            }
        }
        else
        {
            Message.Info("No students founde");
        }
    }
}
