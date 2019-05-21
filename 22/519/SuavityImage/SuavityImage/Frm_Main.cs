using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SuavityImage
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
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap MyBitmap = new Bitmap(openFileDialog.FileName);
                this.pictureBox1.Image = MyBitmap;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Height = this.pictureBox1.Image.Height;//取得圖像高度
                int Width = this.pictureBox1.Image.Width;//取得圖像寬度
                Bitmap bitmap = new Bitmap(Width, Height);//實例化新的位圖物件
                Bitmap MyBitmap = (Bitmap)this.pictureBox1.Image;//記錄原圖
                Color pixel;//定義一個Color結構
                int[] Gauss = { 1, 2, 1, 2, 4, 2, 1, 2, 1 };//定義高斯模板值
                //深度搜尋原圖的每個位置
                for (int x = 1; x < Width - 1; x++)
                    for (int y = 1; y < Height - 1; y++)
                    {
                        int r = 0, g = 0, b = 0;//聲明3個變數，用來記錄R/G/B值
                        int Index = 0;//聲明一個變數，用來記錄位置
                        for (int col = -1; col <= 1; col++)
                            for (int row = -1; row <= 1; row++)
                            {
                                pixel = MyBitmap.GetPixel(x + row, y + col);//取得指定點的像素
                                r += pixel.R * Gauss[Index];//記錄R值
                                g += pixel.G * Gauss[Index];//記錄G值
                                b += pixel.B * Gauss[Index];//記錄B值
                                Index++;
                            }
                        r /= 16;//為R重新賦值
                        g /= 16;//為G重新賦值
                        b /= 16;//為B重新賦值
                        //處理顏色值溢出
                        r = r > 255 ? 255 : r;
                        r = r < 0 ? 0 : r;
                        g = g > 255 ? 255 : g;
                        g = g < 0 ? 0 : g;
                        b = b > 255 ? 255 : b;
                        b = b < 0 ? 0 : b;
                        bitmap.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));//重新為指定點賦顏色值
                    }
                this.pictureBox1.Image = bitmap;//顯示柔化效果的圖像
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "訊息提示");
            }
        }
    }
}