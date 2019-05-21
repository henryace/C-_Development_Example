using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IsChinese
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (!IsChinese(textBox1.Text.Trim()))//驗證字串是否為中文字
            { MessageBox.Show("輸入的不是中文!!!", "提示"); }//彈出消息對話框
            else { MessageBox.Show("輸入正確!!!!!", "提示"); }//彈出消息對話框
        }

        /// <summary>
        /// 驗證字串是否為中文字
        /// </summary>
        /// <param name="str_chinese">字串</param>
        /// <returns>方法返回布林值</returns>
        public bool IsChinese(string str_chinese)
        {
            return System.Text.RegularExpressions.Regex.//使用正規化運算式判斷是否匹配
                IsMatch(str_chinese, @"^[\u4e00-\u9fa5],{0,}$");
        }
    }
}