using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SnatchPlayTime
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void unfold_Click(object sender, EventArgs e)
        {
            OpenFileDialog MP3Dialog = new OpenFileDialog();//宣告一個提示用戶打開文件的對象
            MP3Dialog.Filter = "MP3文件(*.MP3)|*.MP3"; //取得或設定目前文件名篩選器字串
            if (MP3Dialog.ShowDialog() == DialogResult.OK) //當選定文件之後單擊「打開」按鈕時
            {
                filePath.Text = MP3Dialog.FileName;//在文字框中顯示打開文件的文件路徑
                axWindowsMediaPlayer1.URL = MP3Dialog.FileName;//為WindowsMediaPlayer元件指定媒體
            }
        }

        private void snatch_Click(object sender, EventArgs e)
        {
            playTime.Text = GetFileTime(Convert.ToInt32(axWindowsMediaPlayer1.currentMedia.duration) * 1000);//在文字框中顯示歌曲的播放時間
        }

        #region  取得文件的播放時間，並按指定格式進行顯示
        /// <summary>
        /// 取得文件的播放時間，並按指定格式進行顯示
        /// </summary>
        /// <param Millisecond="int">毫秒數</param>
        public string GetFileTime(int Millisecond)
        {
            string Tem_Time = ""; //用來儲存歌曲的播放時間
            double Tem_min = 0;  //用來儲存歌曲播放的分鐘部分
            double Tem_sec = 0;  //用來儲存歌曲播放時間的秒
            double Tem_millisec = 0; //用來儲存歌曲播放時間的毫秒
            Tem_min = Millisecond / 1000;//將目前時間轉化為以秒為單位的資料類型
            Tem_min = Tem_min / 60.0; //將目前時間轉化為以分為單位的資料類型
            Tem_sec = Tem_min - (int)Tem_min; //儲存歌曲播放時間的小數部分（當以分為單位時）
            Tem_min = (int)Tem_min; //將double型變數Tem_min轉化為int型變數
            Tem_sec = (60 * Tem_sec) / 100.0; //將取得的小數轉化為以秒為單位的資料
            Tem_sec = (int)(Tem_sec * 100);//將資料類型轉化為int型
            Tem_millisec = (int)((Millisecond - Tem_min * 60 * 1000 - Tem_sec * 1000) / 1000 * 100);//將歌曲播放的時間轉換為以秒為單位存儲
            if (Tem_min >= 100)//當Tem_min的值大於等於100時
            {
                Tem_Time = Tem_min.ToString("000") + ":" + Tem_sec.ToString("00");//設定時間的顯示格式
            }
            else//當Tem_min的值小於100時
                Tem_Time = Tem_min.ToString("00") + ":" + Tem_sec.ToString("00"); //設定事件的顯示格式
            return Tem_Time;//返回變數Tem_Time
        }
        #endregion

        private void filePath_TextChanged(object sender, EventArgs e)
        {
            if (filePath.Text != "" && filePath.Text != null)//當文字框中內容不為空且存在時
            {
                snatch.Enabled = true;//設定「取得」按鈕為可用狀態
            }
            else//當文字框中內容為空或這不存在時
            {
                snatch.Enabled = false;//設定「取得」按鈕為不可用狀態
            }
        }
    }
}
