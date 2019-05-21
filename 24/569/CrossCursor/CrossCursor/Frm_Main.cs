using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace CrossCursor
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
            openFileDialog1.ShowDialog(); 							//打開文件對話框
            myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName); 	//根據文件的路徑實例化Image類
            pictureBox1.Image = myImage; 							//顯示打開的圖片
            pictureBox1.Height = myImage.Height; 						//根據圖片大小設定pictureBox1控制元件的高度
            pictureBox1.Width = myImage.Width; 						//根據圖片大小設定pictureBox1控制元件的寬度
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics myGraphics = pictureBox1.CreateGraphics();
            //透過呼叫Graphics對象的DrawLine方法實現鼠標十字定位功能
            myGraphics.DrawLine(new Pen(Color.Black, 1), new Point(e.X, 0), new Point(e.X, e.Y));
            myGraphics.DrawLine(new Pen(Color.Black, 1), new Point(e.X, e.Y), new Point(e.X, pictureBox1.Height - e.Y));
            myGraphics.DrawLine(new Pen(Color.Black, 1), new Point(0, e.Y), new Point(e.X, e.Y));
            myGraphics.DrawLine(new Pen(Color.Black, 1), new Point(e.X, e.Y), new Point(pictureBox1.Width - e.X, e.Y));
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = myImage;						//顯示原來的圖片
            pictureBox1.Height = myImage.Height;					//設定控制元件的高度
            pictureBox1.Width = myImage.Width; 					//設定控制元件的寬度
        }
    }
}