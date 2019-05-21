using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AmalgamateMenu
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void 打開自視窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();//建立視窗物件
            f.MdiParent = this;//設定父視窗屬性
            f.Show();//顯示視窗
            f.Resize += //為視窗新增事件
                new EventHandler(f_Resize);
        }

        void f_Resize(object sender, EventArgs e)
        {
            Form2 f = (Form2)sender;//得到視窗物件
            ToolStripMenuItem item = new ToolStripMenuItem();//建立功能表項
            for (int i = 0; i < f.contextMenuStrip2.Items.Count; )//深度搜尋視窗功能表項集合
            {
                item.DropDownItems.Add(//新增功能表項
                    f.contextMenuStrip2.Items[i]);
            }
            this.contextMenuStrip1.Items.AddRange(//向主視窗中新增功能表項集合
                new System.Windows.Forms.ToolStripItem[] {
            item});
        }
    }
}