using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ButtonShortCut
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//彈出消息對話框
              "點擊了確定！", "提示！");
        }
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//彈出消息對話框
             "點擊了退出！", "提示！");
        }
    }
}
