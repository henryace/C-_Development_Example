using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidatePassWord
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsPassword(textBox1.Text.Trim()))//驗證密碼格式是否正確
            { MessageBox.Show("密碼格式不正確!!!"); }//彈出消息對話框
            else { MessageBox.Show("密碼格式正確!!!!!"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證碼碼輸入條件
        /// </summary>
        /// <param name="str_password">密碼字串</param>
        /// <returns>返回布爾值</returns>
        public bool IsPassword(string str_password)
        {
            return System.Text.RegularExpressions.//使用正則表達式判斷是否匹配
                Regex.IsMatch(str_password, @"[A-Za-z]+[0-9]");
        }
    }
}