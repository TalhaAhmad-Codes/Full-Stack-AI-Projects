using StudentManagement.Services;
using StudentManagement.Utilities;
using StudentManagement.Utilities.Menu;

string GetFileName()
{
    string fileName;

    do
    {
        Console.Write("Enter file name you want to work on: ");
        fileName = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            Message.Error("Enter a valid file name");
        }
    } while (string.IsNullOrWhiteSpace(fileName));

    return fileName;
}

void Start()
{
    // Start the program
    var menu = new StudentMenu();
    var operation = new StudentOperations(GetFileName());

    do
    {
        Console.Clear();
        MenuSelection option = menu.Start();

        switch (option)
        {
            case MenuSelection.AddStudent:
                operation.AddStudent();
                break;

            case MenuSelection.RemoveStudent:
                operation.RemoveStudent();
                break;

            case MenuSelection.UpdateStudent:
                operation.UpdateStudent();
                break;

            case MenuSelection.ViewAllStudents:
                operation.GetAllStudents();
                break;

            case MenuSelection.ViewFilteredStudents:
                operation.GetFilteredStudents();
                break;

            case MenuSelection.GetTopStudents:
                operation.GetTopStudents();
                break;

            case MenuSelection.GetAverageGPA:
                operation.GetAverageGPA();
                break;

            default:
                Message.Title("Thanks for using Student Management Applicaiton");
                Environment.Exit(0);
                break;
        }
    } while (true);
}

Start();

/*List<Student> students = [
    new(1, "Talha Ahmad", 20, "talha.code92@gmail.com", "Computer Science", 3.03, true, DateTime.Now),
    new(2, "Ahmad Aslam", 19, "ahmad21@gmail.com", "Arts", 3.13, false, DateTime.Now),
    new(3, "Muneeb Butt", 21, "muneebbutt2@gmail.com", "Commerce", 2.80, true, DateTime.Now),
];

FileService service = new();
//service.SaveToFile("sample-1", students);
var students = service.LoadFromFile("sample-1");
students.DisplayAll();
*/
