using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PopupForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void display_Click(object sender, EventArgs e)
        {
            Frm_Info.Instance().ShowForm();//顯示視窗
        }

        private void close_Click(object sender, EventArgs e)
        {
            Frm_Info.Instance().CloseForm();//隱藏視窗
        }
    }
}
