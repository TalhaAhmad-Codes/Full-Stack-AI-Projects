
---

# Project 1 — Advanced Student Management Console App

---

# Problem Statement

Build a console-based student management system where an admin can:

* Add students
* Update student data
* Delete students
* Search students
* Filter students
* Calculate statistics
* Save/load data from files

The application should use clean OOP principles and modern C# syntax.

---

# Concepts Covered

This project mainly strengthens:

* Classes & Records
* Collections
* LINQ
* Exception Handling
* File Handling
* Generics
* Extension Methods
* Pattern Matching
* Nullable Types
* Clean Code
* SOLID basics

---

# Suggested Features

## Basic Features

* Add student
* View all students
* Update student
* Delete student
* Search by name

## Intermediate Features

* Filter by grade
* Sort by GPA
* Top performers
* Average GPA calculation
* Save to JSON/text file
* Load from file

## Optional Features

* Pagination
* Export report
* Undo delete
* Student activity logs

---

# Suggested Folder Structure

```text
StudentManagementApp/
│
├── Models/
├── Services/
├── Utilities/
├── Data/
├── Interfaces/
└── Program.cs
```

---

# Suggested Classes

## Student Class / Record

Properties:

```text
Id
Name
Age
Email
Department
GPA
IsActive
CreatedAt
```

Think:

* Should this be class or record?
* Which fields should be mutable?

---

## StudentService

Responsible for business logic.

Methods:

```text
AddStudent()
UpdateStudent()
DeleteStudent()
GetAllStudents()
SearchStudents()
FilterStudents()
GetTopStudents()
CalculateAverageGPA()
```

---

## FileService

Handles persistence.

Methods:

```text
SaveToFile()
LoadFromFile()
ExportReport()
```

Use:

* File.ReadAllTextAsync()
* File.WriteAllTextAsync()

---

## ValidationHelper

Methods:

```text
IsValidEmail()
IsValidGPA()
ValidateStudent()
```

Good place for:

* extension methods
* reusable validation

---

## MenuManager

Handles UI navigation.

Methods:

```text
ShowMenu()
HandleChoice()
DisplayStudents()
```

---

# Functional Flow

```text
Program Starts
    ↓
Show Menu
    ↓
User Selects Option
    ↓
Service Layer Executes Logic
    ↓
Data Updates
    ↓
Optional File Save
    ↓
Return to Menu
```

---

# LINQ Practice Ideas

You MUST heavily use LINQ here.

Examples:

* top 3 students
* students grouped by department
* average GPA
* inactive students
* alphabetical sorting

Examples you should implement yourself:

```text
Where
Select
OrderBy
GroupBy
Any
All
Average
Max
Min
FirstOrDefault
```

---

# Important Design Thinking

Instead of:

```text
Everything inside Program.cs
```

Do:

```text
Separate responsibilities
```

This project teaches architecture basics.

---

# What You Should Learn

After this project:

* managing collections
* writing reusable methods
* designing classes
* LINQ thinking
* clean structure
* basic persistence

---
