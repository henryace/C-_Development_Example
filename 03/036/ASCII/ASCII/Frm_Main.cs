using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASCII
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_ToASCII_Click(object sender, EventArgs e)
        {
            if (txt_char.Text != string.Empty)//判斷輸入是否為空
            {
                if (Encoding.GetEncoding("unicode").//判斷輸入是否為字母
                    GetBytes(new char[] { txt_char.Text[0] })[1] == 0)
                {
                    txt_ASCII.Text = Encoding.GetEncoding(//得到字符的ASCII碼值
                        "unicode").GetBytes(txt_char.Text)[0].ToString();
                }
                else
                {
                    txt_ASCII.Text = string.Empty;//輸出空字串
                    MessageBox.Show("請輸入字母！", "提示！");//提示用戶訊息
                }
            }
        }
        private void btn_ToChar_Click(object sender, EventArgs e)
        {
            if (txt_ASCII2.Text != string.Empty)//判斷輸入是否為空
            {
                int P_int_Num;//定義整型局部變數
                if (int.TryParse(//將輸入的字符轉換為數字
                    txt_ASCII2.Text, out P_int_Num))
                {
                    txt_Char2.Text =
                        ((char)P_int_Num).ToString();//將ASCII碼轉換為字符
                }
                else
                {
                    MessageBox.Show(//如果輸入不符合要求彈出提示框
                        "請輸入正確ASCII碼值。", "錯誤！");
                }
            }
            string P_str_temp = "abc";
            string P_str = Encoding.GetEncoding("unicode").GetBytes(new char[] { P_str_temp[0] })[0].ToString();
        }
    }
}
