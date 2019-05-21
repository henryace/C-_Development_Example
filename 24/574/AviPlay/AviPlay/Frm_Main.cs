using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AviPlay
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.axAnimation1.Open(Application.StartupPath + "//clock.avi");//載入AVI文件
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.axAnimation1.Stop(); 			//停止播放
                object start = this.textBox1.Text; 		//儲存起始幀中的資料
                object end = this.textBox2.Text; 		//儲存結束幀中的資料
                object time = 20; 					//初始化變數time
                this.axAnimation1.Play(time, start, end); 	//播放指定的幀數
            }
            catch
            {
                MessageBox.Show("請輸入正確幀數！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.axAnimation1.Play();//播放多媒體文件
        }
    }
}