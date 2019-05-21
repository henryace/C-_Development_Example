using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MoveFontInForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)//用Timer來控制滾動速度
        {
            label1.Left -= 2;//設定label1左邊緣與其容器的工作區左邊緣之間的距離
            if (label1.Right < 0)//當label1右邊緣與其容器的工作區左邊緣之間的距離小於0時
            {
                label1.Left = this.Width;//設定label1左邊緣與其容器的工作區左邊緣之間的距離為該視窗的寬度
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;//開始滾動
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;//停止滾動
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();//關閉視窗
        }
    }
}