using StudentManagement.Interfaces;
using StudentManagement.Utilities;
using StudentManagement.Utilities.Helpers;

namespace StudentManagement.Services
{
    public sealed class StudentOperations : IStudentOperations
    {
        private readonly StudentService _service;

        public StudentOperations(string fileName)
        {
            _service = new(fileName);
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

        private string? TakeNullableInputString(string prompt)
        {
            Console.Write($"{prompt} (leave blank to skip): ");
            var input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? null : input.Trim();
        }

        private int? TakeNullableInputInt(string prompt)
        {
            var input = TakeNullableInputString(prompt);
            return int.TryParse(input, out int parsedInput) ? parsedInput : null;
        }

        private double? TakeNullableInputDouble(string prompt)
        {
            var input = TakeNullableInputString(prompt);
            return double.TryParse(input, out double parsedInput) ? parsedInput : null;
        }

        private bool? TakeNullableInputBoolean(string prompt)
        {
            var input = TakeNullableInputString(prompt);
            return bool.TryParse(input, out bool parsedInput) ? parsedInput : null;
        }

        public void AddStudent()
        {
            Console.Clear();
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
            }
            finally
            {
                Misc.Hold();
            }
        }

        public void GetAllStudents()
        {
            Console.Clear();
            Message.Title("All Students");

            var students = _service.GetAllStudents();
            students.DisplayAll();
            Misc.Hold();
        }

        public void GetAverageGPA()
        {
            Console.Clear();
            Message.Title("Average GPA of All Students");

            var gpa = _service.CalculateAverageGPA();
            Message.Info($"The average GPA is {gpa}");
            Misc.Hold();
        }

        public void GetFilteredStudents()
        {
            Console.Clear();
            Message.Title("Filter all Students");

            var name = TakeNullableInputString("Enter name");
            var minAge = TakeNullableInputInt("Enter minimum age");
            var maxAge = TakeNullableInputInt("Enter maximum age");
            var minGPA = TakeNullableInputDouble("Enter minimum GPA");
            var maxGPA = TakeNullableInputDouble("Enter maximum GPA");
            var department = TakeNullableInputString("Enter department");
            var isActive = TakeNullableInputBoolean("Enter activation status (0-False, 1-True)");

            var students = _service.FilterStudents(
                name,
                minAge,
                maxAge,
                minGPA,
                maxGPA,
                department,
                isActive
            );
            students.DisplayAll();
            Misc.Hold();
        }

        public void GetTopStudents()
        {
            Console.Clear();
            Message.Title("Top Students");

            var count = Convert.ToInt32(TakeInput("Enter total number of students (>= 1)"));
            var students = _service.GetTopStudents(count);
            students.DisplayAll();
            Misc.Hold();
        }

        public void RemoveStudent()
        {
            Console.Clear();
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
            finally
            {
                Misc.Hold();
            }
        }

        public void UpdateStudent()
        {
            Console.Clear();
            Message.Title("Update Student");

            try
            {
                var id = Convert.ToInt32(TakeInput("Enter student id"));
                var name = TakeNullableInputString("Enter name");
                var email = TakeNullableInputString("Enter email");
                var age = TakeNullableInputInt("Enter age");
                var department = TakeNullableInputString("Enter department");
                var gpa = TakeNullableInputDouble("Enter GPA");
                var isActive = TakeNullableInputBoolean("Enter activation status (0-False, 1-True)");

                _service.UpdateStudent(id, name, age, email, department, gpa, isActive);
                Message.Success("Student has been updated");
            }
            catch (Exception ex)
            {
                Message.Error(ex.Message);
            }
            finally
            {
                Misc.Hold();
            }
        }
    }
}
