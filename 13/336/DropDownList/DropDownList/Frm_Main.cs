using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DropDownList
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn dgvc =//建立列物件
                new DataGridViewComboBoxColumn();
            dgvc.Items.Add("蘋果");//向集合中新增元素
            dgvc.Items.Add("芒果");//向集合中新增元素
            dgvc.Items.Add("鴨梨");//向集合中新增元素
            dgvc.Items.Add("橘子");//向集合中新增元素
            dgvc.HeaderText = "水果";//設定列標題文字
            dgv_Message.Columns.Add(dgvc);//將列新增到集合
        }
    }
}
