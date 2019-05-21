using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateSmallLetter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsUpChar(textBox1.Text.Trim()))//驗證輸入字符是否為小寫字母
            { MessageBox.Show("只充許輸入小寫字母!!!", "提示"); }//彈出消息對話框
            else { MessageBox.Show("輸入訊息正確!!!!!", "提示"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證輸入字符是否為小寫字母
        /// </summary>
        /// <param name="str_UpChar">用戶輸入的字串</param>
        /// <returns>方法返回布林值</returns>
        public bool IsUpChar(string str_UpChar)
        {
            return System.Text.RegularExpressions.Regex.//使用正規化運算式判斷是否匹配
                IsMatch(str_UpChar, @"^[a-z]+$");
        }
    }
}