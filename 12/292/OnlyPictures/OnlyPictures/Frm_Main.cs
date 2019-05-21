using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace OnlyPictures
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.jpg|*.jpg|*.bmp|*.bmp";//設定篩選字串
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//彈出打開檔案對話框
            {
                pictureBox1.Image = //顯示圖像
                    Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}