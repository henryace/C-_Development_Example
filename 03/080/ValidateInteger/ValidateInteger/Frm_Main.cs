using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateInteger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsIntNumber(textBox1.Text.Trim()))//驗證輸入是否為非零正整數
            { MessageBox.Show("只充許輸入非零的正整數!!!", "提示"); }//彈出消息對話框
            else { MessageBox.Show("輸入訊息正確!!!!!", "提示"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證輸入是否為非零正整數
        /// </summary>
        /// <param name="str_intNumber">用戶輸入的數值</param>
        /// <returns>方法返回布林值</returns>
        public bool IsIntNumber(string str_intNumber)
        {
            return System.Text.RegularExpressions.Regex.//使用正規化運算式判斷是否符合
                IsMatch(str_intNumber, @"^\+?[1-9][0-9]*$");
        }
    }
}