using System;
using System.IO;

namespace lab12
{
    class KDYFileInfo
    {
        public static string GetFullPath(string filePath)
        {
            if (File.Exists(filePath))
            {
                return $"Полный путь: {Path.GetFullPath(filePath)}";
            }
            else
            {
                return $"Файл {filePath} не существует.";
            }
        }

        public static string GetFileDetails(string filePath)
        {
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                return $"Имя файла: {fileInfo.Name}\n" +
                       $"Размер файла: {fileInfo.Length / 1024.0:F2} КБ\n" +
                       $"Расширение файла: {fileInfo.Extension}";
            }
            else
            {
                return $"Файл {filePath} не существует.";
            }
        }

        public static string GetFileDates(string filePath)
        {
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                return $"Дата создания: {fileInfo.CreationTime}\n" +
                       $"Дата последнего изменения: {fileInfo.LastWriteTime}";
            }
            else
            {
                return $"Файл {filePath} не существует.";
            }
        }
    }
}
