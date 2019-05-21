using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemoveSameNum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string P_str_Arr = lab_Array.Text.Remove(0, 5);//記錄初始字串
            string[] P_str_Arrs = P_str_Arr.Split(',');//對字串進行分割
            int[] P_int_Arrs = new int[P_str_Arrs.Length];//定義一個一維陣列
            //為int類型的一維陣列進行賦值
            for (int i = 0; i < P_str_Arrs.Length; i++)
                P_int_Arrs[i] = Convert.ToInt32(P_str_Arrs[i]);
            //定義兩個int類型的變數，分別用來表示陣列下標和存儲新的陣列元素
            int P_int_Index, P_int_Temp;
            for (int i = 0; i < P_int_Arrs.Length - 1; i++)//根據陣列下標的值深度搜尋陣列元素
            {
                P_int_Index = i + 1;
            id://定義一個標識，以便從這裡開始執行語句
                if (P_int_Arrs[i] > P_int_Arrs[P_int_Index])//判斷前後兩個數的大小
                {
                    P_int_Temp = P_int_Arrs[i];//將比較後大的元素賦值給定義的int變數
                    P_int_Arrs[i] = P_int_Arrs[P_int_Index];//將後一個元素的值賦值給前一個元素
                    P_int_Arrs[P_int_Index] = P_int_Temp;//將int變數中存儲的元素值賦值給後一個元素
                    goto id;//返回標識，繼續判斷後面的元素
                }
                else
                    if (P_int_Index < P_int_Arrs.Length - 1)//判斷是否執行到最後一個元素
                    {
                        P_int_Index++;//如果沒有，則再往後判斷
                        goto id;//返回標識，繼續判斷後面的元素
                    }
            }
            int[] P_int_newArrs = RemoveNum(P_int_Arrs);//去掉重複數字
            lab_NArray.Text = "去掉重複數字之後的陣列：\n       ";
            foreach (int P_int_NIndex in P_int_newArrs)//循環深度搜尋排序後的陣列元素並輸出
                lab_NArray.Text += P_int_NIndex + " ";
        }

        #region 去掉陣列中的重複數字
        /// <summary>
        /// 去掉陣列中的重複數字
        /// </summary>
        /// <param name="P_int_Data">要去除重複數字的int陣列</param>
        /// <returns>取出重複數字之後的陣列</returns>
        static int[] RemoveNum(int[] P_int_Data)
        {
            List<int> P_list_Arrs = new List<int>();//實例化泛型集合
            for (int i = 0; i < P_int_Data.Length - 1; i++)//循環訪問源陣列元素
            {
                if (P_int_Data[i] != P_int_Data[i + 1])//判斷相鄰的值是否相同
                {
                    P_list_Arrs.Add(P_int_Data[i]);//如果不同，將值新增到泛型集合中
                }
            }
            P_list_Arrs.Add(P_int_Data[P_int_Data.Length - 1]);//將陣列的最後一個元素新增到泛型集合中
            return P_list_Arrs.ToArray();//將泛型集合轉換為陣列，並返回
        }
        #endregion
    }
}
