using StudentManagement.Services;
using StudentManagement.Utilities.Helpers;
using StudentManagement.Utilities.Menu;

StudentService service = new();

try
{
    service.AddStudent("Talha Ahmad", 20, "talha.code92@gmail.com", "Computer Science", 3.03);
    service.AddStudent("Aslam Akbar", 21, "aslam@gmail.com", "Commerce", 2.98);

    var students = service.GetAllStudents();

    foreach (var student in students)
    {
        student.Display();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine();
Console.WriteLine("Press Enter to launch the sample menu...");
Console.ReadLine();

var menu = new StudentMenu();
menu.Show();

/*

[OUTPUT]

-----------------------------------------------------------
Id:         1
Name:       Talha Ahmad
Department: Computer Science
GPA:        3.03
Email:      talha.code92@gmail.com
Active:     True
Created At: 7/17/2026 4:09:23 PM
-----------------------------------------------------------
Id:         2
Name:       Aslam Akbar
Department: Commerce
GPA:        2.98
Email:      aslam@gmail.com
Active:     True
Created At: 7/17/2026 4:09:23 PM

*/
