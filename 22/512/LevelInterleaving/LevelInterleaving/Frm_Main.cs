using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace LevelInterleaving
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
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp|*.jpg;*.jpeg;*.bmp"; 			//設定文件的類型
            openFileDialog1.ShowDialog(); 									//打開文件對話框
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);	//根據文件的路徑實例化Image類
            myBitmap = new Bitmap(myImage);								//實例化Bitmap類
            this.BackgroundImage = myBitmap; 								//顯示打開的圖片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int intWidth = this.BackgroundImage.Width;						//取得背景圖片的寬度
                int intHeight = this.BackgroundImage.Height; 					//取得背景圖片的高度
                Graphics myGraphics = this.CreateGraphics(); 					//建立視窗的Graphics類
                myGraphics.Clear(Color.WhiteSmoke); 							//以指定的顏色清除
                Bitmap bitmap = new Bitmap(intWidth, intHeight); 					//實例化Bitmap類
                int i = 0;
                //透過呼叫Bitmap對象的SetPixel方法實現水平交錯效果顯示圖像
                while (i <= intWidth / 2)
                {
                    for (int m = 0; m <= intHeight - 1; m++)
                    {
                        bitmap.SetPixel(i, m, myBitmap.GetPixel(i, m));				//設定目前象素的顏色值
                    }
                    for (int n = 0; n <= intHeight - 1; n++)
                    {
                        bitmap.SetPixel(intWidth - i - 1, n, myBitmap.GetPixel(intWidth - i - 1, n));//設定目前象素的顏色值
                    }
                    i++;
                    this.Refresh();										//工作區無效
                    this.BackgroundImage = bitmap;							//顯示水平交錯的圖片
                    System.Threading.Thread.Sleep(10);							//線程掛起
                }
            }
            catch { }
        }
    }
}