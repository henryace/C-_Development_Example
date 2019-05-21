using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CanvasImage
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
            //以油畫效果顯示圖像
            Graphics g = this.panel1.CreateGraphics();
            //取得圖片尺寸
            int width = MyBitmap.Width;
            int height = MyBitmap.Height;
            RectangleF rect = new RectangleF(0, 0, width, height);
            Bitmap img = MyBitmap.Clone(rect, System.Drawing.Imaging.PixelFormat.DontCare);
            //產生隨機數序列
            Random rnd = new Random();
            //取不同的值決定油畫效果的不同程度
            int iModel = 2;
            int i = width - iModel;
            while (i > 1)
            {
                int j = height - iModel;
                while (j > 1)
                {
                    int iPos = rnd.Next(100000) % iModel;
                    //將該點的RGB值設定成附近iModel點之內的任一點
                    Color color = img.GetPixel(i + iPos, j + iPos);
                    img.SetPixel(i, j, color);
                    j = j - 1;
                }
                i = i - 1;
            }
            //重新繪製圖像
            g.Clear(Color.White);
            g.DrawImage(img, new Rectangle(0, 0, width, height));
        }
    }
}