using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateMonth
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (!IsMonth(textBox1.Text.Trim()))//驗證月份是否正確
            { MessageBox.Show("輸入月份不正確!!!", "提示"); }//彈出消息對話框
            else { MessageBox.Show("輸入訊息正確!!!!!", "提示"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證月份是否正確
        /// </summary>
        /// <param name="str_Month">月份訊息字串</param>
        /// <returns>返回布爾值</returns>
        public bool IsMonth(string str_Month)
        {
            return System.Text.RegularExpressions.Regex.//使用正則表達式判斷是否匹配
                IsMatch(str_Month, @"^(0?[[1-9]|1[0-2])$");
        }
    }
}