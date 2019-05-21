using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace HundredWindow
{
    public partial class Frm_Main : Form
    {
        Image myImage;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp|*.jpg;*.jpeg;*.bmp";		//設定文件的類型
            openFileDialog1.ShowDialog();								//打開文件對話框
            myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);	//根據文件的路徑實例化Image類
            this.BackgroundImage = myImage;								//顯示打開的圖片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap myBitmap = (Bitmap)this.BackgroundImage.Clone();		//用視窗背景的復本實例化Bitmap類
                int intWidth = myBitmap.Width;							//記錄圖片的寬度
                int intHeight = myBitmap.Height / 20;						//記錄圖片的指定高度
                Graphics myGraphics = this.CreateGraphics();				//建立視窗的Graphics類
                myGraphics.Clear(Color.WhiteSmoke);						//用指定的顏色清除視窗背景
                Point[] myPoint = new Point[30];							//定義陣列
                for (int i = 0; i < 30; i++)									//記錄百葉窗各節點的位置
                {
                    myPoint[i].X = 0;
                    myPoint[i].Y = i * intHeight;
                }
                Bitmap bitmap = new Bitmap(myBitmap.Width, myBitmap.Height);	//實例化Bitmap類
                //透過呼叫Bitmap對象的SetPixel方法重新設定圖像的像素點顏色，從而實現百葉窗效果
                for (int m = 0; m < intHeight; m++)
                {
                    for (int n = 0; n < 20; n++)
                    {
                        for (int j = 0; j < intWidth; j++)
                        {
                            bitmap.SetPixel(myPoint[n].X + j, myPoint[n].Y + m, myBitmap.GetPixel(myPoint[n].X + j, myPoint[n].Y + m));//取得目前象素顏色值
                        }
                    }
                    this.Refresh();									//繪製無效
                    this.BackgroundImage = bitmap;						//顯示百葉視窗的效果
                    System.Threading.Thread.Sleep(100);						//線程掛起
                }
            }
            catch { }
        }
    }
}