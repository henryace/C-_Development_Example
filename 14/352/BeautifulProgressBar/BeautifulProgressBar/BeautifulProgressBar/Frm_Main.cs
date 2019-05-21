using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsControlLibrary;

namespace BeautifulProgressBar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.BeautifulProgressBar1.Value > 0) //當BeautifulProgressBar1控制元件的目前值大於0時
            {
                this.BeautifulProgressBar1.Value--;//設定BeautifulProgressBar1控制元件的目前值遞減
                this.BeautifulProgressBar2.Value++;//設定BeautifulProgressBar2控制元件的目前值遞增
            }
            else//當BeautifulProgressBar1控制元件的目前值小於0時
            {
                this.timer1.Enabled = false;//使Timer元件處於不可用狀態
            }
        }

        private void StartOrStop_Click(object sender, EventArgs e)
        {
            this.BeautifulProgressBar1.Value = 100;//設定BeautifulProgressBar1的值為100
            this.BeautifulProgressBar2.Value = 0;//設定BeautifulProgressBar2的值為0

            this.timer1.Interval = 1;//設定Timer元件的Tick事件的時間間隔
            this.timer1.Enabled = true;//設定Timer元件為可用狀態
        }
    }
}
