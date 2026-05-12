using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Pantry_To_Plate.mods
{
    public class AppLogger
    {
        private string LogFilePath = "app_log.txt";

        public AppLogger(string logFilePath)
        {
            LogFilePath = logFilePath;
        }

        public void Log(string message)
        {
            Write($"INFORMATION: {message}");
        }
        public void LogError(string message)
        {
            Write($"ERROR: {message}");
        }
        public void LogWarning(string message)
        {
            Write($"WARNING: {message}");
        }

        public void Write(string message)
        {
            string logEntry = ($"{DateTime.Now}: {message}");
            File.AppendAllText(LogFilePath, logEntry + "\n");
        }
        
    }
}
