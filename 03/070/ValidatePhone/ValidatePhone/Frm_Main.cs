using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidatePhone
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsTelephone(textBox1.Text))//驗證電話號碼格式是否正確
            { MessageBox.Show("電話號碼格式不正確"); }//彈出消息對話框
            else { MessageBox.Show("電話號碼格式正確"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證電話號碼格式是否正確
        /// </summary>
        /// <param name="str_telephone">電話號碼訊息</param>
        /// <returns>方法返回布爾值</returns>
        public bool IsTelephone(string str_telephone)
        {
            return System.Text.RegularExpressions.//使用正則表達式判斷是否匹配
                Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }
    }
}