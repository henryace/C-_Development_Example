using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageBlowUp
{
    public partial class Frm_Main : Form
    {
        Cursor myCursor = new Cursor(@"C:\WINDOWS\Cursors\cross_r.cur"); //自定義鼠標 
        Image myImage;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //設定文件的類型
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp,*.gif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.ShowDialog();								//打開文件對話框
            myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);	//根據文件的路徑和名稱實例化Image類
            pictureBox1.Image = myImage;								//顯示圖片
            pictureBox1.Height = myImage.Height;							//設定控制元件的高度
            pictureBox1.Width = myImage.Width;							//設定控制元件的寬度
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Cursor.Current = myCursor;								//定義鼠標
                Graphics graphics = pictureBox1.CreateGraphics();				//實例化pictureBox1控制元件的Graphics類
                //聲明兩個Rectangle對象，分別用來指定要放大的區域和放大後的區域
                Rectangle sourceRectangle = new Rectangle(e.X - 10, e.Y - 10, 20, 20);	//要放大的區域 
                Rectangle destRectangle = new Rectangle(e.X - 20, e.Y - 20, 40, 40);
                //呼叫DrawImage方法對選定區域進行重新繪製，以放大該部分
                graphics.DrawImage(myImage, destRectangle, sourceRectangle, GraphicsUnit.Pixel);
            }
            catch { }
        }
    }
}