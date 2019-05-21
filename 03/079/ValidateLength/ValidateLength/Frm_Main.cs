using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace ValidateLength
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsPasswLength(textBox1.Text.Trim()))//驗證密碼長度是否正確
            {
                MessageBox.Show("密碼長度不正確\n" +//彈出消息對話框
                  "密碼長度為6-18位!!!", "提示");
            }
            else { MessageBox.Show("輸入訊息正確!!!!!", "提示"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證密碼長度是否正確
        /// </summary>
        /// <param name="str_Length">密碼字串</param>
        /// <returns>方法返回布林值</returns>
        public bool IsPasswLength(string str_Length)
        {
            return System.Text.RegularExpressions.Regex.//使用正規化運算式判斷是否符合
                IsMatch(str_Length, @"^\d{6,18}$");
        }
    }
}