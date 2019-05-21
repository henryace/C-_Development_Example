using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridStyle
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.GridColor = Color.Blue;//設定網格顏色
            dgv_Message.DataSource = new List<Student>() {//繫結到資料集合
            new Student(){Name="小明",Age=30},
            new Student(){Name="老張",Age=40},
            new Student(){Name="小李",Age=33},
            new Student(){Name="雲峰",Age=31}};
            dgv_Message.Columns[0].Width = 200;//設定列寬
            dgv_Message.Columns[1].Width = 170;//設定列寬
        }
    }
}
