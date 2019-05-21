using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace OpenMulti
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
            openFileDialog1.Multiselect = true;//允許選中多個文件
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判斷是否選中文件
            {
                string Content = string.Empty;
                foreach (string filename in openFileDialog1.FileNames)
                {
                    System.IO.StreamReader sr = new//建立流讀取器物件
                         System.IO.StreamReader(filename, Encoding.Default);
                    Content += sr.ReadToEnd();//讀取文件內容
                    sr.Close();//關閉流
                }
                textBox1.Text = Content;//顯示文件內容
            }
        }
    }
}