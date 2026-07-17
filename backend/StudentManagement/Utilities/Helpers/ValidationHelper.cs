namespace StudentManagement.Utilities.Helpers;

public static class ValidationHelper
{
    public static bool IsValidEmail(string email)
    {
        return RegexHelper.IsValidEmail(email);
    }

    public static bool IsValidGPA(float gpa)
    {
        var newGPA = (int) gpa * 100;
        return newGPA is >= 100 and <= 400;
    }
    
    //bool ValidateStudent(this Student student, );
}
