namespace StudentManagement.Utilities
{
    public static class Message
    {
        public static void Info(string message) => Console.WriteLine($"[INFO] {message}");

        public static void Success(string message) => Console.WriteLine($"[SUCCESS] {message}");

        public static void Warning(string message) => Console.WriteLine($"[WARNING] {message}");

        public static void Error(string message) => Console.WriteLine($"[ERROR] {message}");

        public static void Title(string title)
        {
            Console.WriteLine("=================================");
            Console.WriteLine(title.ToUpper());
            Console.WriteLine("=================================\n");
        }
    }
}
