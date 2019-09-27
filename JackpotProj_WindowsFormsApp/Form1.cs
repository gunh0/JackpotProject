using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JackpotProj_WindowsFormsApp
{ 
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        int input_data = 1111;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send(input_data.ToString());
            SendKeys.Send("{ENTER}");
            input_data += 1;
        }
    }
}
