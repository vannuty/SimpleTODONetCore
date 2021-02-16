using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TODOLib.Handlers
{
    public class FileHandler
    {
        public static void WriteToFile(string FileName, string Text)
        {
            string DirectoryPath = Directory.GetCurrentDirectory();
            string FilePath = DirectoryPath + "\\" + FileName;

            File.WriteAllText(FilePath, Text);
        }

        public static string ReadFromFile(string FileName)
        {
            string DirectoryPath = Directory.GetCurrentDirectory();
            string FilePath = DirectoryPath + "\\" + FileName;
            if (File.Exists(FilePath))
            {
                return File.ReadAllText(FilePath);
            }
            return "";
        }
    }
}
