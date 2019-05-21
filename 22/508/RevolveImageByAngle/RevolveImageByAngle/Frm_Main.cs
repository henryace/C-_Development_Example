using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RevolveImageByAngle
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private Bitmap SourceBitmap;
        private Bitmap MyBitmap;
        private void button2_Click(object sender, EventArgs e)
        {
            //打開圖像文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "圖像文件(JPeg, Gif, Bmp, etc.)|*.jpg;*.jpeg;*.gif;*.bmp;*.tif; *.tiff; *.png| JPeg 圖像文件(*.jpg;*.jpeg)|*.jpg;*.jpeg |GIF 圖像文件(*.gif)|*.gif |BMP圖像文件(*.bmp)|*.bmp|Tiff圖像文件(*.tif;*.tiff)|*.tif;*.tiff|Png圖像文件(*.png)| *.png |所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //得到原始大小的圖像
                SourceBitmap = new Bitmap(openFileDialog.FileName);
                //得到縮放後的圖像
                MyBitmap = new Bitmap(SourceBitmap, this.pictureBox1.Width, this.pictureBox1.Height);
                this.pictureBox1.Image = MyBitmap;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.panel1.CreateGraphics();//實例化繪圖物件
            float MyAngle = 0;//旋轉的角度
            while (MyAngle < 360)
            {
                TextureBrush MyBrush = new TextureBrush(MyBitmap);//實例化TextureBrush類
                this.panel1.Refresh();//使工作區無效
                MyBrush.RotateTransform(MyAngle);//以指定角度旋轉圖像
                g.FillRectangle(MyBrush, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);//繪製旋轉後的圖像
                MyAngle += 0.5f;//增加旋轉的角度
                System.Threading.Thread.Sleep(50);//使線程休眠50毫秒
            }
        }
    }
}