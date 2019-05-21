using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace MouseMove
{
    public partial class Frm_Main : Form
    {
        bool flag = false;
        int x, y;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //設定文件的類型
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp,*.gif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.ShowDialog(); 									//打開文件對話框
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName); 	//根據文件的路徑實例化Image類
            pictureBox1.Image = myImage; 									//顯示打開的圖片
            pictureBox1.Height = myImage.Height;		//根據圖片大小設定pictureBox1控制元件的高度
            pictureBox1.Width = myImage.Width; 		//根據圖片大小設定pictureBox1控制元件的高度
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;													//標識，鼠標按下
            x = e.X;													//記錄鼠標的X坐標
            y = e.Y; 													//記錄鼠標的Y坐標
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                //設定pictureBox1控制元件的位置
                pictureBox1.Left = pictureBox1.Left + (e.X - x);
                pictureBox1.Top = pictureBox1.Top + (e.Y - y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }
    }
}