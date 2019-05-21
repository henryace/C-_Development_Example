using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Encrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            int P_int_Num, P_int_Key;//定義兩個值類型變數
            if (int.TryParse(txt_Num.Text, out P_int_Num)//判斷輸入是否是數值
                && int.TryParse(txt_Key.Text, out P_int_Key))
            {
                txt_Encrypt.Text = (P_int_Num ^ P_int_Key).ToString();//加密數值
            }
            else
            {
                MessageBox.Show("請輸入數值", "出現錯誤！");//提示輸入訊息不正確
            }
        }

        private void btn_Revert_Click(object sender, EventArgs e)
        {
            int P_int_Key, P_int_Encrypt;//定義兩個值類型變數
            if (int.TryParse(txt_Encrypt.Text, out P_int_Key)//判斷輸入是否是數值
                && int.TryParse(txt_Key.Text, out P_int_Encrypt))
            {
                txt_Revert.Text = (P_int_Encrypt ^ P_int_Key).ToString();//解密數值
            }
            else
            {
                MessageBox.Show("請輸入數值", "出現錯誤！");//提示輸入訊息不正確
            }
        }
    }
}
