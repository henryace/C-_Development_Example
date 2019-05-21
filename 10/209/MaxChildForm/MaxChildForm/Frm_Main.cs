using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MaxChildForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Child frm = new Frm_Child();//實例化子視窗物件
            frm.MdiParent = this;//設定子視窗的父視窗為目前視窗
            frm.WindowState = FormWindowState.Maximized;//設定子視窗最大化顯示
            frm.Show();//顯示子視窗
        }
    }
}