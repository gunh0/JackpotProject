using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using HackingPOS.Scrapers.Common;

namespace HackingPOS.Scrapers.DiskScraper
{
    public class TextFileSearch
    {
        PANandTracksSearch searchLine;

        public TextFileSearch(PANandTracksSearch searchLine)
        {
            this.searchLine = searchLine;
        }

        public List<SearchResult> Search(string fName)
        {
            List<SearchResult> res = new List<SearchResult>();
            try
            {
                StreamReader sr = new StreamReader(fName);
                try
                {
                    string input;
                    int LineNumber = 0;
                    while (sr.Peek() >= 0)
                    {
                        input = sr.ReadLine();
                        LineNumber++;
                        searchLine.Search(input, LineNumber.ToString(), fName, ref res);
                    }
                }
                finally
                {
                    sr.Close();
                }

            }
            catch
            {
            }
            return res;
        }
    }
}
