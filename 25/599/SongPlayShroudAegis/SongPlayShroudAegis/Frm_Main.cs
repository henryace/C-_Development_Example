using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SongPlayShroudAegis
{
    public partial class Frm_Main : Form
    {
        int width = 0, heigh = 0;
        string strpath;
        public Frm_Main()
        {
            InitializeComponent();
            strpath = Application.StartupPath + "\\music";
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            width = this.Width;
            heigh = this.Height;

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            ExitWindows();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                drowInfo(); 										//繪製屏保訊息
                this.timer1.Interval = new Random().Next(800, 1600); 		//設定timer1的時間間隔
                string strname = new Random().Next(1, 4).ToString(); 		//記錄隨機數
                //當播放器處於空或者已停止時
                if (this.axWindowsMediaPlayer1.status == "" || this.axWindowsMediaPlayer1.status == "已停止")
                {
                    string strUrl = strpath + "\\" + strname + ".mp3";	//取得多媒體文件所處的路徑
                    this.axWindowsMediaPlayer1.URL = strUrl; 	//設定播放文件的URL
                }
            }
            catch (Exception ex) 							//擷取異常
            {
                timer1.Enabled = false; 						//關閉計時器timer1
                MessageBox.Show(ex.Message); 				//彈出異常訊息提示
            }
        }

        private void drowInfo()
        {
            Graphics myGraphics = this.CreateGraphics(); 			//實例化一個GDI+繪圖圖面類
            myGraphics.Clear(Color.Black);					//清空原有繪圖面並以指定的背景色填充
            string strinfo = "歌曲播放螢幕保護";				//儲存顯示訊息
            int x = new Random().Next(0, width - 250); 			//設定顯示地點的X坐標
            int y = new Random().Next(50, heigh - 20); 			//設定顯示地點的Y坐標
            myGraphics.DrawString(strinfo, new Font("華文形楷", 72, FontStyle.Bold), new SolidBrush(Color.FromArgb(new Random().Next(50, 255), new Random().Next(70, 255), new Random().Next(36, 255))), x, y); 	//繪製內容
        }

        private void ExitWindows()
        {
            this.timer1.Enabled = false;
            Application.Exit();
        }

    }
}