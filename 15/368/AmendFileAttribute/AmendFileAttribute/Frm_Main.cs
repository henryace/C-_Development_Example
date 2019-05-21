using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace AmendFileAttribute
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.FileInfo f = new System.IO.FileInfo(textBox1.Text);			//實例化FileInfo類
            if (checkBox1.Checked == true)									//如果只讀複選框選中
            {
                f.Attributes = System.IO.FileAttributes.ReadOnly; 				//設定文件為只讀
            }
            if (checkBox2.Checked == true) 								//如果系統複選框選中
            {
                f.Attributes = System.IO.FileAttributes.System; 					//設定文件為系統
            }
            if (checkBox3.Checked == true) 								//如果存檔複選框選中
            {
                f.Attributes = System.IO.FileAttributes.Archive; 					//設定文件為存檔
            }
            if (checkBox4.Checked == true) 								//如果隱藏複選框選中
            {
                f.Attributes = System.IO.FileAttributes.Hidden; 					//設定文件為隱藏
            }
        }
    }
}