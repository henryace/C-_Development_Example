using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace RevolveJPG
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.jpg|*.jpg";								//設定圖片的類型
            openFileDialog1.ShowDialog();									//打開文件對話框
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);	//實例化Image類
            pictureBox1.Image = myImage;									//顯示打開的圖片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image myImage = pictureBox1.Image;								//實例化Image類
            myImage.RotateFlip(RotateFlipType.Rotate90FlipXY); 		//呼叫RotateFlip方法將JPG格式圖像進行旋轉
            pictureBox1.Image = myImage;									//顯示旋轉後的圖片
        }
    }
}