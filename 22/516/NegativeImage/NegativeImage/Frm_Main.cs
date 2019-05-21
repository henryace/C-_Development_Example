using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NegativeImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //打圖像文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "圖像文件(JPeg, Gif, Bmp, etc.)|*.jpg;*.jpeg;*.gif;*.bmp;*.tif; *.tiff; *.png| JPeg 圖像文件(*.jpg;*.jpeg)|*.jpg;*.jpeg |GIF 圖像文件(*.gif)|*.gif |BMP圖像文件(*.bmp)|*.bmp|Tiff圖像文件(*.tif;*.tiff)|*.tif;*.tiff|Png圖像文件(*.png)| *.png |所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)//判斷是否選擇了文件
            {
                Bitmap MyBitmap = new Bitmap(openFileDialog.FileName);
                this.pictureBox1.Image = MyBitmap;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Height = this.pictureBox1.Image.Height;//取得圖片高度
                int Width = this.pictureBox1.Image.Width;//取得圖片寬度
                Bitmap newbitmap = new Bitmap(Width, Height);//實例化位圖物件
                Bitmap oldbitmap = (Bitmap)this.pictureBox1.Image;//取得原圖
                Color pixel;//定義一個Color結構
                //深度搜尋圖片的每個位置
                for (int x = 1; x < Width; x++)
                {
                    for (int y = 1; y < Height; y++)
                    {
                        int r, g, b;//定義3個變數，用來記錄指定點的R\G\B值
                        pixel = oldbitmap.GetPixel(x, y);//取得指定點的像素值
                        r = 255 - pixel.R;//記錄R值
                        g = 255 - pixel.G;//記錄G值
                        b = 255 - pixel.B;//記錄B值
                        newbitmap.SetPixel(x, y, Color.FromArgb(r, g, b));//為指定點重新著色
                    }
                }
                this.pictureBox1.Image = newbitmap;//顯示底片效果的圖像
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}