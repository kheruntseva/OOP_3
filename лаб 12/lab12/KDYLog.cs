using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace lab12
{
    class KDYLog
    {
        public string LogPath;

        public KDYLog(string path)
        {
            LogPath = path;
            if (!File.Exists(LogPath))
            {
                File.Create(LogPath).Dispose();
            }
        }

        public void writelog(string action, string name, string path)
        {
            string logEntry = $"[{DateTime.Now}] Action: {action}, FileName: {name}, FilePath: {path}";
            File.AppendAllText(path, logEntry + Environment.NewLine);
        }

        public string ReadLogs()
        {
            return File.ReadAllText(LogPath);
        }

        public string searchlog(string word)
        {
            var logs = File.ReadAllLines(LogPath);
            var filteredLogs = logs.Where(log => log.Contains(word));
            return string.Join(Environment.NewLine, filteredLogs);
        }

        public string SearchLogs(string word)
        {
            var logs = File.ReadAllLines(LogPath);
            var filteredLogs = logs.Where(log => log.Contains(word));
            return string.Join(Environment.NewLine, filteredLogs);
        }

        public string SearchLogsByDate(DateTime date)
        {
            var logs = File.ReadAllLines(LogPath);
            var filteredLogs = logs.Where(log => log.Contains(date.ToString("yyyy-MM-dd")));
            return string.Join(Environment.NewLine, filteredLogs);
        }
        public string SearchLogsByTimeRange(DateTime startTime, DateTime endTime)
        {
            var logs = File.ReadAllLines(LogPath);
            var filteredLogs = logs.Where(log =>
            {
                DateTime logTime = ExtractLogTime(log);
                return logTime >= startTime && logTime <= endTime;
            });
            return string.Join(Environment.NewLine, filteredLogs);
        }

        public int GetLogCount()
        {
            return File.ReadAllLines(LogPath).Length;
        }

        public void RetainLogsForCurrentHour()
        {
            var logs = File.ReadAllLines(LogPath);
            var currentHour = DateTime.Now.Hour;
            var currentDate = DateTime.Now.Date;

            var filteredLogs = logs.Where(log =>
            {
                DateTime logTime = ExtractLogTime(log);
                return logTime.Hour == currentHour && logTime.Date == currentDate;
            }).ToList();


            File.WriteAllLines(LogPath, filteredLogs);
        }

        private DateTime ExtractLogTime(string log)
        {
            var timeString = log.Split(']')[0].TrimStart('[');
            return DateTime.Parse(timeString);
        }




    }
}
