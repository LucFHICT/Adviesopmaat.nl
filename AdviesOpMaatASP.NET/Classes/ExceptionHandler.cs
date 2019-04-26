using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace AdviesOpMaatASP.NET.Classes
{
    public static class ExceptionHandler
    {
        public static void WriteExceptionToFile(Exception ex)
        {
            const string filePath = "Exceptions\\Exceptions.txt";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(Convert.ToString(DateTime.Now) + ex);
            }
        }
    }
}
