using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoAddAndRemoveLine
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.Columns.Add("Name", "名稱");//向控制元件中新增列
            dgv_Message.Columns.Add("Price", "價格");//向控制元件中新增列
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            dgv_Message.AllowUserToAddRows = false;//禁止新增行
            dgv_Message.AllowUserToDeleteRows = false;//禁止刪除行
            dgv_Message.ReadOnly = true;//設定單元格為不可編輯
        }

    }
}
