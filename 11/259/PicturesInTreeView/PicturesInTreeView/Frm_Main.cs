using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PicturesInTreeView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            treeView1.ImageList = imageList1;//繫結ImageList控制元件
            TreeNode tr = new TreeNode("公司職員", 0, 1);
            tr.Nodes.Add("", "小張", 0, 1);
            tr.Nodes.Add("", "小王", 0, 1);
            tr.Nodes.Add("", "小李", 0, 1);
            tr.Nodes.Add("", "小劉", 0, 1);
            tr.Nodes.Add("", "小孰", 0, 1);
            tr.Nodes.Add("", "小趙", 0, 1);
            tr.Nodes.Add("", "小懂", 0, 1);
            tr.Nodes.Add("", "小高", 0, 1);
            treeView1.Nodes.Add(tr);
            treeView1.ExpandAll();
        }
    }
}