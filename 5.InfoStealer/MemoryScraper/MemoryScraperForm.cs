using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using HackingPOS.Scrapers.Common;

namespace HackingPOS.Scrapers.MemoryScraper
{
    public partial class MemoryScraperForm : Form
    {
        public MemoryScraperForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxAddresses.SelectedIndex > -1)
            {
                labelStatus.Text = "Scanning Memory...";
                labelCount.Text = "";
                buttonScan.Enabled = false;
                buttonLog.Enabled = false;

                Application.DoEvents();

                MemoryScanner scanner = new MemoryScanner();
                int cardsFound = scanner.ScanMemory(Process.GetProcessesByName(comboBoxAddresses.SelectedItem.ToString())[0]);

                labelStatus.Text = "Finished Scanning";
                labelCount.Text = "Cards found: " + cardsFound.ToString();

                buttonScan.Enabled = true;
                buttonLog.Enabled = true;
            }

        }

        private void PopulateProcessList()
        {
            comboBoxAddresses.Items.Clear();
            Process[] processList = Process.GetProcesses();
            foreach (Process process in processList)
                comboBoxAddresses.Items.Add(process.ProcessName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelStatus.Text = "";
            labelCount.Text = "";
            PopulateProcessList();
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            Logger.GetLogger(LogType.MemoryScraper).ShowLogFile();
        }

    }
}
