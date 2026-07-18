namespace StudentManagement.Interfaces
{
    public interface IStudentOperations
    {
        void AddStudent();
        void RemoveStudent();
        void UpdateStudent();
        void GetAllStudents();
        void GetFilteredStudents();
        void GetTopStudents();
        void GetAverageGPA();
    }
}