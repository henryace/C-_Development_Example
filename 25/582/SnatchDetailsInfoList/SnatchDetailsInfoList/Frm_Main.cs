using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace SnatchDetailsInfoList
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private WMPLib.WindowsMediaPlayerClass c;	//初始化一個媒體對像
        private WMPLib.IWMPMedia m;        	//建立媒體播放列表對像

        private void ButOpen_Click(object sender, EventArgs e)
        {
            this.optFile.ShowDialog();
        }
        //載入多媒體文件
        private void ButPlay_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.URL = this.optFile.FileName;	//播放指定路徑下的多媒體文件
        }
        private void ButStop_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.Ctlcontrols.stop(); 			//停止多媒體文件的播放
        }
        private void ButPause_Click(object sender, EventArgs e)
        {
            if (this.ButPause.Text == "暫停(&A)") 					//當單擊「暫停（&A）」鍵時
            {
                this.axWindowsMediaPlayer1.Ctlcontrols.pause(); 		//暫停多媒體文件的播放
                this.ButPause.Text = "繼續(&A)"; 					//使Button按鈕上的文字變為「繼續（&A）」
            }
            else											//當單擊的是「繼續（&A）」按鈕時
            {
                this.axWindowsMediaPlayer1.Ctlcontrols.play(); 		//播放多媒體文件
                this.ButPause.Text = "暫停(&A)"; 					//設定Button按鈕上的文字變為「暫停（&A）」
            }
        }
        private void ButInfo_Click(object sender, EventArgs e)
        {
            if (this.optFile.FileName != "optFile")	//當打開文件的文件名不為「optFile」
            {
                c = new WMPLib.WindowsMediaPlayerClass(); 		//實例化WindowsMediaPlayerClass類的對象
                m = c.newMedia(this.optFile.FileName); 				//為IWMPMedia對像賦值
                //取得媒體詳細訊息
                MessageBox.Show("歌手名:" + m.getItemInfo("Author") + "\r\n" + "歌  名:" + m.getItemInfo("Title"));
            }
        }
    }
}