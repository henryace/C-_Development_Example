using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace UprightnessInterleaving
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
            myBitmap = new Bitmap(myImage);	 							//實例化Bitmap類
            this.BackgroundImage = myBitmap; 								//顯示打開的圖片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int intWidth = this.BackgroundImage.Width;						//取得背景片的寬度
                int intHeight = this.BackgroundImage.Height;					//取得背景片的高度
                Graphics myGraphics = this.CreateGraphics(); 					//建立視窗的Graphics類
                myGraphics.Clear(Color.WhiteSmoke); 							//以指定的顏色清除
                Bitmap bitmap = new Bitmap(intWidth, intHeight); 					//實例化Bitmap類
                int i = 0;
                //透過呼叫Bitmap對象的SetPixel方法實現垂直交錯效果顯示圖像
                while (i <= intHeight / 2)
                {
                    for (int m = 0; m <= intWidth - 1; m++)
                    {
                        bitmap.SetPixel(m, i, myBitmap.GetPixel(m, i));				//設定目前象素的顏色值
                    }
                    for (int n = 0; n <= intWidth - 1; n++)
                    {
                        bitmap.SetPixel(n, intHeight - i - 1, myBitmap.GetPixel(n, intHeight - i - 1)); //設定目前象素的顏色值
                    }
                    i++;
                    this.Refresh();										//工作區無效
                    this.BackgroundImage = bitmap; 							//顯示垂直交錯的圖片
                    System.Threading.Thread.Sleep(10);							//線程掛起
                }
            }
            catch { }
        }
    }
}