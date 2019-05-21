using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChangeColor
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.DataSource = new List<Fruit>() {//對應資料集合
            new Fruit(){Name="蘋果",Price=30},
            new Fruit(){Name="橘子",Price=40},
            new Fruit(){Name="鴨梨",Price=33},
            new Fruit(){Name="水蜜桃",Price=31}};
            dgv_Message.Columns[0].Width = 200;//設定列寬度
            dgv_Message.Columns[1].Width = 170;//設定列寬度

            dgv_Message.SelectionMode = //設定如何選擇儲存格
                DataGridViewSelectionMode.FullRowSelect;
            dgv_Message.DefaultCellStyle.SelectionForeColor//選中儲存格的前景色
                = Color.Blue;
            dgv_Message.DefaultCellStyle.SelectionBackColor//選中儲存格的背景色
                = Color.LightYellow;
        }
    }
}
