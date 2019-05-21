using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SumAndAverage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private List<Fruit> G_Fruit;

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            G_Fruit = new List<Fruit>() {//建立集合併新增元素
            new Fruit(){Name="蘋果",Price=30},
            new Fruit(){Name="橘子",Price=40},
            new Fruit(){Name="鴨梨",Price=33},
            new Fruit(){Name="水蜜桃",Price=31}};
            dgv_Message.Columns.Add("Fruit", "水果");//新增列
            dgv_Message.Columns.Add("Pric", "價格");//新增列
            foreach (Fruit f in G_Fruit)//新增元素
            {
                dgv_Message.Rows.Add(new string[] 
                { 
                    f.Name,
                    f.Price.ToString()
                });
            }
            dgv_Message.Columns[0].Width = 200;//設定列寬度
            dgv_Message.Columns[1].Width = 170;//設定列寬度
            float sum = 0;//定義float類型變數
            G_Fruit.ForEach(
                (pp) =>
                {
                    sum += pp.Price;//求和
                });
            dgv_Message.Rows.Add(new string[] //在新列中顯示平均值及合計訊息
            { 
                "合計： "+sum.ToString()+" 元",
                "平均價格： "+(sum/G_Fruit.Count).ToString()+" 元"
            });
        }
    }
}
