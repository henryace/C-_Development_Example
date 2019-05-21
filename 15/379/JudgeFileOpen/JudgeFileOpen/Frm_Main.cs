using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace JudgeFileOpen
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;							//沒有被選中
            checkBox2.Checked = true;							//被選中
            openFileDialog1.ShowDialog();						//打開文件對話框
            try
            {
                System.IO.File.Move(openFileDialog1.FileName, openFileDialog1.FileName);		//移動文件
            }
            catch								//如果移動文件產生異常則說明文件被打開
            {
                checkBox2.Checked = false;					//沒有被選中
                checkBox1.Checked = true; 					//被選中
            }
        }
    }
}