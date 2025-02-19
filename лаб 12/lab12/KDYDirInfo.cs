using System;
using System.IO;

namespace lab12
{
    class KDYDirInfo
    {
        public static string GetFileCount(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                int fileCount = Directory.GetFiles(dirPath).Length;
                return $"Количество файлов: {fileCount}";
            }
            else
            {
                return $"Директория {dirPath} не существует.";
            }
        }

        public static string GetCreationTime(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                DateTime creationTime = Directory.GetCreationTime(dirPath);
                return $"Время создания: {creationTime}";
            }
            else
            {
                return $"Директория {dirPath} не существует.";
            }
        }

        public static string GetSubdirectoryCount(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                int dirCount = Directory.GetDirectories(dirPath).Length;
                return $"Количество поддиректориев: {dirCount}";
            }
            else
            {
                return $"Директория {dirPath} не существует.";
            }
        }

        public static string GetParentDirectories(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                string result = "Родительские директории:";
                while (dirInfo.Parent != null)
                {
                    result += $"\n  {dirInfo.Parent.FullName}";
                    dirInfo = dirInfo.Parent;
                }
                return result;
            }
            else
            {
                return $"Директория {dirPath} не существует.";
            }
        }
    }
}
