using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace FileEqual
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox2.Text = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader sr1 = new StreamReader(textBox1.Text);			//建立StreamReader物件
            StreamReader sr2 = new StreamReader(textBox2.Text); 			//建立StreamReader物件
            if (object.Equals(sr1.ReadToEnd(), sr2.ReadToEnd()))			//讀取文件內容並判斷
            {
                MessageBox.Show("兩個檔案相等");
            }
            else
            {
                MessageBox.Show("兩個檔案不相等");
            }
        }
    }
}