using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelectSort
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
                int min;//定義一個int變數，用來存儲陣列下標
                for (int i = 0; i < G_int_value.Length - 1; i++)//循環訪問陣列中的元素值（除最後一個）
                {
                    min = i;//為定義的陣列下標賦值
                    for (int j = i + 1; j < G_int_value.Length; j++)//循環訪問陣列中的元素值（除第一個）
                    {
                        if (G_int_value[j] < G_int_value[min])//判斷相鄰兩個元素值的大小
                            min = j;
                    }
                    int t = G_int_value[min];//定義一個int變數，用來存儲比較大的陣列元素值
                    G_int_value[min] = G_int_value[i];//將小的陣列元素值移動到前一位
                    G_int_value[i] = t;//將int變數中存儲的較大的陣列元素值向後移
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
