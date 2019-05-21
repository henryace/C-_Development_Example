using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace CutImage
{
    public partial class Frm_Main : Form
    {
        bool isDrag = false;													//是否可以剪下圖片
        Rectangle theRectangle = new Rectangle(new Point(0, 0), new Size(0, 0));				//實例化Rectangle類
        Point startPoint, oldPoint;												//定義Point類
        private Graphics ig;													//定義Graphics類
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //設定文件的類型
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp,*.gif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.ShowDialog();										//打開文件對話框
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);		//實例化Image類
            pictureBox1.Image = myImage;										//顯示圖片
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //如果開始繪製，則開始記錄鼠標位置
                if ((isDrag = !isDrag) == true)
                {
                    startPoint = new Point(e.X, e.Y);								//記錄鼠標的目前位置
                    oldPoint = new Point(e.X, e.Y);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            ig = pictureBox1.CreateGraphics();								//建立pictureBox1控制元件的Graphics類
            //繪製矩形框
            ig.DrawRectangle(new Pen(Color.Black, 1), startPoint.X, startPoint.Y, e.X - startPoint.X, e.Y - startPoint.Y);
            theRectangle = new Rectangle(startPoint.X, startPoint.Y, e.X - startPoint.X, e.Y - startPoint.Y);	//取得矩形框的區域
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();										//為目前視窗建立Graphics類
            if (isDrag)														//如果鼠示已按下
            {
                //繪製一個矩形框
                g.DrawRectangle(new Pen(Color.Black, 1), startPoint.X, startPoint.Y, e.X - startPoint.X, e.Y - startPoint.Y);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Graphics graphics = this.CreateGraphics();						//為目前視窗建立Graphics類
                Bitmap bitmap = new Bitmap(pictureBox1.Image);					//實例化Bitmap類
                Bitmap cloneBitmap = bitmap.Clone(theRectangle, PixelFormat.DontCare);//透過剪下圖片的大小實例化Bitmap類
                graphics.DrawImage(cloneBitmap, e.X, e.Y);						//繪製剪下的圖片
                Graphics g = pictureBox1.CreateGraphics();
                SolidBrush myBrush = new SolidBrush(Color.White);				//定義畫刷
                g.FillRectangle(myBrush, theRectangle);							//繪製剪下後的圖片
            }
            catch { }
        }
    }
}