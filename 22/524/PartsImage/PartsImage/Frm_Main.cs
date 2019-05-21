using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PartsImage
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
            g.Clear(Color.White);//清空背景色
            int width = MyBitmap.Width;//取得圖片的寬度
            int height = MyBitmap.Height;//取得圖片的高度
            //定義將圖片切分成四個部分的區域
            RectangleF[] block ={
					new RectangleF(0,0,width/2,height/2),
					new RectangleF(width/2,0,width/2,height/2),
					new RectangleF(0,height/2,width/2,height/2),
					new RectangleF(width/2,height/2,width/2,height/2)};
            //分別克隆圖片的四個部分	
            Bitmap[] MyBitmapBlack ={
                MyBitmap.Clone(block[0],System.Drawing.Imaging.PixelFormat.DontCare),
                MyBitmap.Clone(block[1],System.Drawing.Imaging.PixelFormat.DontCare),
                MyBitmap.Clone(block[2],System.Drawing.Imaging.PixelFormat.DontCare),
                MyBitmap.Clone(block[3],System.Drawing.Imaging.PixelFormat.DontCare)};
            //繪製圖片的四個部分，各部分繪製時間間隔為0.5秒					
            g.DrawImage(MyBitmapBlack[0], 0, 0);
            System.Threading.Thread.Sleep(500);
            g.DrawImage(MyBitmapBlack[1], width / 2, 0);
            System.Threading.Thread.Sleep(500);
            g.DrawImage(MyBitmapBlack[3], width / 2, height / 2);
            System.Threading.Thread.Sleep(500);
            g.DrawImage(MyBitmapBlack[2], 0, height / 2);
        }
    }
}