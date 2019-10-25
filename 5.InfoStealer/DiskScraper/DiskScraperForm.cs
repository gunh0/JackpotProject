using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HackingPOS.Scrapers.Common;

using System.IO;

namespace HackingPOS.Scrapers.DiskScraper
{
    public partial class DiskScraperForm : Form
    {
        IList<DriveInfo> driveList;
        
        IList<string> textExtensionList;
        IList<string> binExtensionList;

        List<SearchResult> searchResults;
        int fileCount;
        int TotalCardCount;
        int processedFilesCount;
        DateTime startDateTime = DateTime.Now;
        PANandTracksSearch searchLine;
        TextFileSearch searchTextFile;
        BinaryFileSearch searchBinFile;

        public DiskScraperForm()
        {
            InitializeComponent();

        }

        void UpdateCounter(string CounterName, string CounterValue)
        {
            if (CounterName == "TotalCardsFound")
            {
                labelVisa.Text = CounterValue;
            }
            else
            if (CounterName == "FileName")
            {
                labelName.Text = CounterValue;
            }
            Application.DoEvents();
        }



        private void buttonScan_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Preparing for scan...";
            labelProcessedFilesCount.Text = "0";
            labelVisa.Text = "0";
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            buttonViewLog.Enabled = false;
            fileCount = 0;
            TotalCardCount = 0;
            processedFilesCount = 0;
            startDateTime = DateTime.Now;
            progressBar1.Value = 0;

            searchLine = new PANandTracksSearch(checkBoxTracksOnly.Checked);
            searchTextFile = new TextFileSearch(searchLine);
            searchBinFile = new BinaryFileSearch(searchLine);

            searchResults = new List<SearchResult>();
            ScanInfo scanInfo = new ScanInfo();


            if (radioButtonAllDrives.Checked)
            {
                foreach (DriveInfo drive in driveList)
                {
                    DirectoryInfo startDirectory = drive.RootDirectory;
                    scanInfo.searchInfo = scanInfo.searchInfo + " " + drive.Name;
                    if (!RecursiveScan(startDirectory, true))
                        break;
                }
                scanInfo.searchInfo = "Scanned drives: " + scanInfo.searchInfo;
            }
            else
                if (radioButtonSingleDrive.Checked)
                {
                    DriveInfo drive = new DriveInfo(comboBoxDrives.Text);
                    DirectoryInfo startDirectory = drive.RootDirectory;
                    RecursiveScan(startDirectory, true);
                    scanInfo.searchInfo = "Scanned drive: " + comboBoxDrives.Text;
                }
                else
                {
                    DirectoryInfo startDirectory = new DirectoryInfo(textBoxDrives.Text);
                    RecursiveScan(startDirectory, true);
                    scanInfo.searchInfo = "Scanned folder: " + textBoxDrives.Text;
                }

            if (fileCount > 0)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = fileCount;
                progressBar1.Step = 1;
                labelStatus.Text = "Scanning...";

                if (radioButtonAllDrives.Checked)
                {
                    foreach (DriveInfo drive in driveList)
                    {
                        DirectoryInfo startDirectory = drive.RootDirectory;
                        if (!RecursiveScan(startDirectory, false))
                            break;
                    }
                }
                else
                    if (radioButtonSingleDrive.Checked)
                    {
                        DriveInfo drive = new DriveInfo(comboBoxDrives.Text);
                        DirectoryInfo startDirectory = drive.RootDirectory;
                        RecursiveScan(startDirectory, false);
                    }
                    else
                    {
                        DirectoryInfo startDirectory = new DirectoryInfo(textBoxDrives.Text);
                        RecursiveScan(startDirectory, false);
                    }

            }
            scanInfo.searchResults = searchResults;
            scanInfo.fileCount = fileCount;
            scanInfo.TotalCardCount = TotalCardCount;
            scanInfo.processedFilesCount = processedFilesCount;
            scanInfo.startDateTime = startDateTime;
            scanInfo.stopDateTime = DateTime.Now;
            scanInfo.scanDuration = labelTime.Text;

            Logger.GetLogger(LogType.DiskScraper).AddToLog(scanInfo);

            labelStatus.Text = "Finished";
            labelName.Text = "";
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
            buttonViewLog.Enabled = true;
        }

        bool RecursiveScan(DirectoryInfo Directory, bool CountOnly)
        {
            labelTime.Text = CalculateTimeElapsed(startDateTime);
            Application.DoEvents();
            if (!buttonStop.Enabled)
                return false;
            try
            {
                IEnumerable<DirectoryInfo> dirs = Directory.GetDirectories(); // EnumerateDirectories();

                foreach (DirectoryInfo dir in dirs)
                {
                    if (!RecursiveScan(dir, CountOnly))
                        return false;
                }

                IEnumerable<FileInfo> files = Directory.GetFiles(); // EnumerateFiles();

                foreach (FileInfo file in files)
                {
                    if (!ProcessFile(file, CountOnly))
                        return false;
                }

            }
            catch
            {
            }
            return true;
        }


        bool ProcessFile(FileInfo file, bool CountOnly)
        {
            try
            {
                if (!(textExtensionList.Contains(file.Extension) || binExtensionList.Contains(file.Extension)))
                    return true;

                if (CountOnly)
                    fileCount++;
                else
                    fileCount--;

                labelCount.Text = fileCount.ToString();
                labelTime.Text = CalculateTimeElapsed(startDateTime);
                if (!CountOnly)
                {
                    labelName.Text = file.FullName;
                }
                Application.DoEvents();

                if (CountOnly)
                    return true;

                progressBar1.PerformStep();

                if (!SearchInFile(file))
                    return false;

                labelProcessedFilesCount.Text = processedFilesCount.ToString();
                labelVisa.Text = TotalCardCount.ToString();
                Application.DoEvents();
                if (!buttonStop.Enabled)
                    return false;
            }
            catch
            {
            }
            return true;
        }

        bool SearchInFile(FileInfo file)
        {
            List<SearchResult> res = new List<SearchResult>();

            if (textExtensionList.Contains(file.Extension))
            {
                res = searchTextFile.Search(file.FullName);
                processedFilesCount++;
            }
            else
                if (binExtensionList.Contains(file.Extension))
                {
                    res = searchBinFile.Search(file.FullName);
                    processedFilesCount++;
                }

            if (res.Count > 0)
            {
                TotalCardCount += res.Count;
                foreach (SearchResult result in res)
                    searchResults.Add(result);
            }

            return true;
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            textExtensionList = new List<string>()
            {
	            ".txt", ".log", ".htm", ".html", ".xml"
	        };
            binExtensionList = new List<string>()
            {
	            ".dat"
	        };

            radioButtonAllDrives.Checked = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Interrupted";
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
        }

        string CalculateTimeElapsed(DateTime start)
        {
            string res = "";
            TimeSpan ts = DateTime.Now - start;

            if (ts.Hours == 1)
                res += string.Format("1 hour ");
            else
                if (ts.Hours > 1)
                    res += string.Format("{0} hours ", ts.Hours);
            
            if (ts.Minutes == 1)
                res += string.Format("1 minute ");
            else
                if (ts.Minutes > 1)
                    res += string.Format("{0} minutes ", ts.Minutes);
                
            if (ts.Seconds == 1)
                res += string.Format("1 second");
            else
                if (ts.Seconds > 1)
                    res += string.Format("{0} seconds", ts.Seconds);

            return res;
        }

        private void buttonViewLog_Click(object sender, EventArgs e)
        {
            Logger.GetLogger(LogType.DiskScraper).ShowLogFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void radioButtonAllDrives_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAllDrives.Checked)
            {
                comboBoxDrives.Visible = false;
                textBoxDrives.Visible = true;
                comboBoxDrives.Items.Clear();
                textBoxDrives.Text = "";
                buttonSelectFolder.Visible = false;

                driveList = new List<DriveInfo>();
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                string allDrivesString = ""; 
                foreach (DriveInfo drive in allDrives)
                {
                    try
                    {
                        if (drive.DriveType == DriveType.Fixed || drive.DriveType == DriveType.Removable)
                        {
                            allDrivesString = allDrivesString + ", " + drive.Name;
                            driveList.Add(drive);
                        }
                    }
                    catch { }
                }
                textBoxDrives.Text = allDrivesString;
            }
            else
                if (radioButtonSingleDrive.Checked)
                {
                    comboBoxDrives.Visible = true;
                    textBoxDrives.Visible = false;
                    comboBoxDrives.Items.Clear();
                    textBoxDrives.Text = "";
                    buttonSelectFolder.Visible = false;

                    driveList = new List<DriveInfo>();
                    DriveInfo[] allDrives = DriveInfo.GetDrives();
                    foreach (DriveInfo drive in allDrives)
                    {
                        try
                        {
                            if (drive.DriveType == DriveType.Fixed || drive.DriveType == DriveType.Removable)
                            {
                                comboBoxDrives.Items.Add(drive.Name);
                                driveList.Add(drive);
                            }
                        }
                        catch { }
                    }
                    comboBoxDrives.Text = comboBoxDrives.Items[0].ToString();

                }
                else
                    if (radioButtonFolder.Checked)
                    {
                        comboBoxDrives.Visible = false;
                        textBoxDrives.Visible = true;
                        comboBoxDrives.Items.Clear();
                        textBoxDrives.Text = "";
                        buttonSelectFolder.Visible = true;

                    }

        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxDrives.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
