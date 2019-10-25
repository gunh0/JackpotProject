using System;
using System.Collections.Generic;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackingPOS.Scrapers.MemoryScraper
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MemoryScraperForm());
        }
    }
}
