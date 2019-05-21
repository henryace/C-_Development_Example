using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GetShortPathName
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        [DllImport("Kernel32.dll")]//宣告API函數
        private static extern Int16 GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, Int16 cchBuffer);

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFDialog = new OpenFileDialog();//建立OpenFileDialog物件
            if (OFDialog.ShowDialog() == DialogResult.OK)//判讀是否選擇了文件
            {
                textBox1.Text = OFDialog.FileName;//顯示選擇的文件名
                string longName = textBox1.Text;//記錄選擇的文件名
                StringBuilder shortName = new System.Text.StringBuilder(256);//建立StringBuilder物件
                GetShortPathName(longName, shortName, 256);//呼叫API函數轉換成短文件名
                string myInfo = "長文件名：" + longName;//顯示長文件名
                myInfo += "\n短文件名：" + shortName;//顯示短文件名
                label2.Text = myInfo;
            }
        }
    }
}