using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServiceCSharp.Tools
{
    public class FileT
    {
        public const string NameLog = "log";
        public const string ExtensionLog = ".txt";

        public static void SaveLog(string message, string logFilePath = NameLog)
        {
            try
            {
                string executableDirectory = AppDomain.CurrentDomain.BaseDirectory;

                Directory.CreateDirectory(executableDirectory);

                string logFile = Path.Combine(executableDirectory, logFilePath + ExtensionLog);

                using (StreamWriter writer = new StreamWriter(logFile, true))
                {
                    writer.WriteLine($"{DateTime.Now.ToString(ConstT.formatDateyyyyMMddHHmmssFormat)} - {message}");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
