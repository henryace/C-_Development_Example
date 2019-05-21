using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageGrain
{
    public partial class Frm_Main : Form
    {
        Bitmap myBitmap;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp|*.jpg;*.jpeg;*.bmp";			//設定文件的類型
            openFileDialog1.ShowDialog(); 									//打開文件對話框
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName); 	//根據文件的路徑實例化Image類
            myBitmap = new Bitmap(myImage);								//實例化Bitmap類
            this.BackgroundImage = myBitmap; 								//顯示打開的圖片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);//實例化Image類
                myBitmap = new Bitmap(myImage); 							//實例化Bitmap類
                Rectangle rect = new Rectangle(0, 0, myBitmap.Width, myBitmap.Height);	//實例化Rectangle類
                System.Drawing.Imaging.BitmapData bmpData = myBitmap.LockBits(rect,
        System.Drawing.Imaging.ImageLockMode.ReadWrite, myBitmap.PixelFormat); 		//將指定圖像鎖定到記憶體中
                IntPtr ptr = bmpData.Scan0; 								//取得圖像中第一個像素資料的地址
                int bytes = myBitmap.Width * myBitmap.Height * 3;			//設定大小
                byte[] rgbValues = new byte[bytes];//實例化byte陣列
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes); //使用RGB值為聲明的rgbValues陣列賦值
                for (int counter = 0; counter < rgbValues.Length; counter += 3)		//初始化大小
                    rgbValues[counter] = 255;
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes); //使用RGB值為圖像的像素點著色
                myBitmap.UnlockBits(bmpData); 							//從記憶體中解鎖圖像
                this.BackgroundImage = myBitmap;							//顯示設定後的圖片
            }
            catch { }
        }
    }
}