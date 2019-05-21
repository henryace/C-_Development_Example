using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisableMenuItem
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Enable_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem P_ToolStripMenuItem =//得到功能表項
                (ToolStripMenuItem)menus_Main.Items[0];
            foreach (ToolStripMenuItem item in
                P_ToolStripMenuItem.DropDownItems)
            {
                item.Enabled = true;//啟用功能表項
            }
        }

        private void btn_Disable_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem P_ToolStripMenuItem =//得到功能表項
    (ToolStripMenuItem)menus_Main.Items[0];
            foreach (ToolStripMenuItem item in
                P_ToolStripMenuItem.DropDownItems)
            {
                item.Enabled = false;//停用功能表項
            }
        }

        private void 打開OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//彈出消息對話框
                "點擊\"打開\"按鈕", "提示！");
        }

        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//彈出消息對話框
                "退出應用程式", "提示！");
            this.Close();//關閉主視窗
        }
    }
}
