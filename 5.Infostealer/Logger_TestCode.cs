using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Diagnostics;

namespace HackingPOS.Scrapers.Common
{
    public class ScanInfo
    {
        //public IList<DriveInfo> driveList;
        public List<SearchResult> searchResults;
        public string searchInfo;
        public int fileCount;
        public int PANCount;
        public int Track1Count;
        public int Track2Count;
        public int TotalCardCount;
        public int processedFilesCount;
        public DateTime startDateTime;
        public DateTime stopDateTime;
        public string scanDuration;
    }

    public enum LogType { MemoryScraper, NetScraper, DiskScraper };

    public class Logger_TestCode
    {
        private static Logger_TestCode logger;

        public static Logger_TestCode GetLogger(LogType logType)
        {
            if (logger == null)
            {
                logger = new Logger_TestCode(logType);
            }
            return logger;
        }

        private string logName;

        private LogType logType;

        private Logger_TestCode(LogType logType)
        {
            this.logType = logType;
        }

        public void AddToLog(ScanInfo scanInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Host: " + Environment.MachineName);
            sb.AppendLine(scanInfo.searchInfo);

            if (logType == LogType.DiskScraper)
                sb.AppendLine("Files Scanned: " + scanInfo.processedFilesCount.ToString());
            else
                if (logType == LogType.MemoryScraper)
                sb.AppendLine("Pages Scanned: " + scanInfo.processedFilesCount.ToString());
            else
                sb.AppendLine("Packets Scanned: " + scanInfo.processedFilesCount.ToString());

            sb.AppendLine("Scan Duration: " + scanInfo.scanDuration);
            sb.AppendLine("Scan Started: " + scanInfo.startDateTime.ToString());
            sb.AppendLine("Scan Finished: " + scanInfo.stopDateTime.ToString());
            sb.AppendLine("Total Cards Found: " + scanInfo.TotalCardCount.ToString());
            sb.AppendLine("");

            foreach (SearchResult entry in scanInfo.searchResults)
                AddSearchResult(entry, ref sb);

            logName = Environment.CurrentDirectory + @"\" + logType.ToString() + "_" + DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss") + ".log";
            using (StreamWriter outfile = new StreamWriter(logName))
            {
                outfile.Write(sb.ToString());
            }
        }

        private void AddSearchResult(SearchResult entry, ref StringBuilder sb)
        {
            string label;
            if (entry.ResultType == ResultTypes.PAN)
                label = "PAN: ";
            else
                if (entry.ResultType == ResultTypes.Track1)
                label = "Track 1: ";
            else
                label = "Track 2: ";

            if (logType == LogType.DiskScraper)
            {
                sb.AppendLine(label + entry.Value + " found in line: " + entry.ElementInfo + " at position: " + entry.Position.ToString());
                sb.AppendLine("in file: " + entry.FileName);
            }
            else
                if (logType == LogType.MemoryScraper)
            {
                sb.AppendLine(label + entry.Value + " found in page: " + entry.ElementInfo + " at position: " + entry.Position.ToString());
            }
            else
                    if (logType == LogType.NetScraper)
            {
                sb.AppendLine(label + entry.Value + " found in packet: " + entry.ElementInfo + " at position: " + entry.Position.ToString());
            }
        }

        public void ShowLogFile()
        {
            try
            {
                Process.Start(@"notepad.exe", logName);
            }
            catch
            {
            }
        }
    }
}
