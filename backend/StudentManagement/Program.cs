using StudentManagement.Services;
using StudentManagement.Utilities.Menu;

void Start()
{
    var menu = new StudentMenu();
    var operation = new StudentOperations();
    MenuSelection option;

    do
    {
        option = menu.Start();

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
                continue;
        }
    } while (option != MenuSelection.Exit);
}

Start();
