using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShortCutInMenu
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("退出應用程式", "提示！");
            Close();//退出應用程式
        }

        private void 打開OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("已經點擊\"打開\"功能表項", "提示！");
        }
    }
}
