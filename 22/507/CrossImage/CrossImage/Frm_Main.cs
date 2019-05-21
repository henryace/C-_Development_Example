using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace CrossImage
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
            openFileDialog1.ShowDialog();									//打開文件對話框
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);	//根據文件的路徑實例化Image類
            pictureBox1.Image = myImage;									//顯示打開的圖片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image myImage = pictureBox1.Image;//實例化Image
            myImage.RotateFlip(RotateFlipType.Rotate180FlipX); 					//呼叫RotateFlip方法實現圖形翻轉
            pictureBox1.Image = myImage;									//顯示旋轉後的圖片
        }
    }
}