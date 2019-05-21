using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace MP3Player
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //***********************
        private Point mouseOffset;//記錄鼠標坐標
        private bool isMouseDown = false;//是否按下鼠標
        bool flag = false;//判斷是播放還是打開選擇視窗
        static bool MM = true;//記錄是否靜音
        //***********************

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region 移動無邊框視窗
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;
            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X;
                yOffset = -e.Y;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
        #endregion

        private void pictureBox4_Click(object sender, EventArgs e)//打開播放
        {
            if (!flag)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
                    m = 1;
                    lblSongTitle.Text = " 歌曲名稱：" + axWindowsMediaPlayer1.currentMedia.getItemInfo("Title");
                }
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)//暫停
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            flag = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)//停止
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            flag = false;
        }



        private void pictureBox7_Click(object sender, EventArgs e)//靜音
        {
            if (MM)
            {
                pictureBox7.Image = (Image)Properties.Resources.音量按鈕變色;
                axWindowsMediaPlayer1.settings.mute = true;
                MM = false;
            }
            else
            {
                pictureBox7.Image = (Image)Properties.Resources.音量按鈕;
                axWindowsMediaPlayer1.settings.mute = false;
                MM = true;
            }
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = (Image)Properties.Resources.播放按鈕變;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = (Image)Properties.Resources.播放按鈕;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Image = (Image)Properties.Resources.暫停按鈕變;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = (Image)Properties.Resources.暫停按鈕;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.Image = (Image)Properties.Resources.停止按鈕變;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Image = (Image)Properties.Resources.停止按鈕;
        }
        int m = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = (int)axWindowsMediaPlayer1.playState;
            switch (i)
            {
                case 1: lblStauts.Text = "狀態：停止"; break;
                case 2: lblStauts.Text = "狀態：暫停"; break;
                case 3: lblStauts.Text = "狀態：播放"; break;
                case 6: lblStauts.Text = "狀態：正在緩衝"; break;
                case 9: lblStauts.Text = "狀態：正在連接"; break;
                case 10: lblStauts.Text = "狀態：準備就緒"; break;
            }
            lbljindu.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
            if (m == 1)
            {
                hScrollBar1.Maximum = (int)axWindowsMediaPlayer1.currentMedia.duration;
                hScrollBar1.Minimum = 0;
                hScrollBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                hScrollBar2.Value = axWindowsMediaPlayer1.settings.volume;
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = e.NewValue;
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = e.NewValue;
        }
    }
}
