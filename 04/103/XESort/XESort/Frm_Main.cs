using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XESort
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private int[] G_int_value;//定義陣列欄位

        private Random G_Random = new Random();//建立隨機數物件

        private void btn_sort_Click(object sender, EventArgs e)
        {
            if (G_int_value != null)
            {
                int inc;//定義一個int變數，用來確定每個有序序列的個數
                for (inc = 1; inc <= G_int_value.Length / 9; inc = 3 * inc + 1) ;//為有序序列賦值
                for (; inc > 0; inc /= 3)
                {
                    for (int i = inc + 1; i <= G_int_value.Length; i += inc)
                    {
                        int t = G_int_value[i - 1];//記錄目前值
                        int j = i;//定義下一個索引
                        while ((j > inc) && (G_int_value[j - inc - 1] > t))
                        {
                            G_int_value[j - 1] = G_int_value[j - inc - 1];//交換資料
                            j -= inc;
                        }
                        G_int_value[j - 1] = t;//將下一個元素值設定為目前值
                    }
                }
                txt_str2.Clear();//清空控制元件內字串
                foreach (int i in G_int_value)//深度搜尋字串集合
                {
                    txt_str2.Text += i.ToString() + ", ";//向控制元件內新增字串
                }
            }
            else
            {
                MessageBox.Show("首先應當產生陣列，然後再進行排序。", "提示！");
            }
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            G_int_value = new int[G_Random.Next(10, 20)];//產生隨機長度陣列
            for (int i = 0; i < G_int_value.Length; i++)//深度搜尋陣列
            {
                G_int_value[i] = G_Random.Next(0, 100);//為陣列賦隨機數值
            }
            txt_str.Clear();//清空控制元件內字串
            foreach (int i in G_int_value)//深度搜尋字串集合
            {
                txt_str.Text += i.ToString() + ", ";//向控制元件內新增字串

            }
        }
    }
}
