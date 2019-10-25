namespace HackingPOS.Scrapers.NetScraper
{
    partial class NetScraperForm
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
            this.Addresses = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCardsFound = new System.Windows.Forms.Label();
            this.labelPacketCounter = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLog = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelLastPacket = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStart.Location = new System.Drawing.Point(15, 78);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(80, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "&Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Addresses
            // 
            this.Addresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Addresses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Addresses.FormattingEnabled = true;
            this.Addresses.Location = new System.Drawing.Point(15, 35);
            this.Addresses.Name = "Addresses";
            this.Addresses.Size = new System.Drawing.Size(280, 21);
            this.Addresses.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cards Found: ";
            // 
            // labelCardsFound
            // 
            this.labelCardsFound.AutoSize = true;
            this.labelCardsFound.Location = new System.Drawing.Point(138, 185);
            this.labelCardsFound.Name = "labelCardsFound";
            this.labelCardsFound.Size = new System.Drawing.Size(13, 13);
            this.labelCardsFound.TabIndex = 4;
            this.labelCardsFound.Text = "0";
            // 
            // labelPacketCounter
            // 
            this.labelPacketCounter.AutoSize = true;
            this.labelPacketCounter.Location = new System.Drawing.Point(138, 137);
            this.labelPacketCounter.Name = "labelPacketCounter";
            this.labelPacketCounter.Size = new System.Drawing.Size(13, 13);
            this.labelPacketCounter.TabIndex = 6;
            this.labelPacketCounter.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TCP Packets scanned:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select IP address to scan:";
            // 
            // buttonLog
            // 
            this.buttonLog.Enabled = false;
            this.buttonLog.Location = new System.Drawing.Point(18, 225);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Size = new System.Drawing.Size(75, 23);
            this.buttonLog.TabIndex = 8;
            this.buttonLog.Text = "View Log";
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Last packet scanned:";
            // 
            // labelLastPacket
            // 
            this.labelLastPacket.AutoSize = true;
            this.labelLastPacket.Location = new System.Drawing.Point(138, 160);
            this.labelLastPacket.Name = "labelLastPacket";
            this.labelLastPacket.Size = new System.Drawing.Size(33, 13);
            this.labelLastPacket.TabIndex = 10;
            this.labelLastPacket.Text = "None";
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(141, 78);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(80, 23);
            this.buttonStop.TabIndex = 11;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // NetScraperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 315);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.labelLastPacket);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelPacketCounter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelCardsFound);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Addresses);
            this.Controls.Add(this.buttonStart);
            this.Name = "NetScraperForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetScraper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetScraperForm_FormClosing);
            this.Load += new System.EventHandler(this.NetScraperForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ComboBox Addresses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCardsFound;
        private System.Windows.Forms.Label labelPacketCounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelLastPacket;
        private System.Windows.Forms.Button buttonStop;
    }
}

