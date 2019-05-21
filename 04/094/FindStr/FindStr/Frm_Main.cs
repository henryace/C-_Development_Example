using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FindStr
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private string[] G_str_array;//定義字串陣列欄位

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            G_str_array = new string[] {//為字串陣列欄位賦值
            "明日科技","C#編程詞典","C#範例大全","C#範例寶典"};
            for (int i = 0; i < G_str_array.Length; i++)//循環輸出字串
            {
                lab_Message.Text += G_str_array[i] + "\n";
            }
        }

        private void txt_find_TextChanged(object sender, EventArgs e)
        {
            if (txt_find.Text != string.Empty)//判斷搜尋字串是否為空
            {
                string[] P_str_temp = Array.FindAll//使用FindAll方法搜尋相應字串
                    (G_str_array, (s) => s.Contains(txt_find.Text));
                if (P_str_temp.Length > 0)//判斷是否搜尋到相應字串
                {
                    txt_display.Clear();//清空控制元件中的字串
                    foreach (string s in P_str_temp)//向控制元件中新增字串
                    {
                        txt_display.Text += s + Environment.NewLine;
                    }
                }
                else
                {
                    txt_display.Clear();//清空控制元件中的字串
                    txt_display.Text = "沒有找到記錄";//提示沒有找到記錄
                }
            }
            else
            {
                txt_display.Clear();//清空控制元件中的字串
            }
        }
    }
}
