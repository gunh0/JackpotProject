using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CrackMe_CTF_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string passw0rd = "1234";
            PWEncryption(textBox2.Text);
            if ((textBox1.Text == "Adm1n") && textBox2.Text == passw0rd)
            {
                MessageBox.Show("하아아아아아아아아위위이이이이이이이?!?!!!", "Success!!!");
            }
            else
            {
                MessageBox.Show("바위이이이...", "Fail...");
            }
            textBox2.Text = "";
        }

        private void PWEncryption(string pw)
        {
            string realPW = "";
            if (pw.Length == 4)
            {
                realPW += textBox2.Text.Substring(3,1);
                realPW += textBox2.Text.Substring(2, 1);
                realPW += textBox2.Text.Substring(1, 1);
                realPW += textBox2.Text.Substring(0, 1);
                textBox2.Text = realPW;
            }
        }
    }
}
