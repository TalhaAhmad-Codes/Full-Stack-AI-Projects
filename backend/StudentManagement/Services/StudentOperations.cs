using StudentManagement.Interfaces;
using StudentManagement.Utilities;
using StudentManagement.Utilities.Helpers;

namespace StudentManagement.Services
{
    public sealed class StudentOperations : IStudentOperations
    {
        private readonly StudentService _service;

        public StudentOperations()
        {
            _service = new();
        }

        public StudentOperations(StudentService service)
        {
            _service = service;
        }

        private string TakeInput(string prompt)
        {
            Console.Write($"{prompt}: ");
            return Console.ReadLine()!.Trim();
        }

        private string? TakeNullableInput(string prompt)
        {
            Console.Write($"{prompt} (leave blank to skip): ");
            var input = Console.ReadLine()!.Trim();
            return input.Count() == 0 ? null : input;
        }

        public void AddStudent()
        {
            Message.Title("Add Student");

            try
            {
                var name = TakeInput("Enter name");
                var email = TakeInput("Enter email");
                var age = Convert.ToInt32(TakeInput("Enter age"));
                var department = TakeInput("Enter department");
                var gpa = Convert.ToDouble(TakeInput("Enter GPA"));

                _service.AddStudent(name, age, email, department, gpa);
                Message.Success("Student has been added");
            }
            catch (Exception ex)
            {
                Message.Error(ex.Message);
                Misc.Hold();
            }
        }

        public void GetAllStudents()
        {
            Message.Title("All Students");
            var students = _service.GetAllStudents();
            students.DisplayAll();
            Misc.Hold();
            // if (students.Count > 0)
            // {
            //     foreach (var student in students)
            //     {
            //         student.Display();
            //     }
            // }
            // else
            // {
            //     Message.Info("No students found");
            //     Misc.Hold();
            // }
        }

        public void GetAverageGPA()
        {
            Message.Title("Average GPA of All Students");

            var gpa = _service.CalculateAverageGPA();
            Message.Info($"The average GPA is {gpa}");
        }

        public void GetFilteredStudents()
        {
            Message.Title("Filter all Students");

            var name = TakeNullableInput("Enter name");
            var minAge = Convert.ToInt32(TakeNullableInput("Enter minimum age"));
            var maxAge = Convert.ToInt32(TakeNullableInput("Enter maximum age"));
            var minGPA = Convert.ToDouble(TakeNullableInput("Enter minimum GPA"));
            var maxGPA = Convert.ToDouble(TakeNullableInput("Enter maximum GPA"));
            var department = TakeNullableInput("Enter department");

            var students = _service.FilterStudents(
                name,
                minAge,
                maxAge,
                minGPA,
                maxGPA,
                department
            );
            students.DisplayAll();
            Misc.Hold();
        }

        public void GetTopStudents()
        {
            Message.Title("Top Students");

            var count = Convert.ToInt32(TakeInput("Enter total number of students (>= 1)"));
            var students = _service.GetTopStudents(count);
            students.DisplayAll();
            Misc.Hold();
        }

        public void RemoveStudent()
        {
            Message.Title("Remove Student");

            var studentId = Convert.ToInt32(TakeInput("Enter student id"));

            try
            {
                _service.DeleteStudent(studentId);
                Message.Success("Student has beed removed");
            }
            catch (Exception ex)
            {
                Message.Error(ex.Message);
            }
        }

        public void UpdateStudent()
        {
            Message.Title("Update Student");

            try
            {
                var id = Convert.ToInt32(TakeNullableInput("Enter student id"));
                var name = TakeNullableInput("Enter name");
                var email = TakeNullableInput("Enter email");
                var age = Convert.ToInt32(TakeNullableInput("Enter age"));
                var department = TakeNullableInput("Enter department");
                var gpa = Convert.ToDouble(TakeNullableInput("Enter GPA"));
                var isActive = Convert.ToBoolean(TakeNullableInput("Enter activation status"));

                _service.UpdateStudent(id, name, age, email, department, gpa, isActive);
                Message.Success("Student has been updated");
            }
            catch (Exception ex)
            {
                Message.Error(ex.Message);
                Misc.Hold();
            }
        }
    }
}
