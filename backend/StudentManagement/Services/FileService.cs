using System.Globalization;
using CsvHelper;
using StudentManagement.Interfaces;
using StudentManagement.Models;
//using StudentManagement.Utilities;

namespace StudentManagement.Services;

public sealed class FileService : IFileService
{
    private readonly string _dataDirectory;

    public FileService()
    {
        // Path to bin/Debug/net10.0/Data
        _dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        
        // Ensure the directory exists to avoid DirectoryNotFoundException
        // Create the directory if it doesn't exist
        if (!Directory.Exists(_dataDirectory))
        {
            Directory.CreateDirectory(_dataDirectory);
        }
    }
    
    public void SaveToFile(string fileName, List<Student> students) // Only file name no extension
    {
        // Initialization
        string path = Path.Combine(_dataDirectory, $"{fileName}.csv");
        
        using StreamWriter writer = new(path);
        using CsvWriter csv = new(writer, CultureInfo.InvariantCulture);
        
        // Writing to the file
        csv.WriteRecords(students);
        
        //Message.Success($"Saved to '{path}'");
    }

    public List<Student> LoadFromFile(string fileName)
    {
        // Initialization
        string path = Path.Combine(_dataDirectory, $"{fileName}.csv");
        
        // If file doesn't exist
        if (!File.Exists(path))
        {
            //Message.Error($"The file at given path doesn't exist");            
            return []; // Return empty list if file doesn't exist yet
        }
        
        using StreamReader reader = new(path);
        using CsvReader csv = new(reader, CultureInfo.InvariantCulture);
        
        //Message.Info($"Reading form '{path}'");

        // Reading / Loading from the file
        var students = csv.GetRecords<Student>().ToList();
        //Message.Success($"Read all records from '{path}'");
        return students;
    }
}
