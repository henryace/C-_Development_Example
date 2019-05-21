using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace BassoRelievo
{
    public partial class Frm_Main : Form
    {
        Bitmap myBitmap;
        Image myImage;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp|*.jpg;*.jpeg;*.bmp"; 		//設定文件的類型
            openFileDialog1.ShowDialog(); //打開文件對話框
            myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName); 	//根據文件的路徑實例化Image類
            myBitmap = new Bitmap(myImage);							//實例化Bitmap類
            this.BackgroundImage = myBitmap;	 							//顯示打開的圖片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                myBitmap = new Bitmap(myImage); 						//實例化Bitmap類
                //深度搜尋圖片中的所有象素
                for (int i = 0; i < myBitmap.Width - 1; i++)
                {
                    for (int j = 0; j < myBitmap.Height - 1; j++)
                    {
                        Color Color1 = myBitmap.GetPixel(i, j);				//取得目前象素的顏色值
                        Color Color2 = myBitmap.GetPixel(i + 1, j + 1);			//取得斜點下象素的顏色值
                        int red = Math.Abs(Color1.R - Color2.R + 128);				//設定R色值
                        int green = Math.Abs(Color1.G - Color2.G + 128); 			//設定G色值
                        int blue = Math.Abs(Color1.B - Color2.B + 128); 			//設定B色值
                        //顏色處理
                        if (red > 255) red = 255;							//如果R色值大於255，將R色值設為255
                        if (red < 0) red = 0; 								//如果R色值小於0，將R色值設為0
                        if (green > 255) green = 255; 						//如果G色值大於255，將R色值設為255
                        if (green < 0) green = 0; 							//如果G色值小於0，將R色值設為0
                        if (blue > 255) blue = 255; 							//如果B色值大於255，將R色值設為255
                        if (blue < 0) blue = 0; 							//如果B色值小於0，將R色值設為0
                        //透過呼叫Bitmap對象的SetPixel方法為圖像的像素點重新著色
                        myBitmap.SetPixel(i, j, Color.FromArgb(red, green, blue));
                    }
                }
                this.BackgroundImage = myBitmap;							//顯示處理後的圖片
            }
            catch { }
        }
    }
}