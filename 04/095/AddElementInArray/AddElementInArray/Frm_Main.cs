using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddElementInArray
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private int[] G_int_array = new int[8];//定義陣列類型變數
        /// <summary>
        /// 增加單個陣列元素
        /// </summary>
        /// <param name="ArrayBorn">要向其中新增元素的一維陣列</param>
        /// <param name="Index">新增索引</param>
        /// <param name="Value">新增值</param>
        /// <returns></returns>
        static int[] AddArray(int[] ArrayBorn, int Index, int Value)
        {
            if (Index >= (ArrayBorn.Length))//判斷新增索引是否大於陣列的長度
                Index = ArrayBorn.Length - 1;//將新增索引設定為陣列的最大索引
            int[] TemArray = new int[ArrayBorn.Length + 1];//聲明一個新的陣列
            for (int i = 0; i < TemArray.Length; i++)//深度搜尋新陣列的元素
            {
                if (Index >= 0)//判斷新增索引是否大於等於0
                {
                    if (i < (Index + 1))//判斷深度搜尋到的索引是否小於新增索引加1
                        TemArray[i] = ArrayBorn[i];//交換元素值
                    else if (i == (Index + 1))//判斷深度搜尋到的索引是否等於新增索引加1
                        TemArray[i] = Value;//為深度搜尋到的索引設定新增值
                    else
                        TemArray[i] = ArrayBorn[i - 1];//交換元素值
                }
                else
                {
                    if (i == 0)//判斷深度搜尋到的索引是否為0
                        TemArray[i] = Value;//為深度搜尋到的索引設定新增值
                    else
                        TemArray[i] = ArrayBorn[i - 1];//交換元素值
                }
            }
            return TemArray;//返回插入元素後的新陣列
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
            G_int_array = AddArray(G_int_array, 4, Convert.ToInt32(txt_Element.Text));//呼叫自定義方法向陣列中插入單個元素
            //使用循環輸出
            for (int i = 0; i < G_int_array.GetUpperBound(0) + 1; i++)
            {
                rtbox_NArray.Text += G_int_array[i] + " ";
            }
        }
    }
}
