using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SetFormSizeByDeskSize
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;//取得桌面寬度
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;//取得桌面高度
            this.Width = Convert.ToInt32(DeskWidth * 0.8);//設定視窗寬度
            this.Height = Convert.ToInt32(DeskHeight * 0.8);//設定視窗高度
        }
    }
}