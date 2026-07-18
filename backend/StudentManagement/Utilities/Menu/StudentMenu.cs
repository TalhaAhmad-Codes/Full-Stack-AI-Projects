namespace StudentManagement.Utilities.Menu;

public enum MenuSelection
{
    AddStudent = 1,
    RemoveStudent,
    UpdateStudent,
    ViewAllStudents,
    ViewFilteredStudents,
    GetTopStudents,
    GetAverageGPA,
    Exit,
}

public sealed class StudentMenu : BaseMenu<MenuSelection>
{
    public StudentMenu()
        : base(
            title: "Student Management",
            options:
            [
                "Add Student",
                "Remove Student",
                "Update Student",
                "View All Students",
                "View Filtered Students",
                "Get Top Students",
                "Get Average GPA",
                "Exit",
            ]
        ) { }

    protected override MenuSelection HandleSelection(int selectedOption)
    {
        return selectedOption switch
        {
            1 => MenuSelection.AddStudent,
            2 => MenuSelection.RemoveStudent,
            3 => MenuSelection.UpdateStudent,
            4 => MenuSelection.ViewAllStudents,
            5 => MenuSelection.ViewFilteredStudents,
            6 => MenuSelection.GetTopStudents,
            7 => MenuSelection.GetAverageGPA,
            8 => MenuSelection.Exit,
            _ => throw new Exception("Invalid Option"),
        };
    }
}
