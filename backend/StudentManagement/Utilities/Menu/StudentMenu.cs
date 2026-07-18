using StudentManagement.Utilities.Menu;

namespace StudentManagement.Utilities.Menu;

public sealed class StudentMenu : BaseMenu
{
    public StudentMenu()
        : base("Student Management", new[] { "Add Student", "View Students", "Exit" })
    {
    }

    protected override void HandleSelection(int selectedOption)
    {
        switch (selectedOption)
        {
            case 1:
                Console.WriteLine("Add Student selected.");
                break;
            case 2:
                Console.WriteLine("View Students selected.");
                break;
            case 3:
                Console.WriteLine("Exiting menu.");
                break;
        }
    }
}
