using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DiffuseImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private Bitmap MyBitmap;
        private void button2_Click(object sender, EventArgs e)
        {
            //打開圖像文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "圖像文件(JPeg, Gif, Bmp, etc.)|*.jpg;*.jpeg;*.gif;*.bmp;*.tif; *.tiff; *.png| JPeg 圖像文件(*.jpg;*.jpeg)|*.jpg;*.jpeg |GIF 圖像文件(*.gif)|*.gif |BMP圖像文件(*.bmp)|*.bmp|Tiff圖像文件(*.tif;*.tiff)|*.tif;*.tiff|Png圖像文件(*.png)| *.png |所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //得到原始大小的圖像
                Bitmap SourceBitmap = new Bitmap(openFileDialog.FileName);
                //得到縮放後的圖像
                MyBitmap = new Bitmap(SourceBitmap, this.pictureBox1.Width, this.pictureBox1.Height);
                this.pictureBox1.Image = MyBitmap;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int width = this.MyBitmap.Width; //圖像寬度	
                int height = this.MyBitmap.Height; //圖像高度
                Graphics g = this.panel1.CreateGraphics();//實例化Graphics物件
                g.Clear(Color.Gray); //初始為全灰色
                for (int i = 0; i <= width / 2; i++)
                {
                    int j = Convert.ToInt32(i * (Convert.ToSingle(height) / Convert.ToSingle(width)));//取得高和寬的比例
                    Rectangle DestRect = new Rectangle(width / 2 - i, height / 2 - j, 2 * i, 2 * j);//設定縮小後圖片的大小
                    Rectangle SrcRect = new Rectangle(0, 0, MyBitmap.Width, MyBitmap.Height);//取得原圖片大小
                    g.DrawImage(MyBitmap, DestRect, SrcRect, GraphicsUnit.Pixel);//按照指定的大小繪製原圖片
                    System.Threading.Thread.Sleep(10);//線程掛起
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "訊息提示");
            }
        }
    }
}