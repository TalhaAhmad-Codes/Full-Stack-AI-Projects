using StudentManagement.Models;

namespace StudentManagement.Interfaces;

public interface IFileService
{
   void SaveToFile(string fileName, List<Student> students);
   List<Student> LoadFromFile(string fileName);
   //void ExportReport();
}
