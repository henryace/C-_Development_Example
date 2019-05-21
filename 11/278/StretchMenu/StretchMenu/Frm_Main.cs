using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StretchMenu
{
    public partial class Frm_Main : Form
    {
        bool G_bl = true;//設定布爾欄位用於展開縮進功能表項
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.設定密碼ToolStripMenuItem.Visible = false;//隱藏功能表項
            this.新增用戶ToolStripMenuItem.Visible = false;//隱藏功能表項
            this.忘記密碼ToolStripMenuItem.Visible = false;//隱藏功能表項
            this.修改密碼ToolStripMenuItem.Visible = false;//隱藏功能表項
            this.員工錄入ToolStripMenuItem.Visible = false;//隱藏功能表項
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            switch (G_bl)
            {
                case false:
                    this.設定密碼ToolStripMenuItem.Visible = false;//隱藏功能表項
                    this.新增用戶ToolStripMenuItem.Visible = false;//隱藏功能表項
                    this.忘記密碼ToolStripMenuItem.Visible = false;//隱藏功能表項
                    this.修改密碼ToolStripMenuItem.Visible = false;//隱藏功能表項
                    this.員工錄入ToolStripMenuItem.Visible = false;//隱藏功能表項
                    G_bl = true;//設定布林值
                    操作ToolStripMenuItem.ShowDropDown();//顯示功能表項
                    break;
                case true:
                    this.設定密碼ToolStripMenuItem.Visible = true;//顯示功能表項
                    this.新增用戶ToolStripMenuItem.Visible = true;//顯示功能表項
                    this.忘記密碼ToolStripMenuItem.Visible = true;//顯示功能表項
                    this.修改密碼ToolStripMenuItem.Visible = true;//顯示功能表項
                    this.員工錄入ToolStripMenuItem.Visible = true;//顯示功能表項
                    G_bl = false;//設定布林值
                    this.操作ToolStripMenuItem.ShowDropDown();//顯示功能表項
                    break;
            }
        }
    }
}