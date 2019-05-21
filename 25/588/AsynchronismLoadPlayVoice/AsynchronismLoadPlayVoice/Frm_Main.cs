using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace AsynchronismLoadPlayVoice
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 本實例需參考命名空間using System.Media
        /// </summary>
        private void unfold_Click(object sender, EventArgs e)
        {
            OpenFileDialog VoiceDialog = new OpenFileDialog();//宣告一個提示用戶打開文件的對象
            VoiceDialog.ShowDialog(); //用預設的所有者執行通用對話框。 （繼承自 CommonDialog。）
            path.Text = VoiceDialog.FileName; //將文件的路徑儲存在文字框中
        }

        private void play_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer player = new SoundPlayer(); //宣告一個控制WAV文件的聲音播放文件對像
                player.SoundLocation = path.Text; //指定聲音文件的路徑
                player.LoadAsync();  //設定播放的方法
                player.Play(); //播放聲音文件
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void path_TextChanged(object sender, EventArgs e)
        {
            if (path.Text != null && path.Text != "")//當文字框中的內容為空或不存在時
            {
                play.Enabled = true;//設定「播放」按鈕為可用狀態
            }
            else                                   //當文字框中的內容為空或不存在時
            {
                play.Enabled = false;//設定「播放」按鈕為不可用狀態
            }
        }
    }
}
