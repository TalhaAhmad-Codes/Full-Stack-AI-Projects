namespace StudentManagement.Models;

public sealed record Student(
    int Id,
    string Name,
    int Age,
    string Email,
    string Department,
    float GPA,
    bool IsActive,
    DateTime CreatedAt
);
