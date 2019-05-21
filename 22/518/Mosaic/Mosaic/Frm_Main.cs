using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace Mosaic
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp|*.jpg;*.jpeg;*.bmp";
            openFileDialog1.ShowDialog();
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);
            this.BackgroundImage = myImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap myBitmap = new Bitmap(this.BackgroundImage);				//根據視窗的背景實例化Bitmap類
            int intWidth = myBitmap.Width / 50;								//取得圖片的指定寬度
            int intHeight = myBitmap.Height / 50; 								//取得圖片的指定高度
            Graphics myGraphics = this.CreateGraphics(); 							//建立視窗的Graphics類
            myGraphics.Clear(Color.WhiteSmoke); 								//以指定的顏色清除
            Point[] myPoint = new Point[2500];									//定義陣列
            for (int i = 0; i < 50; i++)										//取得指定區域圖片的位置
            {
                for (int j = 0; j < 50; j++)
                {
                    myPoint[i * 50 + j].X = i * intWidth;
                    myPoint[i * 50 + j].Y = j * intHeight;
                }
            }
            Bitmap bitmap = new Bitmap(myBitmap.Width, myBitmap.Height);			//實例化Bitmap類
            for (int i = 0; i < 10000; i++)
            {
                Random rand = new Random();								//實例化Random類
                int intPos = rand.Next(2500);									//取得一個隨機數
                for (int m = 0; m < intWidth; m++)
                {
                    for (int n = 0; n < intHeight; n++)
                    {
                        bitmap.SetPixel(myPoint[intPos].X + m, myPoint[intPos].Y + n, myBitmap.GetPixel(myPoint[intPos].X + m,
        myPoint[intPos].Y + n)); 						//透過呼叫Bitmap對象的SetPixel方法為圖像的各像素點重新著色
                    }
                }
                this.Refresh();//工作區無效
                this.BackgroundImage = bitmap;								//顯示處理後的圖片
                for (int k = 0; k < 2500; k++)
                {
                    for (int m = 0; m < intWidth; m++)
                    {
                        for (int n = 0; n < intHeight; n++)
                        {
                            bitmap.SetPixel(myPoint[k].X + m, myPoint[k].Y + n, myBitmap.GetPixel(myPoint[k].X + m,
        myPoint[k].Y + n)); 					//透過呼叫Bitmap對象的SetPixel方法為圖像的各像素點重新著色
                        }
                    }
                    this.Refresh(); //工作區無效
                    this.BackgroundImage = bitmap;							//顯示處理後的圖片
                }
            }
        }
    }
}