using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LetterCount
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (!IsLength(textBox1.Text.Trim()))//驗證輸入字串中的字符數量是否大於7個
            { MessageBox.Show("至少輸入8個字符!!!", "提示"); }//彈出消息對話框
            else { MessageBox.Show("輸入正確!!!!!", "提示"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證輸入字串中的字符數量是否大於7個
        /// </summary>
        /// <param name="str_Length">字串</param>
        /// <returns>方法返回布林值</returns>
        public bool IsLength(string str_Length)
        {
            return System.Text.RegularExpressions.Regex.//使用正規化運算式判斷是否匹配
                IsMatch(str_Length, @"^.{8,}$");
        }
    }
}