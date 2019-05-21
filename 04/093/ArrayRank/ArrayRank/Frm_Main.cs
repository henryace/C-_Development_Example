using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArrayRank
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private string[,] G_str_array;//定義陣列類型變數

        private Random G_Random_Num = new Random();//產生隨機數物件

        private void btn_GetArray_Click(object sender, EventArgs e)
        {
            txt_display.Clear();//清空控制元件中的字串
            G_str_array = new string[//隨機產生二維陣列
                G_Random_Num.Next(2, 10),
                G_Random_Num.Next(2, 10)];
            lab_Message.Text = string.Format(
                "產生了 {0} 行 {1 }列 的陣列",
                G_str_array.GetUpperBound(0) + 1,//取得陣列的行數
                G_str_array.GetUpperBound(1) + 1);//取得陣列的列數
            DisplayArray();//呼叫顯示陣列方法
        }

        private void DisplayArray()
        {
            //使用循環賦值
            for (int i = 0; i < G_str_array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < G_str_array.GetUpperBound(1) + 1; j++)
                {
                    G_str_array[i, j] = i.ToString() + "," + j.ToString() + "  ";
                }
            }

            //使用循環輸出
            for (int i = 0; i < G_str_array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < G_str_array.GetUpperBound(1) + 1; j++)
                {
                    txt_display.Text += G_str_array[i, j];
                }
                txt_display.Text += Environment.NewLine;
            }
        }
    }
}
