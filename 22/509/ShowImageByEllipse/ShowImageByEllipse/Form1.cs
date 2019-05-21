using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShowImageByEllipse
{
    public partial class Form1 : Form
    {
        public Form1()
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
            this.panel1.Refresh();//刷新Panel控制元件
            Graphics g = this.panel1.CreateGraphics();//實例化繪圖物件
            TextureBrush MyBrush = new TextureBrush(MyBitmap);//實例化TextureBrush物件
            g.FillEllipse(MyBrush, this.panel1.ClientRectangle);//繪製橢圓圖像
        }
    }
}