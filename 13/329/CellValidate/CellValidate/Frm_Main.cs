using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CellValidate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgv_Message.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)//驗證指定列
            {
                float result = 0;//定義值類型變數並賦值
                if (!float.TryParse(//判斷資料是否為數值類型
                    e.FormattedValue.ToString(), out result))
                {
                    dgv_Message.Rows[e.RowIndex].ErrorText =//提示錯誤訊息
                        "內容必需為數值類型";
                    e.Cancel = true;//取消事件的值
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv_Message.DataSource = new List<Fruit>() {//繫結資料集合
            new Fruit(){Name="蘋果",Price=30},
            new Fruit(){Name="橘子",Price=40},
            new Fruit(){Name="鴨梨",Price=33},
            new Fruit(){Name="水蜜桃",Price=31},
            new Fruit(){Name=""}};
            dgv_Message.Columns[0].Width = 200;//設定列寬度
            dgv_Message.Columns[1].Width = 170;//設定列寬度
            dgv_Message.Columns[0].DefaultCellStyle.Alignment =//設定對齊方式
                DataGridViewContentAlignment.MiddleCenter;
        }

    }
}