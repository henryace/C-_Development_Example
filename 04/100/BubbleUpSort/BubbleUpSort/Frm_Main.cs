using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BubbleUpSort
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
                //定義兩個int類型的變數，分別用來表示陣列下標和存儲新的陣列元素
                int j, temp;
                for (int i = 0; i < G_int_value.Length - 1; i++)//根據陣列下標的值深度搜尋陣列元素
                {
                    j = i + 1;
                id://定義一個標識，以便從這裡開始執行語句
                    if (G_int_value[i] > G_int_value[j])//判斷前後兩個數的大小
                    {
                        temp = G_int_value[i];//將比較後大的元素賦值給定義的int變數
                        G_int_value[i] = G_int_value[j];//將後一個元素的值賦值給前一個元素
                        G_int_value[j] = temp;//將int變數中存儲的元素值賦值給後一個元素
                        goto id;//返回標識，繼續判斷後面的元素
                    }
                    else
                        if (j < G_int_value.Length - 1)//判斷是否執行到最後一個元素
                        {
                            j++;//如果沒有，則再往後判斷
                            goto id;//返回標識，繼續判斷後面的元素
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
