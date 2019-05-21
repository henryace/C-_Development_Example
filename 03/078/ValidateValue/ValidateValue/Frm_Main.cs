using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateValue
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsNumber(textBox1.Text.Trim()))//驗證輸入是否為數字
            { MessageBox.Show("只充許輸入數字!!!", "提示"); }//彈出消息對話框
            else { MessageBox.Show("輸入訊息正確!!!!!", "提示"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證輸入是否為數字
        /// </summary>
        /// <param name="str_number">用戶輸入的字串</param>
        /// <returns>方法返回布爾值</returns>
        public bool IsNumber(string str_number)
        {
            return System.Text.RegularExpressions.Regex.//使用正則表達式判斷是否匹配
                IsMatch(str_number, @"^[0-9]*$");
        }
    }
}