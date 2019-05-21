using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace MaxMinImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        Image myImage;
        private void button1_Click(object sender, EventArgs e)
        {
            //設定文件的類型
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp,*.gif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.ShowDialog();								//打開文件對話框
            myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);	//實例化myImage類
            pictureBox1.Image = myImage;								//顯示圖片
            pictureBox1.Height = myImage.Height;							//設定pictureBox1的高度
            pictureBox1.Width = myImage.Width; 							//設定pictureBox1的寬度
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Height = Convert.ToInt32(myImage.Height * Convert.ToSingle(textBox1.Text.Trim()));//設定高度
                pictureBox1.Width = Convert.ToInt32(myImage.Width * Convert.ToSingle(textBox1.Text.Trim()));//設定寬度
            }
            catch { }
        }
    }
}