using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDIVerticalSort
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void 載入子視窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ChildOne frm2 = new Frm_ChildOne();//實例化Frm_ChildOne
            frm2.MdiParent = this;//設定MdiParent屬性，將目前視窗作為父視窗
            frm2.Show();//使用Show方法打開視窗
            Frm_ChildTwo frm3 = new Frm_ChildTwo();//實例化Frm_ChildTwo
            frm3.MdiParent = this;//設定MdiParent屬性，將目前視窗作為父視窗
            frm3.Show();//使用Show方法打開視窗
            Frm_ChildThree frm4 = new Frm_ChildThree();//實例化Frm_ChildThree
            frm4.MdiParent = this;//設定MdiParent屬性，將目前視窗作為父視窗
            frm4.Show();//使用Show方法打開視窗
        }

        private void 垂直排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);//使用MdiLayout枚舉實現視窗的垂直排列
        }
    }
}
