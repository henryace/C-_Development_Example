using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InsertSort
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
                for (int i = 0; i < G_int_value.Length; ++i)//循環訪問陣列中的元素
                {
                    int temp = G_int_value[i];//定義一個int變數，並使用取得的陣列元素值賦值
                    int j = i;
                    while ((j > 0) && (G_int_value[j - 1] > temp))//判斷陣列中的元素是否大於取得的值
                    {
                        G_int_value[j] = G_int_value[j - 1];//如果是，則將後一個元素的值提前
                        --j;
                    }
                    G_int_value[j] = temp;//最後將int變數存儲的值賦值給最後一個元素
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
