using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClockingPlayImplement
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //當目前的時間與文字框中的內容一致時
            if (DateTime.Now.ToShortTimeString() == this.textBox2.Text.Trim().ToString())
            {
                this.axWindowsMediaPlayer1.URL = this.textBox1.Text; 		//設定音樂文件的播放路徑
                this.axWindowsMediaPlayer1.Ctlcontrols.play(); 			//播放多媒體文件
                this.timer1.Enabled = false; 		//關閉timer1計時器
                this.timer2.Enabled = true; 		//啟動timer2計時器
                this.timer2.Interval = 1000; 		//設定timer2計時器的Tick事件間隔為1s
                this.Show(); 				//顯示該視窗
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.Hide();
            this.ShowInTaskbar = false;//不在任務欄顯現

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = this.openFileDialog1.FileName;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.axWindowsMediaPlayer1.status != "正在播放")			//當多媒體處於正在播放的狀態時
            {
                this.timer2.Enabled = false; 		//關閉timer2計時器
                MessageBox.Show("本次播放已完成，謝謝使用！！！");		//彈出訊息提示
            }
        }
    }
}