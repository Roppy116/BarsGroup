using System;
using System.IO;

namespace Logger
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex);
    }

    class LocalFileLogger<T> : ILogger
    {
        private string path;
        public LocalFileLogger(string path)
        {
            this.path = path;
        }

        public void LogInfo(string message)
        {
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine($"[Info]: [{typeof(T).Name}] : {message}");
            sw.Close();
        }

        public void LogWarning(string message)
        {
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine($"[Warning] : [{typeof(T).Name}] : {message}");
            sw.Close();
        }

        public void LogError(string message, Exception ex)
        {
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteAsync($"[Error] : [{typeof(T).Name}] : {message}. {ex.Message}");
            sw.Close();
        }
    
    }

    class Program
    {
        static void Main(string[] args)
        {
            LocalFileLogger<string> string_logger = new LocalFileLogger<string>("test123.txt");
            string_logger.LogInfo("Some string Information");
            string_logger.LogWarning("Some string Warning");
            string_logger.LogError("Some string Error", new Exception("ERROR!"));

            LocalFileLogger<int> int_logger = new LocalFileLogger<int>("test123.txt");
            int_logger.LogInfo("Some Int Information");
            int_logger.LogWarning("Some Int Warning");
            int_logger.LogError("Some Int Error", new Exception("ERROR!"));
        }
    }
}