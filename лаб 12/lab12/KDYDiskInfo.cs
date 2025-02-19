using System;
using System.IO;

public class KDYDiskInfo
{
    public static string GetFreeSpace(string driveName)
    {
        DriveInfo drive = new DriveInfo(driveName);
        if (drive.IsReady)
        {
            return $"\nДиск {drive.Name}\n  Свободное место: {drive.TotalFreeSpace / (1024 * 1024)} МБ";
        }
        else
        {
            return $"\nДиск {driveName} не готов.";
        }
    }

    public static string GetFileSystemInfo(string driveName)
    {
        DriveInfo drive = new DriveInfo(driveName);
        if (drive.IsReady)
        {
            return $"\nДиск {drive.Name}\n  Файловая система: {drive.DriveFormat}";
        }
        else
        {
            return $"\nДиск {driveName} не готов.";
        }
    }

    public static string GetAllDrivesInfo()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        string result = "";

        foreach (var drive in drives)
        {
            if (drive.IsReady)
            {
                result += $"\nДиск {drive.Name}\n" +
                          $"  Объем: {drive.TotalSize / (1024 * 1024)} МБ\n" +
                          $"  Доступный объем: {drive.AvailableFreeSpace / (1024 * 1024)} МБ\n" +
                          $"  Метка тома: {drive.VolumeLabel}\n" +
                          $"  Файловая система: {drive.DriveFormat}\n";
            }
            else
            {
                result += $"\nДиск {drive.Name} не готов.";
            }
        }
        return result;
    }
}
