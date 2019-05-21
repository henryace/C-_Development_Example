using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BubbleShowForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void clewButton_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = true;//設定提示控制元件可見
            this.notifyIcon1.ShowBalloonTip(1000, "目前時間：", DateTime.Now.ToLocalTime().ToString(), ToolTipIcon.Info);//顯示氣泡提示
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;//設定提示控制元件不可見
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            this.notifyIcon1.ShowBalloonTip(1000, "目前時間：", DateTime.Now.ToLocalTime().ToString(), ToolTipIcon.Info);//顯示氣泡提示
        }
    }
}
