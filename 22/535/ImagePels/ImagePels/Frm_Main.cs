using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace ImagePels
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //設定文件的類型
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp,*.gif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.ShowDialog(); //打開文件對話框
            textBox1.Text = openFileDialog1.FileName;//顯示選擇圖片的路徑
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName); //根據文件的路徑實例化Image類
            label2.Text = "圖片像素：[" + myImage.Width + "*" + myImage.Height + "]";//取得圖片的大小
        }
    }
}