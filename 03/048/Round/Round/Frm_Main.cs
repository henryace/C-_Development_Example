using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Round
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            double P_dbl_d1, P_dbl_d2;//定義兩個double類型變數
            if (double.TryParse(txt_add1.Text, out P_dbl_d1) &&//判斷輸入訊息是否正確
                double.TryParse(txt_add2.Text, out P_dbl_d2))
            {
                txt_add3.Text = //得到四捨五入後的值
                    Round(P_dbl_d1 + P_dbl_d2, cbox_select.SelectedIndex + 1).ToString();
            }
            else
            {
                MessageBox.Show(//提示錯誤訊息
                    "輸入數值不正確！", "提示！");
            }
        }

        /// <summary>
        /// 計算double值四捨五入的方法
        /// </summary>
        /// <param name="dbl">進行四捨五入的數值</param>
        /// <param name="i">保留的小數位</param>
        /// <returns>返回四捨五入後的double值</returns>
        internal double Round(double dbl, int i)
        {
            string P_str_dbl = dbl.ToString();//將double數值轉換為字串
            string P_str_lower = //將double數值小數位轉換為字串
                P_str_dbl.Split('.')[1];
            int P_str_length = P_str_lower.Length;//計算double數值小數位長度
            dbl += GetValue(i, P_str_length);//開始進行四捨五入運算
            P_str_dbl = dbl.ToString();//將運算後的值轉換為字串
            if (P_str_dbl.Contains("."))//判斷是否存在小數位
            {
                string P_str_upper = //得到整數位字串
                    P_str_dbl.Split('.')[0];
                P_str_lower = P_str_dbl.Split('.')[1];//得到小數位字串
                if (P_str_lower.Length > i)//判斷數值位數是否大於保留小數位數
                {
                    P_str_lower = P_str_lower.Substring(//截取保留的小數位
                        0, i);
                    return double.Parse(//返回double數值
                        P_str_upper + "." + P_str_lower);
                }
                else
                {
                    return double.Parse(P_str_dbl);//如數值位數小於保留小數位數則直接返回
                }
            }
            else
            {
                return double.Parse(P_str_dbl);//如果沒有小數位則直接返回值
            }
        }

        /// <summary>
        /// 得到小數數值的方法
        /// </summary>
        /// <param name="int_null">四捨五入保留的位數</param>
        /// <param name="length">四捨五入丟失的位數</param>
        /// <returns>返回小數值用於四捨五入計算</returns>
        internal double GetValue(int int_null, int length)
        {
            string P_str_dbl = "0.";//定義字串變數並賦值
            for (int i = 0; i < length; i++)//使用for循環新增小數位
            {
                if (i > int_null - 1)
                {
                    P_str_dbl += "5";//向小數的四捨五入部分加5
                }
                else
                {
                    P_str_dbl += "0";//向小數的保留部分加0
                }
            }
            return double.Parse(P_str_dbl);//返回小數數值
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cbox_select.SelectedIndex = 0;//cbox_select控制元件默認選擇第一項
        }
    }
}
