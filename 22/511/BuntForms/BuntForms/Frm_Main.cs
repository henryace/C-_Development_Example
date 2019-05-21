using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace BuntForms
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
                Graphics myGraphics = this.CreateGraphics();				//建立視窗的Graphics類
                Bitmap myBitmap = new Bitmap(myImage);					//實例化Bitmap類
                myGraphics.Clear(this.BackColor);							//以指定的顏色清除
                for (int i = 0; i < this.Height; i++)							//從上到下深度搜尋圖片
                {
                    Rectangle rectangle1 = new Rectangle(0, 0, this.Width, i);		//取得圖片指定行的象素
                    Rectangle rectangle2 = new Rectangle(0, this.Height - i, this.Width, i + 1);	//取得圖片當行區域的以下區域
                    //透過呼叫Bitmap對象的Clone方法和DrawImage方法實現圖像的推拉效果
                    Bitmap cloneBitmap = myBitmap.Clone(rectangle2, PixelFormat.DontCare);
                    myGraphics.DrawImage(cloneBitmap, rectangle1);			//繪製指定大小的圖片
                    this.Show();
                }
            }
            catch { }
        }
    }
}