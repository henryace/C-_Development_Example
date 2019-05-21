using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidatePerson
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsIDcard(textBox1.Text.Trim()))//驗證身份證號是否正確
            { MessageBox.Show("身份證號不正確!!!"); }//彈出消息對話框
            else { MessageBox.Show("身份證號正確!!!!!"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證身份證號是否正確
        /// </summary>
        /// <param name="str_idcard">身份證號字串</param>
        /// <returns>返回布爾值</returns>
        public bool IsIDcard(string str_idcard)
        {
            return System.Text.RegularExpressions.Regex.//使用正則表達式判斷是否匹配
                IsMatch(str_idcard, @"(^\d{10}$)|(^\d{15}$)");
        }
    }
}