using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateDay
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (!IsDay(textBox1.Text.Trim()))//驗證每月的31天
            { MessageBox.Show("輸入天數不正確!!!", "提示"); }//彈出消息對話框
            else { MessageBox.Show("輸入訊息正確!!!!!", "提示"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證每月的31天
        /// </summary>
        /// <param name="str_day">每月的天數</param>
        /// <returns>返回布爾值</returns>
        public bool IsDay(string str_day)
        {
            return System.Text.RegularExpressions.Regex.//使用正則表達式判斷是否匹配
                IsMatch(str_day, @"^((0?[1-9])|((1|2)[0-9])|30|31)$");
        }
    }
}