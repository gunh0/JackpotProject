using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using HackingPOS.Scrapers.Common;

namespace HackingPOS.Scrapers.DiskScraper
{
    public class BinaryFileSearch
    {
        private static readonly int CHUNK_SIZE = 4096;

        PANandTracksSearch searchLine;

        public BinaryFileSearch(PANandTracksSearch SearchLine)
        {
            searchLine = SearchLine;
        }


        public List<SearchResult> Search(string fName)
        {
            List<SearchResult> res = new List<SearchResult>();
            try
            {
                using (FileStream fs = new FileStream(fName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (BinaryReader br = new BinaryReader(fs, new ASCIIEncoding()))
                    {
                        byte[] chunk;
                        int position = 0;

                        chunk = br.ReadBytes(CHUNK_SIZE);
                        while (chunk.Length > 0)
                        {
                            string ASCIItext = Encoding.ASCII.GetString(chunk);
                            string Unicodetext = Encoding.Unicode.GetString(chunk);
                            searchLine.Search(ASCIItext, position.ToString(), fName, ref res);
                            searchLine.Search(Unicodetext, position.ToString(), fName, ref res);
                            chunk = br.ReadBytes(CHUNK_SIZE);
                            position += CHUNK_SIZE;
                        }
                    }
                }

            }
            catch 
            {

            }
            return res;
        }
    }
}