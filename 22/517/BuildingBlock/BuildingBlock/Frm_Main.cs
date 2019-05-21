using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace BuildingBlock
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
            Graphics myGraphics = this.CreateGraphics(); 						//建立視窗的Graphics類
            Bitmap myBitmap = new Bitmap(this.BackgroundImage); 			//實例化Bitmap類
            int myWidth, myHeight, i, j, iAvg, iPixel;							//定義變數
            Color myColor, myNewColor; 								//定義顏色變數
            RectangleF myRect;
            myWidth = myBitmap.Width;									//取得背景圖片的寬度
            myHeight = myBitmap.Height;								//取得背景圖片的高度
            myRect = new RectangleF(0, 0, myWidth, myHeight);				//取得圖片的區域
            Bitmap bitmap = myBitmap.Clone(myRect, System.Drawing.Imaging.PixelFormat.DontCare); 	//實例化Bitmap類
            i = 0;
            //深度搜尋圖片的所有象素
            while (i < myWidth - 1)
            {
                j = 0;
                while (j < myHeight - 1)
                {
                    myColor = bitmap.GetPixel(i, j);							//取得目前象素的顏色值
                    iAvg = (myColor.R + myColor.G + myColor.B) / 3;			//平均法
                    iPixel = 0;
                    if (iAvg >= 128)									//如果顏色值大於等於128
                        iPixel = 255;									//設定為255
                    else
                        iPixel = 0;
                    //透過呼叫Color對象的FromArgb方法取得圖像各像素點的顏色
                    myNewColor = Color.FromArgb(255, iPixel, iPixel, iPixel);
                    bitmap.SetPixel(i, j, myNewColor);						//設定顏色值
                    j = j + 1;
                }
                i = i + 1;
            }
            myGraphics.Clear(Color.WhiteSmoke); 							//以指定的顏色清除
            myGraphics.DrawImage(bitmap, new Rectangle(0, 0, myWidth, myHeight));	//繪製處理後的圖片
        }
    }
}