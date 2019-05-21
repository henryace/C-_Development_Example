using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DelArrayYesLength
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private int[] G_int_array = new int[8];//定義陣列類型變數
        /// <summary>
        /// 刪除陣列中的元素，並改變陣列的長度
        /// </summary>
        /// <param name="ArrayBorn">要從中刪除元素的陣列</param>
        /// <param name="Index">刪除索引</param>
        /// <param name="Len">刪除的長度</param>
        /// <returns>得到的新陣列</returns>
        static int[] DeleteArray(int[] ArrayBorn, int Index, int Len)
        {
            if (Len <= 0)//判斷刪除長度是否小於等於0
                return ArrayBorn;//返回源陣列
            if (Index == 0 && Len >= ArrayBorn.Length)//判斷刪除長度是否超出了陣列範圍
                Len = ArrayBorn.Length;//將刪除長度設定為陣列的長度
            else if ((Index + Len) >= ArrayBorn.Length)//判斷刪除索引和長度的和是否超出了陣列範圍
                Len = ArrayBorn.Length - Index - 1;//設定刪除的長度
            int[] temArray = new int[ArrayBorn.Length - Len];//聲明一個新的陣列
            for (int i = 0; i < temArray.Length; i++)//深度搜尋新陣列
            {
                if (i >= Index)//判斷深度搜尋索引是否大於等於刪除索引
                    temArray[i] = ArrayBorn[i + Len];//為深度搜尋到的索引元素賦值
                else
                    temArray[i] = ArrayBorn[i];//為深度搜尋到的索引元素賦值
            }
            return temArray;//返回得到的新陣列
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
            G_int_array = DeleteArray(G_int_array, Convert.ToInt32(txt_Index.Text), Convert.ToInt32(txt_Num.Text));//刪除陣列中的元素
            //使用循環輸出刪除元素的陣列
            for (int i = 0; i < G_int_array.GetUpperBound(0) + 1; i++)
            {
                rtbox_NArray.Text += G_int_array[i] + " ";
            }
        }
    }
}
