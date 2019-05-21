using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateURL
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (!IsUrl(textBox1.Text))//驗證網址格式是否正確
            { MessageBox.Show("網址格式不正確!!!"); }//彈出消息對話框
            else { MessageBox.Show("網址格式正確!!!!!"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證網址格式是否正確
        /// </summary>
        /// <param name="str_url">網址字串</param>
        /// <returns>方法返回布林值</returns>
        public bool IsUrl(string str_url)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_url,//使用正規化運算式判斷是否匹配
@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        }
    }
}