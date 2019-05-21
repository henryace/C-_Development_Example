using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace OpenFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt文件(*.txt)|*.txt";//篩選文件
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//彈出打開文件對話框
            {
                System.IO.StreamReader sr = new//建立文件讀取器物件
                   System.IO.StreamReader(openFileDialog1.FileName, Encoding.Default);
                textBox1.Text = sr.ReadToEnd();//顯示文字文件內容
                sr.Close();//關閉流
            }
        }
    }
}