using System.Text.RegularExpressions;

namespace StudentManagement.Utilities.Helpers;

internal static class RegexHelper
{
    /* <----- Regex Patters -----> */
    private static readonly Regex EmailRegexHelper = new(
        @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", 
        RegexOptions.IgnoreCase | RegexOptions.Compiled
    );
    
    public static bool IsValidEmail(string email)
    {
        return !string.IsNullOrWhiteSpace(email) && EmailRegexHelper.IsMatch(email);
    }
}