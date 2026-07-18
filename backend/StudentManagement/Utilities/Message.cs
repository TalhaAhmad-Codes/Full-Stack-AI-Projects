using System.Text;

namespace StudentManagement.Utilities
{
    public static class Message
    {
        public static void Info(string message) => Console.WriteLine($"\n[INFO] {message}\n");

        public static void Success(string message) => Console.WriteLine($"\n[SUCCESS] {message}\n");

        public static void Warning(string message) => Console.WriteLine($"\n[WARNING] {message}\n");

        public static void Error(string message) => Console.WriteLine($"\n[ERROR] {message}\n");

        public static void Title(string title)
        {
            int gap = 4;
            var gapStr = new string(' ', gap);
            var bar = new string('=', title.Length + (gap * 2));

            Console.WriteLine(bar);
            Console.WriteLine(gapStr + title + gapStr);
            Console.WriteLine(bar);
        }
    }
}
