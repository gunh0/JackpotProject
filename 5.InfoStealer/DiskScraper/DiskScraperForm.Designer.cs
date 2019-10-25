namespace HackingPOS.Scrapers.DiskScraper
{
    partial class DiskScraperForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelVisa = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelProcessedFilesCount = new System.Windows.Forms.Label();
            this.buttonViewLog = new System.Windows.Forms.Button();
            this.radioButtonAllDrives = new System.Windows.Forms.RadioButton();
            this.radioButtonSingleDrive = new System.Windows.Forms.RadioButton();
            this.radioButtonFolder = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.comboBoxDrives = new System.Windows.Forms.ComboBox();
            this.textBoxDrives = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBoxTracksOnly = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(40, 104);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(160, 208);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(13, 13);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "0";
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(163, 104);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(160, 230);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 13);
            this.labelName.TabIndex = 3;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(160, 252);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 13);
            this.labelTime.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(40, 149);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(693, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(160, 186);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Time Elapsed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Scanning Now";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Files to scan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cards Found";
            // 
            // labelVisa
            // 
            this.labelVisa.AutoSize = true;
            this.labelVisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVisa.Location = new System.Drawing.Point(160, 324);
            this.labelVisa.Name = "labelVisa";
            this.labelVisa.Size = new System.Drawing.Size(14, 13);
            this.labelVisa.TabIndex = 11;
            this.labelVisa.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Files Processed";
            // 
            // labelProcessedFilesCount
            // 
            this.labelProcessedFilesCount.AutoSize = true;
            this.labelProcessedFilesCount.Location = new System.Drawing.Point(160, 277);
            this.labelProcessedFilesCount.Name = "labelProcessedFilesCount";
            this.labelProcessedFilesCount.Size = new System.Drawing.Size(13, 13);
            this.labelProcessedFilesCount.TabIndex = 13;
            this.labelProcessedFilesCount.Text = "0";
            // 
            // buttonViewLog
            // 
            this.buttonViewLog.Enabled = false;
            this.buttonViewLog.Location = new System.Drawing.Point(41, 352);
            this.buttonViewLog.Name = "buttonViewLog";
            this.buttonViewLog.Size = new System.Drawing.Size(75, 23);
            this.buttonViewLog.TabIndex = 15;
            this.buttonViewLog.Text = "View Log";
            this.buttonViewLog.UseVisualStyleBackColor = true;
            this.buttonViewLog.Click += new System.EventHandler(this.buttonViewLog_Click);
            // 
            // radioButtonAllDrives
            // 
            this.radioButtonAllDrives.AutoSize = true;
            this.radioButtonAllDrives.Location = new System.Drawing.Point(12, 19);
            this.radioButtonAllDrives.Name = "radioButtonAllDrives";
            this.radioButtonAllDrives.Size = new System.Drawing.Size(67, 17);
            this.radioButtonAllDrives.TabIndex = 16;
            this.radioButtonAllDrives.Text = "All drives";
            this.radioButtonAllDrives.UseVisualStyleBackColor = true;
            this.radioButtonAllDrives.CheckedChanged += new System.EventHandler(this.radioButtonAllDrives_CheckedChanged);
            // 
            // radioButtonSingleDrive
            // 
            this.radioButtonSingleDrive.AutoSize = true;
            this.radioButtonSingleDrive.Location = new System.Drawing.Point(101, 19);
            this.radioButtonSingleDrive.Name = "radioButtonSingleDrive";
            this.radioButtonSingleDrive.Size = new System.Drawing.Size(82, 17);
            this.radioButtonSingleDrive.TabIndex = 17;
            this.radioButtonSingleDrive.Text = "Single Drive";
            this.radioButtonSingleDrive.UseVisualStyleBackColor = true;
            this.radioButtonSingleDrive.CheckedChanged += new System.EventHandler(this.radioButtonAllDrives_CheckedChanged);
            // 
            // radioButtonFolder
            // 
            this.radioButtonFolder.AutoSize = true;
            this.radioButtonFolder.Location = new System.Drawing.Point(199, 19);
            this.radioButtonFolder.Name = "radioButtonFolder";
            this.radioButtonFolder.Size = new System.Drawing.Size(54, 17);
            this.radioButtonFolder.TabIndex = 18;
            this.radioButtonFolder.Text = "Folder";
            this.radioButtonFolder.UseVisualStyleBackColor = true;
            this.radioButtonFolder.CheckedChanged += new System.EventHandler(this.radioButtonAllDrives_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSelectFolder);
            this.groupBox1.Controls.Add(this.comboBoxDrives);
            this.groupBox1.Controls.Add(this.radioButtonAllDrives);
            this.groupBox1.Controls.Add(this.radioButtonFolder);
            this.groupBox1.Controls.Add(this.radioButtonSingleDrive);
            this.groupBox1.Controls.Add(this.textBoxDrives);
            this.groupBox1.Location = new System.Drawing.Point(40, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(693, 75);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select object to scan";
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(602, 43);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFolder.TabIndex = 21;
            this.buttonSelectFolder.Text = "Select";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.FormattingEnabled = true;
            this.comboBoxDrives.Location = new System.Drawing.Point(12, 43);
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(241, 21);
            this.comboBoxDrives.TabIndex = 19;
            // 
            // textBoxDrives
            // 
            this.textBoxDrives.Location = new System.Drawing.Point(12, 43);
            this.textBoxDrives.Name = "textBoxDrives";
            this.textBoxDrives.Size = new System.Drawing.Size(574, 20);
            this.textBoxDrives.TabIndex = 20;
            // 
            // checkBoxTracksOnly
            // 
            this.checkBoxTracksOnly.AutoSize = true;
            this.checkBoxTracksOnly.Checked = true;
            this.checkBoxTracksOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTracksOnly.Location = new System.Drawing.Point(479, 108);
            this.checkBoxTracksOnly.Name = "checkBoxTracksOnly";
            this.checkBoxTracksOnly.Size = new System.Drawing.Size(254, 17);
            this.checkBoxTracksOnly.TabIndex = 20;
            this.checkBoxTracksOnly.Text = "Search tracks 1 and 2 only (no standalone PAN)";
            this.checkBoxTracksOnly.UseVisualStyleBackColor = true;
            // 
            // DiskScraperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 388);
            this.Controls.Add(this.checkBoxTracksOnly);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonViewLog);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelProcessedFilesCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelVisa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.buttonStart);
            this.Name = "DiskScraperForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiskScraper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelVisa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelProcessedFilesCount;
        private System.Windows.Forms.Button buttonViewLog;
        private System.Windows.Forms.RadioButton radioButtonAllDrives;
        private System.Windows.Forms.RadioButton radioButtonSingleDrive;
        private System.Windows.Forms.RadioButton radioButtonFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxDrives;
        private System.Windows.Forms.TextBox textBoxDrives;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox checkBoxTracksOnly;
    }
}

