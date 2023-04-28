using System;
using System.IO;
using System.Text;

namespace Common.FileManagement
{
    public class FileManagement
    {
        public static string[] GetListOfFiles(string folderPath, string searchPattern = "", SearchOption searchOption = SearchOption.AllDirectories)
        {
            return Directory.GetFiles(folderPath);
        }
        public static void CreateFile(string folderPath, string fileName, string content)
        {
            string filePath = $"{folderPath}\\{fileName}";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (FileStream fs = File.Create(filePath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(content);
                fs.Write(info, 0, info.Length);
            }
        }
        public static void RenameFile(string oldFileName, string newFileName)
        {
            if (!File.Exists(newFileName))
            {
                File.Move(oldFileName, newFileName);
            }
        }
    }
}
