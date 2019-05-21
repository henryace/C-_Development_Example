using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FastSort
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private int[] G_int_value;//定義陣列欄位

        private Random G_Random = new Random();//建立隨機數物件

        //交換資料
        private void swap(ref int l, ref int r)
        {
            int temp;//臨時值
            temp = l;//記錄前一個值
            l = r;//記錄後一個值
            r = temp;//前後交換資料
        }

        private void Sort(int[] list, int low, int high)
        {
            int pivot;//臨時變數，用來存儲最大值
            int l, r;//分別用來記錄深度搜尋到的索引和最大索引
            int mid;//中間索引
            if (high <= low)//判斷輸入的值是否合法
                return;
            else if (high == low + 1)//判斷兩個索引是否相鄰
            {
                if (list[low] > list[high])//判斷前面的值是否大於後面的值
                    swap(ref list[low], ref list[high]);//交換前後索引的值
                return;
            }
            mid = (low + high) >> 1;//記錄陣列的中間索引
            pivot = list[mid];//初始化臨時變數的值
            swap(ref list[low], ref list[mid]);//交換第一個值和中間值的索引順序
            l = low + 1;//記錄深度搜尋到的索引值
            r = high;//記錄最大索引
            try
            {
                //使用do...while循環深度搜尋陣列，並比較前後值的大小
                do
                {

                    while (l <= r && list[l] < pivot)//判斷深度搜尋到的索引是否小於最大索引
                        l++;//索引值加1
                    while (list[r] >= pivot)//判斷最大值是否大於等於記錄的分支點
                        r--;//做大索引值減1
                    if (l < r)//如果目前深度搜尋到的值小於最大值
                        swap(ref list[l], ref list[r]);//交換順序

                } while (l < r);
                list[low] = list[r];//在最小索引處記錄最小值
                list[r] = pivot;//在最大索引處記錄最大值
                if (low + 1 < r)//判斷最小索引是否小於最大索引
                    Sort(list, low, r - 1);//呼叫自身進行快速排序
                if (r + 1 < high)//判斷最大索引是否小於陣列長度
                    Sort(list, r + 1, high);//呼叫自身進行快速排序
            }
            catch { }
        }

        private void btn_sort_Click(object sender, EventArgs e)
        {
            if (G_int_value != null)
            {
                Sort(G_int_value, 0, G_int_value.Length - 1);//使用快速排序法對陣列進行排序
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
