using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FullScreenForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;//設定視窗為無邊框樣式
            this.WindowState = FormWindowState.Maximized;//最大化顯示視窗
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;//設定視窗為有邊框樣式
            this.WindowState = FormWindowState.Normal;//正常顯示視窗
        }
    }
}