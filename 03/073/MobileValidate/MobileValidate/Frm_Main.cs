using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobileValidate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsHandset(textBox1.Text))//驗證手機號是否正確
            { MessageBox.Show("手機號不正確!!!"); }//彈出消息對話框
            else { MessageBox.Show("手機號正確!!!!!"); }//彈出消息對話框

        }

        /// <summary>
        /// 驗證手機號是否正確
        /// </summary>
        /// <param name="str_handset">手機號碼字串</param>
        /// <returns>返回布爾值</returns>
        public bool IsHandset(string str_handset)
        {
            return System.Text.RegularExpressions.Regex.////使用正則表達式判斷是否匹配
                IsMatch(str_handset, @"^[0]+[3,5]+\d{10}$");
        }
    }
}