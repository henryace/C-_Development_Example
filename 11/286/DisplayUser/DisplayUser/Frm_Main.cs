using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DisplayUser
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public string user = string.Empty;

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Login P_l = new Login();//建立視窗物件
            P_l.Owner = this;//設定owner屬性
            P_l.ShowDialog();//顯示視窗
            toolStripStatusLabel1.Text = "登入用戶： " + user;//設定用戶登入訊息
        }
    }
}