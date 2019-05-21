using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判斷數值是符合規定
            {
                if (G_bl_add)//判斷是否剛剛按下+號鍵
                {
                    txt_value.Clear();//清空數字
                    G_bl_add = false;//剛剛按下數字鍵
                }
                txt_value.Text += "0";//輸入數字0
                G_bl_key = false;//打開+號鍵開關
            }
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判斷數值是符合規定
            {
                if (G_bl_add)//判斷是否剛剛按下+號鍵
                {
                    txt_value.Clear();//清空數字
                    G_bl_add = false;//剛剛按下數字鍵
                }
                txt_value.Text += "1";//輸入數字0
                G_bl_key = false;//打開+號鍵開關
            }
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判斷數值是符合規定
            {
                if (G_bl_add)//判斷是否剛剛按下+號鍵
                {
                    txt_value.Clear();//清空數字
                    G_bl_add = false;//剛剛按下數字鍵
                }
                txt_value.Text += "2";//輸入數字0
                G_bl_key = false;//打開+號鍵開關
            }
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判斷數值是符合規定
            {
                if (G_bl_add)//判斷是否剛剛按下+號鍵
                {
                    txt_value.Clear();//清空數字
                    G_bl_add = false;//剛剛按下數字鍵
                }
                txt_value.Text += "3";//輸入數字0
                G_bl_key = false;//打開+號鍵開關
            }
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判斷數值是符合規定
            {
                if (G_bl_add)//判斷是否剛剛按下+號鍵
                {
                    txt_value.Clear();//清空數字
                    G_bl_add = false;//剛剛按下數字鍵
                }
                txt_value.Text += "4";//輸入數字0
                G_bl_key = false;//打開+號鍵開關
            }
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判斷數值是符合規定
            {
                if (G_bl_add)//判斷是否剛剛按下+號鍵
                {
                    txt_value.Clear();//清空數字
                    G_bl_add = false;//剛剛按下數字鍵
                }
                txt_value.Text += "5";//輸入數字0
                G_bl_key = false;//打開+號鍵開關
            }
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判斷數值是符合規定
            {
                if (G_bl_add)//判斷是否剛剛按下+號鍵
                {
                    txt_value.Clear();//清空數字
                    G_bl_add = false;//剛剛按下數字鍵
                }
                txt_value.Text += "6";//輸入數字0
                G_bl_key = false;//打開+號鍵開關
            }
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判斷數值是符合規定
            {
                if (G_bl_add)//判斷是否剛剛按下+號鍵
                {
                    txt_value.Clear();//清空數字
                    G_bl_add = false;//剛剛按下數字鍵
                }
                txt_value.Text += "7";//輸入數字0
                G_bl_key = false;//打開+號鍵開關
            }
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判斷數值是符合規定
            {
                if (G_bl_add)//判斷是否剛剛按下+號鍵
                {
                    txt_value.Clear();//清空數字
                    G_bl_add = false;//剛剛按下數字鍵
                }
                txt_value.Text += "8";//輸入數字0
                G_bl_key = false;//打開+號鍵開關
            }
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判斷數值是符合規定
            {
                if (G_bl_add)//判斷是否剛剛按下+號鍵
                {
                    txt_value.Clear();//清空數字
                    G_bl_add = false;//剛剛按下數字鍵
                }
                txt_value.Text += "9";//輸入數字0
                G_bl_key = false;//打開+號鍵開關
            }
        }

        private List<double> G_list_value = //記錄累加數值
            new List<double>();

        private bool G_bl_add = false;//判斷是否剛剛按下+號

        private bool G_bl_value = false;//判斷是否剛剛按下=號

        private bool G_bl_key = false;//防止連續按+號

        private void btn_clear_Click(object sender, EventArgs e)
        {
            G_list_value.Clear();//清空集合中數值
            lb_express.Text = GetString();//清空計算表達式
            txt_value.Clear();//清空累加結果
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (G_bl_value)//判斷是否剛剛按下=號
            {
                G_bl_value = false;//設定剛剛按下的不是=號
                G_bl_key = true;//設定剛剛按下的是加號
            }
            else
            {
                if (!G_bl_key)//判斷是否連續按+號
                {
                    G_list_value.Add(//向集合中新增累加的數值
                        double.Parse(txt_value.Text));
                    GetValue();//計算累加數值並輸出
                    lb_express.Text = GetString();//得到數值的字符串表示
                    G_bl_add = true;//設定已經按下+號
                    G_bl_key = true;//防止多次按下+號
                }
            }
        }

        private void btn_num_Click(object sender, EventArgs e)
        {
            if (!G_bl_key)//判斷是否連續按下+號
            {
                if (!G_bl_value)//判斷是否剛剛按下=號
                {
                    G_list_value.Add(//向集合中新增累加的數值
                        double.Parse(txt_value.Text));
                    GetValue();//計算累加數值並輸出
                    lb_express.Text = GetString();//得到數值的字符串表示
                    G_bl_add = true;//設定已經按下+號
                    G_bl_value = true;//設定已經按下=號
                }
            }
        }

        /// <summary>
        /// 方法用於計算累加數值並輸出
        /// </summary>
        void GetValue()
        {
            double P_dbl_temp = 0;//定義局部變數
            foreach (double d in G_list_value)//遍歷集合
            {
                P_dbl_temp += d;//計算累加結果
            }
            txt_value.Text = P_dbl_temp.ToString();//顯示累加結果
        }

        /// <summary>
        /// 方法用於得到數值的字符串表示
        /// </summary>
        /// <returns>返回字符串數值</returns>
        string GetString()
        {
            string P_str_temp = string.Empty;//定義局部變數
            for (int i = 0; i < G_list_value.Count; i++)//遍歷集合
            {
                if (i != 0)//判斷是否是第一個數值
                {
                    P_str_temp += //產生字符串
                        "+" + G_list_value[i].ToString();
                }
                else
                {
                    P_str_temp = //產生字符串
                        G_list_value[i].ToString();
                }
            }
            return P_str_temp;//返回字符串
        }
    }
}
