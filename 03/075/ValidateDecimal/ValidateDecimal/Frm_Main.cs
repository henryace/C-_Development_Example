using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateDecimal
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsDecimal(txt_Value.Text.Trim()))//驗證小數是否正確
            { MessageBox.Show("請輸入兩位小數!!!", "提示"); }//彈出消息對話框
            else { MessageBox.Show("輸入正確!!!!!", "提示"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證小數是否正確
        /// </summary>
        /// <param name="str_decimal">小數字串</param>
        /// <returns>返回布爾值</returns>
        public bool IsDecimal(string str_decimal)
        {
            return System.Text.RegularExpressions.Regex.//使用正則表達式判斷是否匹配
                IsMatch(str_decimal, @"^[0-9]+(.[0-9]{2})?$");
        }
    }
}