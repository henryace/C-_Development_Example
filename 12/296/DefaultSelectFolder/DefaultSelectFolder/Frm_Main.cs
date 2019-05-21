using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DefaultSelectFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = @"D:\";//設定選定的路徑
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)//確定是否已經選擇資料夾
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;//顯示資料夾路徑
            }
        }
    }
}