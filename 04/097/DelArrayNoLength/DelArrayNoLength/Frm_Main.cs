using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DelArrayNoLength
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private int[] G_int_array = new int[8];//定義陣列類型變數
        /// <summary>
        /// 刪除陣列中的元素
        /// </summary>
        /// <param name="ArrayBorn">要從中刪除元素的陣列</param>
        /// <param name="Index">刪除索引</param>
        /// <param name="Len">刪除的長度</param>
        static void DeleteArray(int[] ArrayBorn, int Index, int Len)
        {
            if (Len <= 0)//判斷刪除長度是否小於等於0
                return;//返回
            if (Index == 0 && Len >= ArrayBorn.Length)//判斷刪除長度是否超出了陣列範圍
                Len = ArrayBorn.Length;//將刪除長度設定為陣列的長度
            else if ((Index + Len) >= ArrayBorn.Length)//判斷刪除索引和長度的和是否超出了陣列範圍
                Len = ArrayBorn.Length - Index - 1;//設定刪除的長度
            int i = 0;//定義一個int變數，用來標識開始深度搜尋的位置
            for (i = 0; i < ArrayBorn.Length - Index - Len; i++)//深度搜尋刪除的長度
                ArrayBorn[i + Index] = ArrayBorn[i + Len + Index];//覆蓋要刪除的值
            //深度搜尋刪除長度後面的陣列元素值
            for (int j = (ArrayBorn.Length - 1); j > (ArrayBorn.Length - Len - 1); j--)
                ArrayBorn[j] = 0;//設定陣列為0
        }

        private void btn_RArray_Click(object sender, EventArgs e)
        {
            txt_RArray.Clear();//清空文字框
            //使用循環賦值
            for (int i = 0; i < G_int_array.GetUpperBound(0) + 1; i++)
            {
                G_int_array[i] = i;
            }
            //使用循環輸出
            for (int i = 0; i < G_int_array.GetUpperBound(0) + 1; i++)
            {
                txt_RArray.Text += G_int_array[i] + " ";
            }
        }

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            rtbox_NArray.Clear();//清空文字框
            DeleteArray(G_int_array, Convert.ToInt32(txt_Index.Text), Convert.ToInt32(txt_Num.Text));//刪除陣列中的元素
            //使用循環輸出刪除元素的陣列
            for (int i = 0; i < G_int_array.GetUpperBound(0) + 1; i++)
            {
                rtbox_NArray.Text += G_int_array[i] + " ";
            }
        }
    }
}
