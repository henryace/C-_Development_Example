using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateCode
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsPostalcode(textBox1.Text))//驗證郵編格式是否正確
            { MessageBox.Show("郵政編號不正確!!!"); }//彈出消息對話框
            else { MessageBox.Show("郵政編號正確!!!!!"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證郵編格式是否正確
        /// </summary>
        /// <param name="str_postalcode">郵編字串</param>
        /// <returns>返回布爾值</returns>
        public bool IsPostalcode(string str_postalcode)
        {
            return System.Text.RegularExpressions.//使用正則表達式判斷是否匹配
                Regex.IsMatch(str_postalcode, @"^\d{6}$");
        }
    }
}