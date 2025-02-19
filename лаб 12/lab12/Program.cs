using System;
using System.IO;
using System.Linq;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            string logFilePath = "kdylogfile.txt";
            KDYLog logger = new KDYLog(logFilePath);

            while (true)
            {
                Console.WriteLine("Выберите действие:(1-3 LOG, 4-6 DISK, 7-FILE, 8-DIR, 9-MANAGER");
                Console.WriteLine("1. Записать действие");
                Console.WriteLine("2. Прочитать лог");
                Console.WriteLine("3. Найти записи по ключевому слову");
                Console.WriteLine("4. Показать свободное место на диске");
                Console.WriteLine("5. Показать файловую систему диска");
                Console.WriteLine("6. Показать информацию о всех дисках");
                Console.WriteLine("7. Показать информацию о файле");
                Console.WriteLine("8. Показать информацию о директории");
                Console.WriteLine("10. Выйти");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите действие: ");
                        string action = Console.ReadLine();

                        Console.Write("Введите имя файла: ");
                        string fileName = Console.ReadLine();

                        Console.Write("Введите путь к файлу: ");
                        string filePath = Console.ReadLine();

                        logger.writelog(action, fileName, filePath);
                        Console.WriteLine("Действие записано в лог.");
                        break;

                    case "2":
                        Console.WriteLine("Содержимое лог-файла:");
                        Console.WriteLine(logger.ReadLogs());
                        break;

                    case "3":
                        Console.Write("Введите ключевое слово для поиска: ");
                        string keyword = Console.ReadLine();

                        string searchResults = logger.searchlog(keyword);
                        Console.WriteLine("Результаты поиска:");
                        Console.WriteLine(string.IsNullOrEmpty(searchResults) ? "Ничего не найдено." : searchResults);
                        break;

                    case "4":
                        Console.Write("Введите имя диска (например, C): ");
                        string driveName1 = Console.ReadLine();
                        string freeSpace = KDYDiskInfo.GetFreeSpace(driveName1);
                        logger.writelog("Проверка свободного места", driveName1, freeSpace);
                        break;

                    case "5":
                        Console.Write("Введите имя диска (например, C): ");
                        string driveName2 = Console.ReadLine();
                        string fileSystemInfo = KDYDiskInfo.GetFileSystemInfo(driveName2);
                        logger.writelog("Проверка файловой системы", driveName2, fileSystemInfo);
                        break;

                    case "6":
                        string allDrivesInfo = KDYDiskInfo.GetAllDrivesInfo();
                        logger.writelog("Просмотр информации о всех дисках", "", allDrivesInfo);
                        break;

                    case "7":
                        Console.WriteLine("Введите путь к файлу для анализа:");
                        string filePath2 = Console.ReadLine();
                        string fullPathInfo = KDYFileInfo.GetFullPath(filePath2);
                        string fileDetails = KDYFileInfo.GetFileDetails(filePath2);
                        string fileDates = KDYFileInfo.GetFileDates(filePath2);
                        logger.writelog("Анализ файла", filePath2, $"{fullPathInfo}\n{fileDetails}\n{fileDates}");
                        break;


                    case "8":
                        Console.WriteLine("Введите путь к директории для анализа:");
                        string dirPath = Console.ReadLine();
                        string fileCountInfo = KDYDirInfo.GetFileCount(dirPath);
                        string creationTimeInfo = KDYDirInfo.GetCreationTime(dirPath);
                        string subdirectoryCountInfo = KDYDirInfo.GetSubdirectoryCount(dirPath);
                        string parentDirectoriesInfo = KDYDirInfo.GetParentDirectories(dirPath);
                        logger.writelog("Анализ директории", dirPath,
                            $"{fileCountInfo}\n{creationTimeInfo}\n{subdirectoryCountInfo}\n{parentDirectoriesInfo}");
                        break;

                    case "9":
                        Console.WriteLine("Введите путь к диску или директории для анализа:");
                        string drivePath = Console.ReadLine();
                        KDYFileManager.InspectDrive(drivePath, "kdylogfile.txt");
                        Console.WriteLine("\nВведите путь к директории для копирования файлов:");
                        string sourceDir = Console.ReadLine();
                        Console.WriteLine("Введите расширение файлов (например, txt):");
                        string extension = Console.ReadLine();
                        KDYFileManager.CopyFilesByExtension(sourceDir, extension, "xxxlogfile.txt");
                        string archiveName = "XXXFilesArchive";
                        string extractDir = "ExtractedFiles";
                        KDYFileManager.ArchiveAndExtract("XXXInspect\\XXXFiles", archiveName, extractDir, "xxxlogfile.txt");
                        break;


                    case "10":
                        Console.WriteLine("Выход из программы.");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
