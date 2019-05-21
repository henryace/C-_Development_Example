using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IsLetter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (!IsLetter(textBox1.Text.Trim()))//驗證字串是否為大小寫字母組成
            { MessageBox.Show("輸入的不是字母!!!", "提示"); }//彈出消息對話框
            else { MessageBox.Show("輸入的是字母!!!!!", "提示"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證字串是否為大小寫字母組成
        /// </summary>
        /// <param name="str_Letter">字串</param>
        /// <returns>方法返回布林值</returns>
        public bool IsLetter(string str_Letter)
        {
            return System.Text.RegularExpressions.Regex.//使用正規化運算式判斷是否匹配
                IsMatch(str_Letter, @"^[A-Za-z]+$");
        }
    }
}