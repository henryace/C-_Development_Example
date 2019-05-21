using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckBoxInDataGridView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private List<Fruit> P_Fruit;

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn dgvc =//建立列物件
                new DataGridViewCheckBoxColumn();
            dgvc.HeaderText = "狀態";//設定列標題文字
            dgv_Message.Columns.Add(dgvc);//新增列
            P_Fruit = new List<Fruit>() {//建立資料集合
            new Fruit(){Name="蘋果",Price=30},
            new Fruit(){Name="橘子",Price=40},
            new Fruit(){Name="鴨梨",Price=33},
            new Fruit(){Name="水蜜桃",Price=31}};
            dgv_Message.DataSource = P_Fruit;//繫結資料集合
            dgv_Message.Columns[0].Width = 50;//設定列寬度
            dgv_Message.Columns[1].Width = 170;//設定列寬度
            dgv_Message.Columns[2].Width = 150;//設定列寬度

        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Message.Rows.Count; i++)//深度搜尋行集合
            {
                if (dgv_Message.Rows[i].Cells[0].Value != null &&
                    dgv_Message.Rows[i].Cells[1].Value != null &&
                    dgv_Message.Rows[i].Cells[2].Value != null)//判斷值是否為空
                {
                    if (Convert.ToBoolean(dgv_Message.Rows[i].//判斷是否選中項
                        Cells[0].Value.ToString()))
                    {
                        P_Fruit.RemoveAll(//標記集合中指定項
                            (pp) =>
                            {
                                if (pp.Name == dgv_Message.Rows[i].Cells[1].Value.ToString() &&
                                    pp.Price == Convert.ToSingle(
                                    dgv_Message.Rows[i].Cells[2].Value.ToString()))
                                    pp.ft = true;//開始標設
                                return false;//不刪除項
                            });
                    }
                }
            }
            P_Fruit.RemoveAll(//刪除集合中指定項
                (pp) =>
                {
                    return pp.ft;
                });
            dgv_Message.DataSource = null;//繫結為空
            dgv_Message.DataSource = P_Fruit;//繫結到資料集合
            dgv_Message.Columns[0].Width = 50;//設定列寬度
            dgv_Message.Columns[1].Width = 170;//設定列寬度
            dgv_Message.Columns[2].Width = 150;//設定列寬度
        }
    }
}
