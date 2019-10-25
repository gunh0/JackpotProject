// Memory Scraper - Copyright (c) 2013 Slava Gomzin

namespace HackingPOS.Scrapers.MemoryScraper
{
    partial class MemoryScraperForm
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
            this.buttonScan = new System.Windows.Forms.Button();
            this.comboBoxAddresses = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLog = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(25, 87);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(75, 23);
            this.buttonScan.TabIndex = 0;
            this.buttonScan.Text = "Start";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxAddresses
            // 
            this.comboBoxAddresses.FormattingEnabled = true;
            this.comboBoxAddresses.Location = new System.Drawing.Point(25, 50);
            this.comboBoxAddresses.Name = "comboBoxAddresses";
            this.comboBoxAddresses.Size = new System.Drawing.Size(233, 21);
            this.comboBoxAddresses.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Process to Scan";
            // 
            // buttonLog
            // 
            this.buttonLog.Enabled = false;
            this.buttonLog.Location = new System.Drawing.Point(25, 187);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Size = new System.Drawing.Size(75, 23);
            this.buttonLog.TabIndex = 3;
            this.buttonLog.Text = "View Log";
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(22, 129);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(59, 13);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "labelStatus";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(22, 157);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(57, 13);
            this.labelCount.TabIndex = 5;
            this.labelCount.Text = "labelCount";
            // 
            // MemoryScraperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 234);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAddresses);
            this.Controls.Add(this.buttonScan);
            this.Name = "MemoryScraperForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MemoryScraper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.ComboBox comboBoxAddresses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelCount;
    }
}

