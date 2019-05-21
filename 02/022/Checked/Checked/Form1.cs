using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Checked
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            byte bt_One, bt_Two;//定義兩個byte類型變數
            if (byte.TryParse(//對兩個byte類型變數賦值
                txt_Add_One.Text, out bt_One)
                && byte.TryParse(txt_Add_Two.Text, out bt_Two))
            {
                try
                {
                    checked { bt_One += bt_Two; }//使用checke關鍵字判斷是否有溢出
                    txt_Result.Text = bt_One.ToString();//輸出相加後的結果
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show(ex.Message, "出錯！");//輸出異常訊息
                }
            }
            else
            {
                MessageBox.Show("請輸入255以內的數字!");//輸出錯誤訊息
            }
        }
    }
}
