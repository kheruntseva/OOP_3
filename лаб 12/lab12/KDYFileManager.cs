using System;
using System.IO;
using System.IO.Compression;

namespace lab12
{
    static class logger
    {
        private static string logFilePath = "kdylogfile.txt";

        public static void writelog(string action, string target, string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true)) // Append mode
            {
                writer.WriteLine($"[{DateTime.Now}] Действие: {action}");
                writer.WriteLine($"Цель: {target}");
                writer.WriteLine($"Сообщение: {message}");
                writer.WriteLine(new string('-', 40));
            }
        }
        public static void SetLogFilePath(string path)
        {
            logFilePath = path;
        }
    }


    class KDYFileManager
    {
        public static void InspectDrive(string drivePath, string logFilePath)
        {
            if (!Directory.Exists(drivePath))
            {
                logger.writelog("Ошибка", drivePath, $"Директория {drivePath} не существует.");
                return;
            }

            string inspectDir = "XXXInspect";
            string dirInfoFile = Path.Combine(inspectDir, "kdydirinfo.txt");

            Directory.CreateDirectory(inspectDir);

            using (StreamWriter writer = new StreamWriter(dirInfoFile))
            {
                writer.WriteLine("Список файлов:");
                foreach (var file in Directory.GetFiles(drivePath))
                {
                    writer.WriteLine(file);
                }

                writer.WriteLine("\nСписок папок:");
                foreach (var dir in Directory.GetDirectories(drivePath))
                {
                    writer.WriteLine(dir);
                }
            }

            string copiedFile = Path.Combine(inspectDir, "kdydirinfo_copy.txt");
            File.Copy(dirInfoFile, copiedFile);
            File.Delete(dirInfoFile);

            logger.writelog("Анализ диска", drivePath, $"Информация записана в {copiedFile}.");
        }

        public static void CopyFilesByExtension(string sourceDir, string extension, string logFilePath)
        {
            if (!Directory.Exists(sourceDir))
            {
                logger.writelog("Ошибка", sourceDir, $"Директория {sourceDir} не существует.");
                return;
            }

            string filesDir = "XXXFiles";
            Directory.CreateDirectory(filesDir);

            foreach (var file in Directory.GetFiles(sourceDir, $"*.{extension}"))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(filesDir, fileName);
                File.Copy(file, destFile, true);
            }

            string inspectDir = "XXXInspect";
            if (!Directory.Exists(inspectDir))
            {
                Directory.CreateDirectory(inspectDir);
            }

            string destDir = Path.Combine(inspectDir, filesDir);
            if (Directory.Exists(destDir))
            {
                Directory.Delete(destDir, true);
            }

            Directory.Move(filesDir, destDir);
            logger.writelog("Копирование файлов", sourceDir, $"Файлы с расширением {extension} перемещены в {destDir}.");
        }

        public static void ArchiveAndExtract(string sourceDir, string archiveName, string extractDir, string logFilePath)
        {
            if (!Directory.Exists(sourceDir))
            {
                logger.writelog("Ошибка", sourceDir, $"Директория {sourceDir} не существует.");
                return;
            }

            string archivePath = $"{archiveName}.zip";

            ZipFile.CreateFromDirectory(sourceDir, archivePath);
            logger.writelog("Архивация", sourceDir, $"Директория заархивирована в {archivePath}.");

            if (Directory.Exists(extractDir))
            {
                Directory.Delete(extractDir, true);
            }

            ZipFile.ExtractToDirectory(archivePath, extractDir);
            logger.writelog("Распаковка", archivePath, $"Архив разархивирован в {extractDir}.");
        }
    }
}
