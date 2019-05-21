using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoldItem
{
    public partial class Main_Main : Form
    {
        public Main_Main()
        {
            InitializeComponent();
        }

        private void btn_Bold_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem P_ToolStripMenuItem =//得到功能表項
                (ToolStripMenuItem)menus_Bold.Items[0];
            foreach (ToolStripItem item in //深度搜尋功能表項集合
                P_ToolStripMenuItem.DropDownItems)
            {
                item.Font = //設定功能表項字體
                    new Font(new Font("細明體", 9), FontStyle.Bold);
            }
        }

        private void 打開OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//彈出消息對框
                "點擊\"打開\"項", "提示！");
        }

        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//彈出消息對框
                "退出應用程式", "提示！");
            this.Close();//關閉主視窗
        }

    }
}
