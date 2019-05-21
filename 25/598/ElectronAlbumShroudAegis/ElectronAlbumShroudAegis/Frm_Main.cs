using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElectronAlbumShroudAegis
{
    public partial class Frm_Main : Form
    {
        int width = 0, heigh = 0;
        string strpath;
        public Frm_Main()
        {
            InitializeComponent();

        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            strpath = Application.StartupPath + "\\Image";		//取得可執行文件的路徑
            Cursor.Hide();			//隱藏目前鼠標指針
            this.timer1.Enabled = true; 	//啟動timer1計時器
            width = this.Width;			//儲存目前視窗的寬度
            heigh = this.Height;			//儲存目前視窗的高度
            drowImage(); 			//繪製圖片
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Interval = new Random().Next(500, 2000);	//設定Timer控制元件的Interval屬性來控制圖片更改的頻率
            drowImage(); 								//繪製圖片
        }

        private void drowImage()
        {
            Graphics myGraphics = this.CreateGraphics(); 			//實例化一個GDI+繪圖圖面類
            myGraphics.Clear(Color.Black);					//清空原有的繪圖圖面並以指定的背景色填充
            //實例化一個GDI+位圖實例
            Bitmap myBitmap = new Bitmap(strpath + "\\" + new Random().Next(1, 5).ToString() + ".jpg");
            myGraphics.DrawImage(myBitmap, new Random().Next(0, width - myBitmap.Width), new Random().Next(0, heigh - myBitmap.Height));//繪製圖片
        }

        private void Frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            ExitWindows();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            ExitWindows();
        }

        private void ExitWindows()
        {
            this.timer1.Enabled = false;
            Application.Exit();
        }
    }
}