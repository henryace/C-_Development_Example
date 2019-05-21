using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DriftTool
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            ToolStripPanel tsp_Top = new ToolStripPanel();//建立ToolStripPanel物件
            ToolStripPanel tsp_Bottom = new ToolStripPanel();//建立ToolStripPanel物件
            ToolStripPanel tsp_Left = new ToolStripPanel();//建立ToolStripPanel物件
            ToolStripPanel tsp_right = new ToolStripPanel();//建立ToolStripPanel物件
            tsp_Top.Dock = DockStyle.Top;//設定停靠方式
            tsp_Bottom.Dock = DockStyle.Bottom;//設定停靠方式
            tsp_Left.Dock = DockStyle.Left;//設定停靠方式
            tsp_right.Dock = DockStyle.Right;//設定停靠方式
            Controls.Add(tsp_Top);//新增到控制元件集合
            Controls.Add(tsp_Bottom);//新增到控制元件集合
            Controls.Add(tsp_Left);//新增到控制元件集合
            Controls.Add(tsp_right);//新增到控制元件集合
            tsp_Bottom.Join(toolStrip1);//將指定的工具欄新增到面板
        }
    }
}
